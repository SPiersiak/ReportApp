import { PremiseService } from '../infrastructure/service/premise.service';
import { PremiseDto } from '../interface/PremiseDto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-report',
  standalone: true,
  imports: [],
  templateUrl: './report.component.html',
  styleUrl: './report.component.css'
})
export class ReportComponent implements OnInit {
  public premiseResult: PremiseDto[] = [] as PremiseDto[]

  public constructor(
    private premiseService: PremiseService
  ){  }

  ngOnInit(): void {
  }

}
