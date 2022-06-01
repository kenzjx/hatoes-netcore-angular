import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatSliderModule} from '@angular/material/slider'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GoogleLoginProvider, SocialLoginModule } from 'angularx-social-login';
import { LoginGoogleComponent } from './login-google/login-google.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NgChartsModule } from 'ng2-charts';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { NavComponent } from './dashboard/nav/nav.component';
import { DashComponent } from './dashboard/dash/dash.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { CardComponent } from './dashboard/dash/card/card.component';
import { MyLineChartComponent } from './dashboard/dash/my-line-chart/my-line-chart.component';
import { MenuComponent } from './core/menu/menu.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { HeaderComponent } from './core/header/header.component';
import { LayoutComponent } from './core/layout/layout.component';
import { PageHeaderComponent } from './core/page-header/page-header.component';
import { Routes } from '@angular/router';
import { MyreportComponent } from './reports/myreport/myreport.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginGoogleComponent,
    DashboardComponent,
    NavComponent,
    DashComponent,
    CardComponent,
    MyLineChartComponent,
    MenuComponent,
    HeaderComponent,
    LayoutComponent,
    PageHeaderComponent,
    MyreportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSliderModule,
    SocialLoginModule,
    NgChartsModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatExpansionModule
  ],
  providers: [
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              'ClientId'
            )
          }
        ],
        onError: (err : any) => {
          console.error(err);
        }
      } as SocialLoginModule
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
