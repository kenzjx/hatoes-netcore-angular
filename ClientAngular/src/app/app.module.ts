import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatSliderModule} from '@angular/material/slider'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
<<<<<<< HEAD
import { GoogleLoginProvider, SocialLoginModule } from 'angularx-social-login';
=======

import { SocialLoginModule, SocialAuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider } from 'angularx-social-login';
>>>>>>> origin/khaivm_loginGG

import { DashboardComponent } from './dashboard/dashboard.component';
import { NgChartsModule } from 'ng2-charts';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';

import { MatGridListModule } from '@angular/material/grid-list';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatExpansionModule } from '@angular/material/expansion';
import { Routes } from '@angular/router';
import { MyreportComponent } from './reports/myreport/myreport.component';
import { HeaderComponent } from './core/header/header.component';
import { MenuComponent } from './core/menu/menu.component';
import { LoginComponent } from './core/login/login.component';
import { FooterComponent } from './core/footer/footer.component';
import { AdminComponent } from './admin/admin.component';
import { ManageReportComponent } from './reports/manage-report/manage-report.component';
import { HttpClientModule } from '@angular/common/http';
<<<<<<< HEAD
=======
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
>>>>>>> origin/khaivm_loginGG


@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    MyreportComponent,
    HeaderComponent,
    MenuComponent,
    LoginComponent,
    FooterComponent,
    AdminComponent,
    ManageReportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSliderModule,
    SocialLoginModule,
    NgChartsModule,
    LayoutModule,
    // MATERIAL IMPORT
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatGridListModule,
    MatCardModule,
    MatMenuModule,
    MatExpansionModule,
<<<<<<< HEAD

    HttpClientModule
=======
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
>>>>>>> origin/khaivm_loginGG
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
<<<<<<< HEAD
              'ClientId'
=======
              '557580645532-f2om83vuokm89evq4t70b722eq57rvtk.apps.googleusercontent.com'
>>>>>>> origin/khaivm_loginGG
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
