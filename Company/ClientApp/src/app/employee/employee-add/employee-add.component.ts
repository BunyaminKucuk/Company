import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiService } from "../../utils/services/api.service";
import { Employee } from "../../Model/employee";
import { NgForm } from '@angular/forms';
import { first } from 'rxjs/operators';
import Swal from "sweetalert2";
import { Task } from "../../Model/task";


@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.css']
})
export class EmployeeAddComponent implements OnInit {


  employee: Employee[];
  task:Task[];
  modelEmployee: Object | Object[] = new Employee();
  EmployeeId: number;
  TaskId: number;
  

  constructor(
    private api: ApiService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.gelAllTask();
    this.EmployeeId = parseInt(this._activatedRoute.snapshot.paramMap.get("EmployeeId"));
    this.api.getbyId("employee/getById", this.EmployeeId).subscribe(data => {
      this.modelEmployee = data;
    });
  }

  gelAllTask() {
    this.api.getall("task/list").subscribe((data: Task[]) => {
      this.task = data;
    })
  }

  onEmployeeSelected(task_id) {
    this.TaskId = task_id;
  }

  onSave(employeeForm: NgForm) {
    if (!employeeForm.valid) {
      Swal.fire({
        title: "Please make sure the information is correct!",
        icon: "info"
      });
    }
    else {
      Number.isNaN((this.EmployeeId) as any) ? this.employeeAdd(employeeForm) : this.employeeUpdate(employeeForm);
    }
  }

  employeeAdd(employeeForm: NgForm) {
    this.api.post("employee/add",
      {
        EmployeeFirstName: employeeForm.value.EmployeeFirstName,
        EmployeeLastName: employeeForm.value.EmployeeLastName,
        EmployeeMail: employeeForm.value.EmployeeMail,
        EmployeeSalary: employeeForm.value.EmployeeSalary,
        EmployeePhone: employeeForm.value.EmployeePhone,
        EmployeeTaskId: this.TaskId
  }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          Swal.fire({
            title: "Adding employee failed!",
            icon: "error",
            showConfirmButton: false,
            timer: 1000
          });
        });
    Swal.fire({
      icon: 'success',
      title: 'Adding employee succes',
      showConfirmButton: false,
      timer: 1500
    });
    console.log(
      "Adding employee is successful",
      "Success"
    );
    this._router.navigateByUrl("employee-list");
  }
  employeeUpdate(employeeForm: NgForm) {
    this.api.update("employee/update",
      {
        EmployeeId: this.EmployeeId,
        EmployeeFirstName: employeeForm.value.EmployeeFirstName,
        EmployeeLastName: employeeForm.value.EmployeeLastName,
        EmployeeMail: employeeForm.value.EmployeeMail,
        EmployeeSalary: employeeForm.value.EmployeeSalary,
        EmployeePhone: employeeForm.value.EmployeePhone,
        EmployeeTaskId: this.TaskId
      }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          Swal.fire({
            title: "Updating employee failed!",
            icon: "error"
          });
        });
    Swal.fire({
      title: "Updating employee is successful",
      icon: "success",
      showConfirmButton: false,
      timer: 1500
    });
    this._router.navigateByUrl("employee-list");
  }
}
