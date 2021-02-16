import { Component, OnInit } from "@angular/core";
import { ApiService } from "../../utils/services/api.service";
import { Customer } from "../../Model/customer";
import { ActivatedRoute, Router } from "@angular/router";
import { NgForm } from "@angular/forms/forms";
import { first } from "rxjs/operators";
import Swal from "sweetalert2";
import { Company } from "../../Model/company";

@Component({
  selector: "app-customer-add",
  templateUrl: "./customer-add.component.html",
  styleUrls: ["./customer-add.component.css"]
})
export class CustomerAddComponent implements OnInit {

  customer: Customer[];
  company: Company[];
  modelCustomer: Object | Object[] = new Customer();
  CustomerId: number ;
  CompanyId: number;


  constructor(
    private api: ApiService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.getAllCompany();
    this.CustomerId = parseInt(this._activatedRoute.snapshot.paramMap.get("CustomerId"));
    this.api.getbyId("customer/getById", this.CustomerId).subscribe(data => {
      this.modelCustomer = data;
    });
  }

  getAllCompany() {
    this.api.getall("corporation/list").subscribe((data :Company[])=> {
      this.company = data;
    })
  }

  onCompanySelected(company_id) {
    this.CompanyId = company_id;
  }

  onSave(customerForm: NgForm) {
    if (!customerForm.valid) {
      Swal.fire({
        title: "Please make sure the information is correct!",
        icon: "info"
      });
    }
    else {
      Number.isNaN((this.CustomerId) as any) ? this.customerAdd(customerForm) : this.customerUpdate(customerForm);
    }
  }

  customerAdd(customerForm: NgForm) {
    this.api.post("customer/add",
      {
        CustomerFirstName: customerForm.value.CustomerFirstName,
        CustomerLastName: customerForm.value.CustomerLastName,
        CustomerEmail: customerForm.value.CustomerEmail,
        CustomerAddress: customerForm.value.CustomerAddress,
        CustomerPhone: customerForm.value.CustomerPhone,
        CompanyId: this.CompanyId 
      }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          Swal.fire({
            title: "Adding customer failed!",
            icon: "error",
            showConfirmButton: false,
            timer: 1000
          });
        });
    Swal.fire({
      icon: 'success',
      title: 'Adding customer succes',
      showConfirmButton: false,
      timer: 1500
    });
    this._router.navigateByUrl("customer-list");
  }
  customerUpdate(customerForm: NgForm) {
    this.api.update("customer/update",
      {
        CustomerId: this.CustomerId,
        CustomerFirstName: customerForm.value.CustomerFirstName,
        CustomerLastName: customerForm.value.CustomerLastName,
        CustomerEmail: customerForm.value.CustomerEmail,
        CustomerAddress: customerForm.value.CustomerAddress,
        CustomerPhone: customerForm.value.CustomerPhone,
        CompanyId: this.CompanyId 
      }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          Swal.fire({
            title: "Updating customer failed!",
            icon: "error"
          });
        });
    Swal.fire({
      title: "Updating customer is successful",
      icon: "success",
      showConfirmButton: false,
      timer: 1500
    });
    this._router.navigateByUrl("customer-list");
  }

}

