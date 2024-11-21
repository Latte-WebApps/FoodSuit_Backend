using System.Net.Mime;
using FoodSuit_Backend.Finance.Domain.Model.Queries;
using FoodSuit_Backend.Finance.Domain.Services;
using FoodSuit_Backend.Finance.Interfaces.REST.Resources;
using FoodSuit_Backend.Finance.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodSuit_Backend.Finance.Interfaces.REST;
/// <summary>
/// Controller for managing reports.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Report Endpoints.")]
public class ReportsController (
    IReportCommandService reportCommandService,
    IReportQueryService reportQueryService
    ) : ControllerBase
{
    /// <summary>
    /// Creates a new report.
    /// </summary>
    /// <param name="resource">The resource containing the report details.</param>
    /// <returns>A newly created report.</returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new report",
        Description = "Create a new report in the system",
        OperationId = "CreateReport")]
    [SwaggerResponse(201, "The report was created", typeof(ReportResource))]
    [SwaggerResponse(400, "The report was not created")]
    public async Task<IActionResult> CreateReport([FromBody] CreateReportResource resource)
    {
        var createReportCommand = CreateReportCommandFromResourceAssembler.ToCommandFromResource(resource);
        var report = await reportCommandService.Handle(createReportCommand);
        if (report is null) return BadRequest();

        var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
        return CreatedAtAction(nameof(GetReportById), new { reportId = report.Id }, reportResource);
    }

    /// <summary>
    /// Gets a report by its ID.
    /// </summary>
    /// <param name="reportId">The ID of the report to retrieve.</param>
    /// <returns>The report with the specified ID.</returns>
    [HttpGet("{reportId:int}")]
    [SwaggerOperation(
        Summary = "Get report by id",
        Description = "Get a report by its id",
        OperationId = "GetReportById")]
    [SwaggerResponse(200, "The report was found", typeof(ReportResource))]
    [SwaggerResponse(404, "The report was not found")]
    public async Task<IActionResult> GetReportById(int reportId)
    {
        var getReportByIdQuery = new GetReportByIdQuery(reportId);
        var report = await reportQueryService.Handle(getReportByIdQuery);
        if (report is null) return NotFound();

        var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
        return Ok(reportResource);
    }

    /// <summary>
    /// Gets all reports.
    /// </summary>
    /// <returns>A list of all reports.</returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all reports",
        Description = "Get all reports in the system",
        OperationId = "GetAllReports")]
    [SwaggerResponse(200, "The reports were found", typeof(IEnumerable<ReportResource>))]
    [SwaggerResponse(404, "The reports were not found")]
    public async Task<IActionResult> GetAllReports()
    {
        var getAllReportsQuery = new GetAllReportsQuery();
        var reports = await reportQueryService.Handle(getAllReportsQuery);
        var reportResources = reports.Select(ReportResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reportResources);
    }
}