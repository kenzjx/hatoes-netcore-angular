import { Component, OnInit } from '@angular/core';
<<<<<<< HEAD
=======
import {
  SocialAuthService,
  SocialUser,
  GoogleLoginProvider,
} from 'angularx-social-login';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { pipe } from 'rxjs';

import {map} from 'rxjs/operators';
import { UserServiceService } from 'src/app/services/user-service/user-service.service';
>>>>>>> origin/khaivm_loginGG

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
<<<<<<< HEAD
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

=======
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
                 this.userService.googlelogin(idToken).subscribe(data => console.log(data))
                });
                this.router.navigateByUrl('/dashboard');
              }
              signout(): any {
                this.socialAuthService.signOut();
              }
>>>>>>> origin/khaivm_loginGG
}