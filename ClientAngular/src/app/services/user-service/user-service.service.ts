import jwt_decode from 'jwt-decode';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, pipe } from 'rxjs';
import { map } from 'rxjs/operators';
import { IUserDecode } from 'src/app/core/Models/User/UserDecode';
import { IUserReponse } from 'src/app/core/Models/User/UserReponse';
import { environment } from 'src/environments/environment';
import { IProfileUser } from 'src/app/core/Models/User/IProfileUser';
@Injectable({
  providedIn: 'root',
})
export class UserServiceService {
  private expToken = new BehaviorSubject(0);
  private JWT = new BehaviorSubject<string | any>({} as string);

  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) {}

  googlelogin(idToken: any) {
    return this.http.post(
      `${this.baseUrl}/google`,
      { idToken },
      { responseType: 'text' }
    );
  }

  isLoggedIn!: boolean;

  decodeJWT(JWT: any) {
    if (JWT) {
      this.JWT.next(JWT);
      const decodeJWT: any = jwt_decode(JWT);
      if (decodeJWT) {
        const saveUser: IUserDecode = {
          Id: decodeJWT.Id,
          Email: decodeJWT.Email,
          role: decodeJWT.role,
        };
        this.isLoggedIn = this.expiredLogin(decodeJWT.exp);
        this.saveUserJWT(saveUser);
      } else {
      }
    }
  }

  saveUserJWT(userDecode: IUserDecode) {
    window.localStorage.setItem('Id', userDecode.Id);
    window.localStorage.setItem('Email', userDecode.Email);
    window.localStorage.setItem('role', userDecode.role);
  }

  removeUserLocal(){
    window.localStorage.clear();
  }


  getUserJWT(): IUserDecode | any {
    const userReponse: IUserDecode = {
      Id: window.localStorage.getItem('Id') || '',
      Email: window.localStorage.getItem('Email') || '',
      role: window.localStorage.getItem('role') || '',
    };
    return userReponse;
  }

  exp: number = 0;
  expiredLogin(data: number): boolean {
    if (this.exp == 0) {
      return false;
    }
    const tokenExpired = Date.now() > this.exp * 1000;
    return !tokenExpired;
  }

  getProfileUser(id: string) : Observable<IProfileUser>   {
  return  this.http
      .get<IProfileUser>(
        `https://localhost:5001/api/user/profileuser/${id}`
      );

  }

  updateProfileUser(formData: FormData) {
    this.http.put(`${this.baseUrl}/`, formData).pipe(
      map((profile) => {
        return profile;
      })
    );
  }
}
