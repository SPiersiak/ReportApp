import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PremiseDto } from '../../interface/PremiseDto';
import { Common } from '../common/common';

@Injectable({
  providedIn: 'root'
})
export class PremiseService {

  private readonly controlerName = 'premises';

  constructor(private readonly http: HttpClient) { }

  public getPremises(): Observable<PremiseDto[]> {
    return this.http.get<PremiseDto[]>(Common.getUrl(this.controlerName, ''))
  }
}
