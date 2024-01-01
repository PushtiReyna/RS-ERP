using BusinessLayer;
using ServiceLayer;
using ServiceLayer.CommonHelpers;

namespace WebApi
{
    public static class ServiceExtension
    {
        public static void DIScope(this IServiceCollection service)
        {
            service.AddScoped<CommonHelper>();

            service.AddScoped<CommonRepo>();
            service.AddScoped<AuthHelper>();

            service.AddScoped<IAuth, AuthImpl>();
            service.AddScoped<AuthBLL>();

            service.AddScoped<IDropDownMst, DropDownMstImpl>();
            service.AddScoped<DropDownMstBLL>();

            service.AddScoped<IEmployee, EmployeeImpl>();
            service.AddScoped<EmployeeBLL>();

            service.AddScoped<IHoliday, HolidayImpl>();
            service.AddScoped<HolidayBLL>();

            service.AddScoped<ILeave, LeaveImpl>();
            service.AddScoped<LeaveBLL>();

            service.AddScoped<IAttendance, AttendanceImpl>();
            service.AddScoped<AttendanceBLL>();

        }
    }
}
