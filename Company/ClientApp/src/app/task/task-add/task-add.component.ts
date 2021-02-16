import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { Task } from "../../Model/task";
import { ApiService } from "../../utils/services/api.service";

@Component({
  selector: 'app-task-add',
  templateUrl: './task-add.component.html',
  styleUrls: ['./task-add.component.css']
})
export class TaskAddComponent implements OnInit {

  task: Task[];
  modelTask: Object | Object[] = new Task();
  TaskId: number;
  constructor(
    private api: ApiService,
    private _router: Router,
    private _activatedRoute: ActivatedRoute
  ) { }

  ngOnInit() {
    this.TaskId = parseInt(this._activatedRoute.snapshot.paramMap.get("TaskId"));
    this.api.getbyId("task/getById", this.TaskId).subscribe(data => {
      this.modelTask = data;
    });
  }

  onSave(taskForm: NgForm) {
    if (!taskForm.valid) {
      console.log(
        "Please make sure the information is correct!",
        "Error"
      );
    }
    else {
      Number.isNaN((this.TaskId) as any) ? this.taskAdd(taskForm) : this.taskUpdate(taskForm);
    }
  }

  taskAdd(taskForm: NgForm) {
    this.api.post("task/add",
        {
          TaskName: taskForm.value.TaskName,
        }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          console.error(
            "Adding task failed!",
            "Error"
          );
        });
    console.log(
      "Adding task is successful",
      "Success"
    );
    //this._router.navigateByUrl("task/list");
  }
  taskUpdate(taskForm: NgForm) {
    this.api.update("task/update",
        {
          TaskId: this.TaskId,
          TaskName: taskForm.value.TaskName,
        }).pipe(first())
      .subscribe(
        data => {
          console.log("data", data);
        },
        error => {
          console.log("error", error);
          console.error(
            "Updating task failed!",
            "Error"
          );
        });
    console.log(
      "Updating task is successful",
      "Success"
    );
    //this._router.navigateByUrl("task/list");
  }
}
