using ReportInfrastructure.Dtos;
using ReportInfrastructure.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportInfrastructure.Services.Interfaces;
public interface IReportService
{
    Task<PaginnationPageResponseDto<ReportDto>> GetReportsAsync(ReportQuery query);
}
