<<<<<<< HEAD
import { Injectable } from '@angular/core';
=======
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
>>>>>>> origin/khaivm_loginGG

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {

<<<<<<< HEAD
  constructor() { }
=======
  constructor(private http : HttpClient) { }

  googlelogin(idToken :any)
  {
    return this.http.post('https://localhost:5001/google', {idToken},{responseType : 'text' });
  }
>>>>>>> origin/khaivm_loginGG
}
