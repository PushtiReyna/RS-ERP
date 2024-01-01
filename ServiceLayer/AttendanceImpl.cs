using BusinessLayer;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AttendanceImpl : IAttendance
    {
        private readonly AttendanceBLL _attendanceBLL;
        public AttendanceImpl(AttendanceBLL attendanceBLL)
        {
            _attendanceBLL = attendanceBLL;
        }

        public async Task<CommonResponse> GetAttendanceList() => await _attendanceBLL.GetAttendanceList();
    }

    public interface IAttendance
    {
        public Task<CommonResponse> GetAttendanceList();
    }
}
