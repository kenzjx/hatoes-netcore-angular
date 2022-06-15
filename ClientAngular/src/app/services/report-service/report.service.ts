import { Injectable } from '@angular/core';
import {
  FormGroup,
  FormControl,
  ReactiveFormsModule,
  FormBuilder,
  Validators,
} from '@angular/forms';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IReport, Position, Project } from 'src/app/core/model/report';

@Injectable({
  providedIn: 'root',
})
export class ReportService {
  readonly BaseURI = 'https://localhost:5001';

  constructor(public http: HttpClient) {}

  userId: string = window.localStorage.getItem('Id') || '';

  getListReports(): Observable<IReport[]> {
    return this.http.get<IReport[]>(this.BaseURI + `/api/report/working-reports/${this.userId}?PageNumber=1&PageSize=100`);
  }

  // getListProjects(): Observable<Project[]>{
  //   return this.http.get<Project[]>(this.BaseURI + '/api/');
  // }

  // getListPositions(): Observable<Position[]>{
  //   return this.http.get<Position[]>(this.BaseURI + '/api/');
  // }
}
