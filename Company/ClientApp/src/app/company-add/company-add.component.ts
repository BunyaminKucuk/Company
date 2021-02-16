import { Component, OnInit } from "@angular/core";
import { ApiService } from "../utils/services/api.service";
import { NgForm } from "@angular/forms";
import { Company } from "../Model/company";
import { first } from "rxjs/internal/operators/first";
import { ActivatedRoute, Router } from "@angular/router";
import Swal from "sweetalert2";

@Component({
  selector: "app-company-add",
  templateUrl: "./company-add.component.html",
  styleUrls: ["./company-add.component.css"]
})
export class CompanyAddComponent implements OnInit {


  company: Company[];
  modelCompany: Object | Object[] = new Company();
  CompanyId: number;

  constructor(
    private api: ApiService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.CompanyId = parseInt(this._activatedRoute.snapshot.paramMap.get("CompanyId"));
    this.api.getbyId("corporation/getById", this.CompanyId).subscribe(data => {
      this.modelCompany = data;
    });
  }


  onSave(companyForm: NgForm) {
    if (!companyForm.valid) {
      Swal.fire({
        title: "Please make sure the information is correct!",
        icon: "info"
      });
    }
    else {
      Number.isNaN((this.CompanyId) as any) ? this.companyAdd(companyForm) : this.companyUpdate(companyForm);
    }
  }

  companyAdd(companyForm: NgForm) {
    this.api.post("corporation/add",
      {
        CompanyName: companyForm.value.CompanyName,
        CompanyAddress: companyForm.value.CompanyAddress,
        CompanyPhone: companyForm.value.CompanyPhone
      }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          Swal.fire({
            title: "Adding company failed!",
            icon: "error",
            showConfirmButton: false,
            timer: 1000
          });
        });
    Swal.fire({
      icon: 'success',
      title: 'Adding company succes',
      showConfirmButton: false,
      timer: 1500
    });
    this._router.navigateByUrl("company-list");
  }
  companyUpdate(companyForm: NgForm) {
    this.api.update("corporation/update",
      {
        CompanyId: this.CompanyId,
        CompanyName: companyForm.value.CompanyName,
        CompanyAddress: companyForm.value.CompanyAddress,
        CompanyPhone: companyForm.value.CompanyPhone
      }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          Swal.fire({
            title: "Updating company failed!",
            icon: "error"
          });
        });
    Swal.fire({
      title: "Updating company is successful",
      icon: "success",
      showConfirmButton: false,
      timer: 1500
    });
    this._router.navigateByUrl("company-list");
  }

}
