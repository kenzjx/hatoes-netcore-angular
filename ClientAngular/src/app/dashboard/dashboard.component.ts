import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  template: `
  <app-page-header icon="DashBoard">
    <h2>DashBoard</h2>

    <button
      routerLink="/sales"
      mat-flat-button
      color="primary"
      class="action"
    >
      <mat-icon class="mr-2">add</mat-icon>
      <span>Create</span>
    </button>
  </app-page-header>

  <div style="padding: 0 20px">
    Hello from Hello DashBoard
  </div>
`

})
export class DashboardComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
