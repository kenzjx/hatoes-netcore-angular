import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { IReport, Position, Project } from 'src/app/core/model/report';
import { ReportService } from 'src/app/services/report-service/report.service';
import {
  FormBuilder,
  FormArray,
  Validators,
  FormGroup,
  FormControl,
} from '@angular/forms';

@Component({
  selector: 'app-myreport',
  templateUrl: './myreport.component.html',
  styleUrls: ['./myreport.component.scss'],
})
export class MyreportComponent implements OnInit {
  @ViewChild(MatSort) sort!: MatSort;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  displayedColumns: string[] = [
    'project',
    'position',
    'time',
    'day',
    'type',
    'note',
    'status',
    'action',
  ];

  dataSource!: MatTableDataSource<any>;
  isloading = true;
  TbForm!: FormGroup;

  listReports: IReport[] = [];
  listProjects!: Project[];
  listPositions!: Position[];

  constructor(
    private reportService: ReportService,
    private fb: FormBuilder,
    private _formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.reportService.getListReports().subscribe(
      (res) => {
        // this.listReports = res;
        // console.log(this.listReports);
        this.dataSource = new MatTableDataSource(res);
      },
      (error) => {
        console.log(error);
      }
    );

    // this.TbForm = this._formBuilder.group({
    //   TbRows: this._formBuilder.array([]),
    // });

    // this.TbForm = this.fb.group({
    //   TbRows: this.fb.array(
    //     this.listReports?.map((value) =>
    //       this.fb.group({
    //         projectName: new FormControl(value?.projectName),
    //         positionName: new FormControl(value?.positions?.positionName),
    //         time: new FormControl(value?.time),
    //         day: new FormControl(value?.day),
    //         note: new FormControl(value?.note),
    //         status: new FormControl(value?.status),
    //         type: new FormControl(value?.type),
    //         isEditable: new FormControl(true),
    //         isNewRow: new FormControl(false),
    //       })
    //     )
    //   ), //end of fb array
    // }); // end of form group cretation

    // this.dataSource = new MatTableDataSource(
    //   (this.TbForm.get('TbRows') as FormArray).controls

    // );
    // this.dataSource.paginator = this.paginator;

    // this.reportService.getListProjects().subscribe(
    //   (res) => (this.listProjects = res as []),
    //   (error) => {
    //     console.log(error);
    //   }
    // );

    // this.reportService.getListPositions().subscribe(
    //   (res) => (this.listPositions = res as []),
    //   (error) => {
    //     console.log(error);
    //   }
    // );
  }

  // onSearchClear() {
  //   this.searchKey = '';
  //   this.applyFilter();
  // }

  // applyFilter() {
  //   this.listReports.filter = this.searchKey.trim().toLocaleLowerCase();
  // }

  // addRow() {
  //   const newRow = {
  //     reportId: 0,
  //     projectId : 0,
  //     positionId : 0,
  //     time : 8,
  //     day: '',
  //     type: 1,
  //     note: '',
  //     status:1,
  //   };
  //   this.dataSource = [newRow, ...this.dataSource];
  // }

  AddNewRow() {
    // this.getBasicDetails();
    const control = this.TbForm.get('TbRows') as FormArray;
    control.insert(0, this.initiateVOForm());
    this.dataSource = new MatTableDataSource(control.controls);
    // control.controls.unshift(this.initiateVOForm());
    // this.openPanel(panel);
    // this.table.renderRows();
    // this.dataSource.data = this.dataSource.data;
  }

  initiateVOForm(): FormGroup {
    return this.fb.group({
      projectId: new FormControl(''),
      positionId: new FormControl(''),
      time: new FormControl(''),
      day: new FormControl(''),
      note: new FormControl(''),
      status: new FormControl(''),
      type: new FormControl(''),
      action: new FormControl('newRecord'),
      isEditable: new FormControl(false),
      isNewRow: new FormControl(true),
    });
  }
}
