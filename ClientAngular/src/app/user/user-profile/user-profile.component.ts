import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { pipe } from 'rxjs';
import { IUserReponse } from 'src/app/core/Models/User/UserReponse';
import { UserServiceService } from 'src/app/services/user-service/user-service.service';
import {map} from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {

  constructor(private userService : UserServiceService, private http: HttpClient, private datePipe: DatePipe) { }

  ngOnInit(): void {
  }

  urlPhoto !: string;

  data !: IUserReponse;

  userId : string   = window.localStorage.getItem('Id') || '';

  getUserProfile()
  {
    this.userService.getProfileUser(this.userId).pipe(map((data : any) =>{this.data = data})).subscribe();
  }


  getPhoto()
  {
    return this.http.get(`http://localhost:5001/FileManager/${this.userId}`, {responseType: 'blob'})
    .subscribe((result: any) => {
      const blob = new Blob([result], {type: result.headers?.get('content-type')!}); // you can change the type
      const uri = window.URL.createObjectURL(blob);
      this.urlPhoto = uri;
  })}



  proFile = new FormGroup({
    firstName : new FormControl('', Validators.required),
    lastName : new FormControl('', Validators.required),
    birthDay : new FormControl(Date,Validators.required),
    address : new FormControl('',Validators.required),
    phone : new FormControl('',Validators.required)
  })

  fileUpload :any;
  handleFileInput(e : any)
  {
    this.fileUpload = e?.target?.value[0];
  }

  savePhoto(){
    const formData : FormData = new FormData();
    formData.append('myfile', this.fileUpload);
    this.http.put(``, formData).subscribe(data => console.log(data));
  }
  reset()
  {

  }

  updateUser(proFileValue : any)
  {
    const userProfile  = {
      firstName : proFileValue.firstName,
      lastName : proFileValue.lastName,
      birthday : this.datePipe.transform(proFileValue.birthDay, 'yyyy-MM-dd'),
      address : proFileValue.address,
      phone : proFileValue.phone
    }
    this.http.put(``, userProfile).subscribe(data => console.log(data));
  }


}
