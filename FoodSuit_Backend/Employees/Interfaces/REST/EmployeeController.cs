using System.Net.Mime;
using FoodSuit_Backend.Employees.Domain.Model.Commands;
using FoodSuit_Backend.Employees.Domain.Model.Queries;
using FoodSuit_Backend.Employees.Domain.Services;
using FoodSuit_Backend.Employees.Interfaces.REST.Resources;
using FoodSuit_Backend.Employees.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


namespace FoodSuit_Backend.Employees.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Employee Endpoints.")]

public class EmployeeController(
    IEmployeeCommandService employeeCommandService,
    IEmployeeQueryService employeeQueryService) : ControllerBase
{
    [HttpGet("{employeeId:int}")]
    [SwaggerOperation("Get Employee by Id", "Get a profile by its unique identifier.", OperationId = "GetEmployeeById")]
    [SwaggerResponse(200, "The Employee was found and returned.", typeof(EmployeeResource))]
    [SwaggerResponse(404, "The Employee was not found.")]

    public async Task<IActionResult> GetEmployeeById(int employeeId)
    {
        var getEmployeeByIdQuery = new GetEmployeeByIdQuery(employeeId);
        var employee = await employeeQueryService.Handle(getEmployeeByIdQuery);
        if (employee is null) return NotFound();
        var employeeResource = EmployeeResourceFromEntityAssembler.ToResourceFromEntity(employee);
        return Ok(employeeResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Employee", "Create a new Employee.", OperationId = "CreateEmployee")]
    [SwaggerResponse(200, "The Employee was found and returned.", typeof(EmployeeResource))]
    [SwaggerResponse(404, "The Employee was not found.")]

    public async Task<IActionResult> CreateEmployee(CreateEmployeeResource resource)
    {
        var createEmployeeCommand = CreateEmployeeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var employee = await employeeCommandService.Handle(createEmployeeCommand);
        if (employee is null) return BadRequest();
        var employeeResource = EmployeeResourceFromEntityAssembler.ToResourceFromEntity(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { profileId = employee.Id }, employeeResource);
    }
}