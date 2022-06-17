import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {  Position, Project, ReportColumns, IReport } from 'src/app/core/model/report';
import { ReportService } from 'src/app/services/report-service/report.service';
import { FormBuilder, FormArray, Validators, FormGroup, FormControl } from '@angular/forms';


@Component({
  selector: 'app-myreport',
  templateUrl: './myreport.component.html',
  styleUrls: ['./myreport.component.scss'],
})
export class MyreportComponent implements OnInit {
  @ViewChild(MatSort) sort!: MatSort;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

    displayedColumns: string[] = ReportColumns.map((col) => col.key);
    columnsSchema: any = ReportColumns;
    dataSource = new MatTableDataSource<IReport>();
    valid: any = {};


  constructor(private reportService: ReportService,private fb: FormBuilder, private _formBuilder: FormBuilder) {}

  ngOnInit(): void {

    this.reportService.getListReports().subscribe((res:any)=>{
      this.dataSource.data = res;
    })

  }
  addRow() {
    const newRow: IReport = {
      id: 0,
      projectId: 0,
      projectName : '',
      positionId: 1,
      positionName: '',
      time: 8,
      date: '',
      type: '',
      note: '',
      status: 'Waiting',
      isEdit: true,
      isSelected: false,
    };
    this.dataSource.data = [newRow, ...this.dataSource.data];
  }

  removeRow(id: number){
  }

  removeSelectedRows() {}


}
