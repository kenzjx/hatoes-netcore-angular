import { Component, OnInit } from '@angular/core';

import {
  SocialAuthService,
  SocialUser,
  GoogleLoginProvider,
} from 'angularx-social-login';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Router } from '@angular/router';
import { pipe } from 'rxjs';

import {map} from 'rxjs/operators';
import { UserServiceService } from 'src/app/services/user-service/user-service.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',

  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  user?: SocialUser;
  hasApiAccess = false;

  constructor(private socialAuthService: SocialAuthService,
              private http: HttpClient,
              private router: Router,
              private userService : UserServiceService) { }

              ngOnInit(): void {

              }
              loginWithgoogle(): any {
                this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID).then(googleLogin =>{
                  console.log(googleLogin.idToken);
                  const idToken = googleLogin.idToken;
                 this.userService.googlelogin(idToken).subscribe(data => {
                   console.log(data);
                  this.userService.decodeJWT(data);
                 })
                });
                this.router.navigateByUrl('/admin');
              }
              signout(): any {
                this.socialAuthService.signOut();
              }

}
