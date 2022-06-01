import { ChangeDetectionStrategy, Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  template: `
  <mat-toolbar color="primary">
    <button (click)="menuToggled.emit(true)" mat-icon-button>
      <mat-icon>menu</mat-icon>
    </button>
    <span class="title" routerLink="/">Dashboard</span>
    <span class="spacer"></span>
    <span class="welcome-text">Hello {{ user }}</span>
    <button mat-icon-button [matMenuTriggerFor]="menu">
      <mat-icon>person_pin</mat-icon>
    </button>
    <mat-menu #menu="matMenu">
      <button mat-menu-item (click)="logout()">
        <span>Logout</span>
      </button>
    </mat-menu>
  </mat-toolbar>
`,
  styleUrls: ['./header.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HeaderComponent implements OnInit {

  @Output() menuToggled = new EventEmitter<boolean>();

  user: string = 'Phong';

  constructor() { }

  ngOnInit(): void {
  }

  logout(): void {
    console.log('Logged out');
  }
}
