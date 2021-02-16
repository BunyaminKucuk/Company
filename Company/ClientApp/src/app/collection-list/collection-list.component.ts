import { Component, OnInit } from '@angular/core';
import { Collection } from "../Model/collection";
import { ApiService } from "../utils/services/api.service";
import { Project } from "../Model/project";

@Component({
  selector: 'app-collection-list',
  templateUrl: './collection-list.component.html',
  styleUrls: ['./collection-list.component.css']
})
export class CollectionListComponent implements OnInit {

  collection : Collection[];
  project : Project[];
  modelCollection: Object | Object[] = new Collection();


  constructor(
    private api:ApiService) { }

  ngOnInit() {
    this.getAllProject();
  }

  onProjectSelected(val: any) {
    this.getAllProjectById(val);
  }

  getAllProjectById(project_id) {
    this.api.getbyId("collection/getByProjectId", project_id).subscribe(data => {
      this.modelCollection = data;
    });
    console.log("project id",project_id);
    console.log("data", this.modelCollection);
  }

  getAllProject() {
    this.api.getall("project/list").subscribe((data: Project[]) => {
      this.project = data;
    });
  }
  collectionDelete(collection_id) {

  }
}
