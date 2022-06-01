import { Component, OnInit } from '@angular/core';
import { Menu } from '../menu/menu.models';

@Component({
  selector: 'app-layout',
  template: `
    <div>
      <app-header (menuToggled)="toggle()"></app-header>

      <mat-drawer-container>
        <mat-drawer mode="side" [opened]="opened">
          <app-menu [menu]="menu"></app-menu>
        </mat-drawer>

        <mat-drawer-content [class.margin-left]="opened">
          <router-outlet></router-outlet>
        </mat-drawer-content>
      </mat-drawer-container>
    </div>
  `,
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  opened = true;

  toggle(): void {
    this.opened = !this.opened;
  }

  menu: Menu = [
    {
      title: 'DashBoard',
      icon: 'home',
      link: '/home',
      color: '#ff7f0e'
    },
    {
      title: 'Report',
      icon: 'bar_chart',
      color: '#ff7f0e',
      subMenu: [
        {
          title: 'MyReport',
          icon: 'money',
          link: '/myport',
          color: '#ff7f0e'
        },
        {
          title: 'Customers',
          icon: 'people',
          color: '#ff7f0e',
          link: '/customers'
        }
      ]
    }
  ];

  constructor() { }

  ngOnInit(): void {
  }

}
