import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from 'src/app/dashboard/dashboard.component';
import { ProjectComponentComponent } from 'src/app/projects/project-component/project-component.component';
import { ProjectEditComponent } from 'src/app/projects/project-edit/project-edit.component';
import { AdminComponent } from '../admin.component';
import { UserComponent } from 'src/app/user/user.component';
import { HttpClientModule } from '@angular/common/http';

const dashboardRoutes : Routes = [
  {path: 'dashboard', component: DashboardComponent},
  {path: 'project', component: ProjectComponentComponent},
  {path: 'project-edit/:id', component: ProjectEditComponent},
  {path: 'account-settings', component: UserComponent}
]

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    HttpClientModule,
    RouterModule.forChild(dashboardRoutes)
  ]
})
export class AdminDashboardModule { }
