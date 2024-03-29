import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, empty } from 'rxjs';
import { PaginnationPageResponseDto } from '../../../interface/PaginnationPageResponseDto';
import { ReportDto } from '../../../interface/ReportDto';
import { Common } from '../../common/common';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  private readonly controlerName = 'reports';

  constructor(private readonly http: HttpClient) { }

  public getPremises(PageIndex: number, PageSize: number, DateFrom?: Date, DateTo?: Date, PremisesId?: number): Observable<PaginnationPageResponseDto<ReportDto>> {
    var params = new HttpParams().set('PageIndex', PageIndex).set('PageSize', PageSize);
    console.log(PremisesId);
    if (DateTo){
      var date: string = new Date(DateTo.getTime() - (DateTo.getTimezoneOffset() * 60000)).toISOString()
      params = params.append('DateTo', date);
    }

    if (DateFrom){
      var date: string = new Date(DateFrom.getTime() - (DateFrom.getTimezoneOffset() * 60000)).toISOString()
      params = params.append('DateFrom', date);
    }

    if (PremisesId){
      params = params.append('PremisesId', PremisesId!);
    }

    return this.http.get<PaginnationPageResponseDto<ReportDto>>(Common.getUrl(this.controlerName, ''), {params: params})
  }
}
