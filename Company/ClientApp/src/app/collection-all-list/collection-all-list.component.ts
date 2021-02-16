import { Component, OnInit } from '@angular/core';
import { ApiService } from "../utils/services/api.service";
import { Collection } from "../Model/collection";

@Component({
  selector: 'app-collection-all-list',
  templateUrl: './collection-all-list.component.html',
  styleUrls: ['./collection-all-list.component.css']
})
export class CollectionAllListComponent implements OnInit {

  collection: Collection[];
  constructor(
    private api: ApiService) { }

  ngOnInit() {
    this.getAllCollections();
  }

  getAllCollections() {
    this.api.getall("collection/list").subscribe((data: Collection[]) => {
      this.collection = data;
    });
  }
  //collectionTotal(CollectionPaymentAmount) {
  //  if ( var i = 0; i<this.collection.length) {

  //  }
  //}
}
