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

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeResource resource)
    {
        if (id <= 0 || resource is null) 
            return BadRequest("Invalid Employee ID");

        try
        {
            var updateEmployeeCommand = UpdateEmployeeCommandFromResourceAssembler.ToCommandFromResource(resource);
            var employee = await employeeCommandService.Handle(id, updateEmployeeCommand);
            if (employee == null)
                return NotFound($"Employee not found: {id}");

            var employeeResource = EmployeeResourceFromEntityAssembler.ToResourceFromEntity(employee);
            return Ok(employeeResource);
        }
        
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            var deleteEmployeeCommand = new DeleteEmployeeCommand(id);
            var employeeDeleted = await employeeCommandService.Handle(deleteEmployeeCommand);
            
            if (employeeDeleted is null)
                return NotFound($"Employee with id {id} not found.");

            return Ok("Employee deleted successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}