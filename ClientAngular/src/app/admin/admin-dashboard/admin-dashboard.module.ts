import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from 'src/app/dashboard/dashboard.component';
import { ProjectComponentComponent } from 'src/app/projects/project-component/project-component.component';
import { ProjectEditComponent } from 'src/app/projects/project-edit/project-edit.component';
import { AdminComponent } from '../admin.component';

const dashboardRoutes : Routes = [
  {path: 'dashboard', component: DashboardComponent},
  {path: 'project', component: ProjectComponentComponent},
  {path: 'project-edit/:id', component: ProjectEditComponent},

]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(dashboardRoutes)
  ]
})
export class AdminDashboardModule { }
