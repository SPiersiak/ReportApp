using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ReportApi.Controllers;
using ReportInfrastructure.Dtos;
using ReportInfrastructure.Query;
using ReportInfrastructure.Services.Interfaces;

namespace ReportApiTest;

public class ReportControllerTest
{
    [Fact]
    public async Task GetReports_WhenSuccess_ReturnCode200()
    {
        var mockReportService = new Mock<IReportService>();
        var controller = new ReportsController(mockReportService.Object);

        var result = (OkObjectResult)await controller.GetReports(It.IsAny<ReportQuery>());

        result.StatusCode.Should().Be(200);
        result.Should().BeOfType<OkObjectResult>();
    }

    [Fact]
    public async Task GetReports_WhenSuccess_ReturnReportListWithPagginationRespone()
    {
        var mockReportService = new Mock<IReportService>();
        mockReportService
            .Setup(service => service.GetReportsAsync(It.IsAny<ReportQuery>()))
            .ReturnsAsync(new PaginnationPageResponseDto<ReportDto>());
        var controller = new ReportsController(mockReportService.Object);

        var result = (OkObjectResult)await controller.GetReports(It.IsAny<ReportQuery>());

        result.StatusCode.Should().Be(200);
        result.Should().BeOfType<OkObjectResult>();
        result.Value.Should().NotBeNull();
        result.Value.Should().BeOfType<PaginnationPageResponseDto<ReportDto>>();
    }
}