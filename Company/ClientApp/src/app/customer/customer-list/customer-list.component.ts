import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Customer } from "../../Model/customer";
import { ApiService } from "../../utils/services/api.service";

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  constructor(
    private api: ApiService,
    private _router: Router
  ) { }

  customer: Customer[];
  id: Customer[];
  ngOnInit() {
    this.getAllCustomer();
  }

  getAllCustomer() {
    this.api.getall("customer/list").subscribe((data: Customer[]) => {
      this.customer = data;
    });
  }

  customerDelete(id) {
    this.api.delete("customer/delete", id).subscribe(data => {
      window.location.reload();
    });
  }
}
