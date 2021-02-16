import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { Customer } from '../../Model/customer';
import { Project } from "../../Model/project";
import { ApiService } from "../../utils/services/api.service";
import Swal from "sweetalert2";

@Component({
  selector: 'app-project-add',
  templateUrl: './project-add.component.html',
  styleUrls: ['./project-add.component.css']
})
export class ProjectAddComponent implements OnInit {

  project: Project[];
  customer: Customer[];
  CustomerId: number;
  modelProject: Object | Object[] = new Project();
  ProjectId: number;
  constructor(
    private api: ApiService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getAllCustomer();
    this.ProjectId = parseInt(this._activatedRoute.snapshot.paramMap.get("ProjectId"));
    this.api.getbyId("project/getById", this.ProjectId).subscribe(data => {
      this.modelProject = data;
    });
  }

  getAllCustomer() {
    this.api.getall("customer/list").subscribe((data: Customer[]) => {
      this.customer = data;
    });
  }

  onCusotmerSelected(customer_id) {
    this.CustomerId = customer_id;
  }

  onSave(projectForm: NgForm) {
    if (!projectForm.valid) {
      Swal.fire({
        title: "Please make sure the information is correct!",
        icon: "info"
      });
    }
    else {
      Number.isNaN((this.ProjectId) as any) ? this.projectAdd(projectForm) : this.projectUpdate(projectForm);
    }
  }

  projectAdd(projectForm: NgForm) {
    this.api.post("project/add",
      {
        ProjectName: projectForm.value.ProjectName,
        ProjectStarTime: projectForm.value.ProjectStarTime,
        ProjectFinishTime: projectForm.value.ProjectFinishTime,
        ProjectFee: projectForm.value.ProjectFee,
        CustomerId: this.CustomerId
  }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          Swal.fire({
            title: "Adding project failed!",
            icon: "error",
            showConfirmButton: false,
            timer: 1000
          });
        });
    Swal.fire({
      icon: 'success',
      title: 'Adding project succes',
      showConfirmButton: false,
      timer: 1500
    });
    this._router.navigateByUrl("project-list");
  }
  projectUpdate(projectForm: NgForm) {
    this.api.update("project/update",
      {
        ProjectId: this.ProjectId,
        ProjectName: projectForm.value.ProjectName,
        ProjectStarTime: projectForm.value.ProjectStarTime,
        ProjectFinishTime: projectForm.value.ProjectFinishTime,
        ProjectFee: projectForm.value.ProjectFee,
        CustomerId: this.CustomerId
      }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          Swal.fire({
            title: "Updating project failed!",
            icon: "error"
          });
        });
    Swal.fire({
      title: "Updating project is successful",
      icon: "success",
      showConfirmButton: false,
      timer: 1500
    });
    this._router.navigateByUrl("project-list");
  }
}
