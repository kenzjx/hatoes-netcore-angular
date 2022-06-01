import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './core/layout/layout.component';
import { DashComponent } from './dashboard/dash/dash.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MyreportComponent } from './reports/myreport/myreport.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'home'
  },
  {path: '',
component: LayoutComponent,
children: [
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'myreport',
    component: MyreportComponent
  }
]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
