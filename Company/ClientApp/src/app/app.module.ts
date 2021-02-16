import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { HomeComponent } from "./home/home.component";
import { LoginComponent } from "./login/login.component";
import { RegisterComponent } from "./register/register.component";
import { CompanyComponent } from "./company/company.component";
import { CompanyAddComponent } from "./company-add/company-add.component";
import { ProjectListComponent } from "./project/project-list/project-list.component";
import { ProjectAddComponent } from "./project/project-add/project-add.component";
import { EmployeeAddComponent } from "./employee/employee-add/employee-add.component";
import { EmployeeListComponent } from "./employee/employee-list/employee-list.component";
import { CustomerAddComponent } from "./customer/customer-add/customer-add.component";
import { CustomerListComponent } from "./customer/customer-list/customer-list.component";
import { TaskListComponent } from "./task/task-list/task-list.component";
import { TaskAddComponent } from "./task/task-add/task-add.component";
import { CollectionListComponent } from "./collection-list/collection-list.component";
import { CollectionAllListComponent } from "./collection-all-list/collection-all-list.component";


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    CompanyComponent,
    CompanyAddComponent,
    ProjectListComponent,
    ProjectAddComponent,
    EmployeeAddComponent,
    EmployeeListComponent,
    CustomerAddComponent,
    CustomerListComponent,
    TaskListComponent,
    TaskAddComponent,
    CollectionListComponent,
    CollectionAllListComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "register", component: RegisterComponent },
      { path: "login", component: LoginComponent },
      { path: "company-list", component: CompanyComponent },
      { path: "company-add", component: CompanyAddComponent },
      { path: "project-list", component: ProjectListComponent },
      { path: "project-add", component: ProjectAddComponent },
      { path: "employee-list", component: EmployeeListComponent },
      { path: "employee-add", component: EmployeeAddComponent },
      { path: "customer-list", component: CustomerListComponent },
      { path: "customer-add", component: CustomerAddComponent },
      { path: "task-list", component: TaskListComponent },
      { path: "task-add", component: TaskAddComponent },
      { path: "company-update/:CompanyId", component: CompanyAddComponent },
      { path: "customer-update/:CustomerId", component: CustomerAddComponent },
      { path: "project-update/:ProjectId", component: ProjectAddComponent },
      { path: "employee-update/:EmployeeId", component: EmployeeAddComponent },
      { path: "task-update/:TaskId", component: TaskAddComponent },
      { path: "collection-list", component: CollectionListComponent },
      { path: "collection-all-list", component: CollectionAllListComponent },
    ])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
