export interface PaginnationPageResponseDto<T> {
  pageIndex: number;
  pageSize: number;
  totalRecords: number;
  dataCollection: T[];
}
