import { Component, OnInit } from '@angular/core';
import { Company } from "../Model/company";
import { ApiService } from "../utils/services/api.service";

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html',
  styleUrls: ['./company.component.css'],

})
export class CompanyComponent implements OnInit {

  constructor(
    private api:ApiService
    ) { }

  company: Company[];
  searchText:'';

  ngOnInit() {
    this.getAllCompany();
  }



  getAllCompany() {
    this.api.getall("corporation/list").subscribe((data: Company[]) => {
      this.company = data;
    });
  }

  companyDelete(id) {
    this.api.delete("corporation/delete", id).subscribe(data => {
      window.location.reload();
    });
  }


}
