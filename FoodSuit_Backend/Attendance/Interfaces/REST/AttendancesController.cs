﻿using System.Net.Mime;
using FoodSuit_Backend.Attendance.Domain.Model.Commands;
using FoodSuit_Backend.Attendance.Domain.Model.Queries;
using FoodSuit_Backend.Attendance.Domain.Services;
using FoodSuit_Backend.Attendance.Interfaces.REST.Resources;
using FoodSuit_Backend.Attendance.Interfaces.REST.Transform;

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FoodSuit_Backend.Attendance.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Attendance Endpoints.")]

public class AttendancesController(
    IAttendanceCommandService attendanceCommandService,
    IAttendanceQueryService attendanceQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Register an attendance", "Register a new attendance entry.", OperationId = "RegisterAttendance")]
    [SwaggerResponse(201, "The Attendance was registered successfully.", typeof(AttendanceResource))]
    [SwaggerResponse(400, "The Attendance registration failed.")]
    public async Task<IActionResult> RegisterAttendance(RegisterAttendanceResource resource)
    {
        if (resource == null) return BadRequest("Resource cannot be null.");

        var registerAttendanceCommand = RegisterAttendanceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var attendance = await attendanceCommandService.Handle(registerAttendanceCommand);
        if (attendance is null) return BadRequest("Failed to create attendance.");

        var attendanceResource = AttendanceResourceFromEntityAssembler.ToResourceFromEntity(attendance);
        return CreatedAtAction(nameof(GetAttendanceByEmployeeId), new { employeeId = attendance.EmployeeId }, attendanceResource);
    }

    [HttpGet("{employeeId:int}")]
    [SwaggerOperation("Get Attendance by Employee Id", "Get attendance records by employee's unique identifier.", OperationId = "GetAttendanceByEmployeeId")]
    [SwaggerResponse(200, "The Attendance records were found and returned.", typeof(IEnumerable<AttendanceResource>))]
    [SwaggerResponse(404, "No Attendance records were found for the employee.")]
    public async Task<IActionResult> GetAttendanceByEmployeeId(int employeeId)
    {
        var getAttendanceByEmployeeIdQuery = new GetAttendanceByEmployeeIdQuery(employeeId);
        var attendances = await attendanceQueryService.Handle(getAttendanceByEmployeeIdQuery);

        if (attendances == null || !attendances.Any()) return NotFound("No attendance records found for the employee.");

        var attendanceResources = attendances.Select(AttendanceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(attendanceResources);
    }

    [HttpGet]
    [SwaggerOperation("Get All Attendances", "Retrieve all attendance records.", OperationId = "GetAllAttendances")]
    [SwaggerResponse(200, "Attendance records retrieved successfully.", typeof(IEnumerable<AttendanceResource>))]
    public async Task<IActionResult> GetAllAttendances()
    {
        var getAllAttendancesQuery = new GetAllAttendancesQuery();
        var attendances = await attendanceQueryService.Handle(getAllAttendancesQuery);
        var attendanceResources = attendances.Select(AttendanceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(attendanceResources);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation("Update an attendance by ID", "Update the check-out time for an attendance entry.", OperationId = "UpdateCheckOut")]
    [SwaggerResponse(200, "The check-out time was updated successfully.", typeof(AttendanceResource))]
    [SwaggerResponse(404, "The Attendance entry was not found.")]
    public async Task<IActionResult> UpdateCheckOut(int id, UpdateCheckOutResource resource)
    {
        if (resource == null) return BadRequest("Resource cannot be null.");

        var updateCheckOutCommand = UpdateCheckOutCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var attendance = await attendanceCommandService.Handle(id, updateCheckOutCommand);
        if (attendance == null) return NotFound("Attendance entry not found.");

        var attendanceResource = AttendanceResourceFromEntityAssembler.ToResourceFromEntity(attendance);
        return Ok(attendanceResource);
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation("Delete an attendance by ID", "Delete an attendance entry by its ID.", OperationId = "DeleteAttendance")]
    [SwaggerResponse(204, "The Attendance entry was deleted successfully.")]
    [SwaggerResponse(404, "The Attendance entry was not found.")]
    public async Task<IActionResult> DeleteAttendance(int id)
    {
        var deleteAttendanceCommand = new DeleteAttendanceCommand(id);
        var deleted = await attendanceCommandService.Handle(deleteAttendanceCommand);
        if (!deleted) return NotFound($"Attendance entry with ID {id} not found.");
        return Ok("Attendance entry deleted successfully.");
    }
}