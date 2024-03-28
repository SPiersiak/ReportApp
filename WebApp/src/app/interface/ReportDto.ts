import { Time } from "@angular/common";

export interface ReportDto {
  reportName: string;
  reportDate: Date,
  reportTime: Time;
  userName: string;
  premiseName: string;
}
