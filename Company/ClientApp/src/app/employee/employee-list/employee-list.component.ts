import { Component, OnInit } from '@angular/core';
import { Employee } from "../../Model/employee";
import { ApiService } from "../../utils/services/api.service";

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(
    private  api:ApiService) { }

  employee : Employee[];
  ngOnInit() {
    this.getAllEmployee();
  }


  getAllEmployee() {
    this.api.getall("employee/list").subscribe((data: Employee[]) => {
      this.employee = data;
    });
  }

  employeeDelete(id) {
    this.api.delete("employee/delete", id).subscribe(data => {
      window.location.reload();
    });
  }
}
