import { Component, OnInit } from '@angular/core';
import { Project } from "../../Model/project";
import { ApiService } from "../../utils/services/api.service";

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {

  project: Project[];

  constructor(
    private api: ApiService) { }

  ngOnInit() {
    this.getAllProject();
  }

  getAllProject() {
    this.api.getall("project/list").subscribe((data: Project[]) => {
      this.project = data;
    });
  }

  projectDelete(id) {
    this.api.delete("project/delete", id).subscribe(data => {
      window.location.reload();
    });
  }
}
