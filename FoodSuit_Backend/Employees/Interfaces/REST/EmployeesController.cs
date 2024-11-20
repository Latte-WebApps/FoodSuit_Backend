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
[Route("api/v1/employees")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Employees Endpoints.")]
public class EmployeesController(
    IEmployeeCommandService employeeCommandService,
    IEmployeeQueryService employeeQueryService) : ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Get All Employees", "Get a list of all employees.", OperationId = "GetAllEmployees")]
    [SwaggerResponse(200, "The list of Employees was found and returned.", typeof(IEnumerable<EmployeeResource>))]
    public async Task<IActionResult> GetAllEmployees()
    {
        var getAllEmployeesQuery = new GetAllEmployeesQuery();
        var employees = await employeeQueryService.Handle(getAllEmployeesQuery);

        if (employees == null || !employees.Any())
        {
            return NotFound("No employees found.");
        }

        var employeeResources = employees.Select(EmployeeResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(employeeResources);
    }
    
    [HttpGet("{employeesId:int}")]
    [SwaggerOperation("Get Employee by Id", "Get a profile by its unique identifier.", OperationId = "GetEmployeeById")]
    [SwaggerResponse(200, "The Employee was found and returned.", typeof(EmployeeResource))]
    [SwaggerResponse(404, "The Employee was not found.")]
    public async Task<IActionResult> GetEmployeeById(int employeesId)
    {
        var getEmployeeByIdQuery = new GetEmployeeByIdQuery(employeesId);
        var employee = await employeeQueryService.Handle(getEmployeeByIdQuery);
        if (employee is null) return NotFound();
        var employeeResource = EmployeeResourceFromEntityAssembler.ToResourceFromEntity(employee);
        return Ok(employeeResource);
    }

    [HttpPost]
    [SwaggerOperation("Create Employee", "Create a new Employee.", OperationId = "CreateEmployee")]
    [SwaggerResponse(201, "The Employee was created successfully.", typeof(EmployeeResource))]
    [SwaggerResponse(400, "The Employee was not created.")]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeResource resource)
    {
        var createEmployeeCommand = CreateEmployeeCommandFromResourceAssembler.ToCommandFromResource(resource);
        var employee = await employeeCommandService.Handle(createEmployeeCommand);
        if (employee is null) return BadRequest();
        var employeeResource = EmployeeResourceFromEntityAssembler.ToResourceFromEntity(employee);
        return CreatedAtAction(nameof(GetEmployeeById), new { employeesId = employee.Id }, employeeResource);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation("Update Employee Information", "Update Employee Information", OperationId = "UpdateEmployee")]
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
    [SwaggerOperation("Delete Employee Information", "Delete Employee Information", OperationId = "DeleteEmployee")]
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
