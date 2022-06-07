import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

  constructor(private http : HttpClient) { }

  googlelogin(idToken :any)
  {
    return this.http.post('https://localhost:5001/google', {idToken},{responseType : 'text' });
  }
}
