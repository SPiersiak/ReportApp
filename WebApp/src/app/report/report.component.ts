import { PaginnationPageResponseDto } from './../interface/PaginnationPageResponseDto';
import { ReportService } from './../infrastructure/service/report/report.service';
import { PremiseService } from '../infrastructure/service/premise/premise.service';
import { PremiseDto } from '../interface/PremiseDto';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatOption, MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { ReportDto } from '../interface/ReportDto';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';

@Component({
  selector: 'app-report',
  standalone: true,
  imports: [MatFormFieldModule, MatSelectModule, FormsModule, ReactiveFormsModule, MatOption, CommonModule, MatInputModule, MatDatepickerModule, MatNativeDateModule, MatTableModule, MatPaginatorModule],
  templateUrl: './report.component.html',
  styleUrl: './report.component.css'
})
export class ReportComponent implements OnInit {
  public premiseResult: PremiseDto[] = [] as PremiseDto[];
  public reportData= {} as PaginnationPageResponseDto<ReportDto>;
  public premiseFormControl: FormControl;
  public dateFromControl: FormControl;
  public dateToControl: FormControl;
  public minValue: Date = {} as Date;
  public maxValue: Date = {} as Date;
  displayedColumns: string[] = ['reportName', 'reportDate', 'reportTime', 'userName', 'premiseName'];

  public constructor(
    private premiseService: PremiseService,
    private reportService: ReportService
  )
  {
    this.reportData.pageIndex = 1;
    this.reportData.pageSize = 25;
    this.reportData.totalRecords = 0;
    this.premiseFormControl = new FormControl('');
    this.dateFromControl = new FormControl('');
    this.dateToControl = new FormControl('');
  }

  ngOnInit(): void {
    this.premiseService.getPremises().subscribe(result => {
      this.premiseResult = result;
    })
  }

  onPaginateChange(event: PageEvent){
    this.reportService.getPremises(event.pageIndex + 1, event.pageSize, this.dateFromControl.value, this.dateToControl.value, this.premiseFormControl.value).subscribe(result => {
      this.reportData = result;
    })
  }

  confirmButtonOnClick(event: Event){
    this.reportService.getPremises(1, this.reportData.pageSize, this.dateFromControl.value, this.dateToControl.value, this.premiseFormControl.value).subscribe(result => {
      this.reportData = result;
    })
  }

  handleDateFromOnChange(event: MatDatepickerInputEvent<Date>) {
    if (event.value){
      this.minValue = event.value;
    }
    else{
      this.minValue = {} as Date;
    }
  }

  handleDateToOnChange(event: MatDatepickerInputEvent<Date>) {
    if (event.value){
      this.maxValue = event.value;
    }
    else{
      this.maxValue = {} as Date;
    }
  }
}
