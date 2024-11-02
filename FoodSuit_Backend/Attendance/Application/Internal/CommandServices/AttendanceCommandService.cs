using FoodSuit_Backend.Attendance.Domain.Services;
using FoodSuit_Backend.Attendance.Domain.Model.Aggregates;
using FoodSuit_Backend.Attendance.Domain.Model.Commands;
using FoodSuit_Backend.Attendance.Domain.Repositories;
using FoodSuit_Backend.Shared.Domain.Repositories;
using FoodSuit_Backend.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace FoodSuit_Backend.Attendance.Application.Internal.CommandServices;

public class AttendanceCommandService(IAttendanceRepository attendanceRepository, IUnitOfWork unitOfWork) 
    : IAttendanceCommandService
{
    public async Task<EmployeeAttendance?> Handle(RegisterAttendanceCommand command)
    {
        var attendance = new EmployeeAttendance(command);

        try
        {
            await attendanceRepository.AddAsync(attendance);
            await unitOfWork.CompleteAsync();
            return attendance;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<EmployeeAttendance?> Handle(int id, UpdateCheckOutCommand command)
    {
        var attendance = await attendanceRepository.GetByIdAsync(id);

        if (attendance == null)
        {
            return null;
        }

        attendance.UpdateCheckOutTime(command.CheckOutTime);

        try
        {
            await unitOfWork.UpdateAsync(attendance);
            await unitOfWork.CompleteAsync();
            return attendance;
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating attendance", ex);
        }
    }

    public async Task<bool> Handle(DeleteAttendanceCommand command)
    {
        var attendance = await attendanceRepository.GetByIdAsync(command.AttendanceId);

        if (attendance == null)
        {
            return false;
        }

        try
        {
            await unitOfWork.RemoveAsync(attendance);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
