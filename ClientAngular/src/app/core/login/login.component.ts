import { Component, OnInit } from '@angular/core';
import {
  SocialAuthService,
  SocialUser,
  GoogleLoginProvider,
} from 'angularx-social-login';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {

  user?: SocialUser;
  hasApiAccess = false;

  constructor(private socialAuthService: SocialAuthService,
              private http: HttpClient) { }

              ngOnInit(): void {
                this.socialAuthService.authState.subscribe((user) => {
                  if (user) {
                    this.http.post<any>('https://localhost:7033/google', { idToken: user.idToken, accessToken: user.response.access_token }).subscribe((authToken: any) => {
                      console.log(authToken);
                      let reqHeader = new HttpHeaders({
                        'Content-Type': 'application/json',
                        'Authorization': 'Bearer ' + authToken.authToken
                      });
                      // this.http.get<any>('https://localhost:44361/secured', { headers: reqHeader }).subscribe((data: any) => {
                      //   this.hasApiAccess = true;
                      // })
                    })
                  }
                  this.user = user;
                })
              }
              loginWithgoogle(): any {
                this.socialAuthService.signIn(GoogleLoginProvider.PROVIDER_ID);
                console.log(this.user?.idToken)
              }
              signout(): any {
                this.socialAuthService.signOut();
              }
}
