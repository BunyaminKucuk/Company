import { Component, OnInit } from '@angular/core';
import { Task } from "../../Model/task";
import { ApiService } from "../../utils/services/api.service";

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {

  task: Task[];
  constructor(
    private api: ApiService) { }

  ngOnInit() {
    this.getAllTask();
  }

  getAllTask() {
    this.api.getall("task/list").subscribe((data: Task[]) => {
      this.task = data;
    });
  }

  taskDelete(task_id) {

  }
}
