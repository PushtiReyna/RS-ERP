using BusinessLayer;
using DTO.ReqDTO;
using DTO.ResDTO;
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

        public async Task<CommonResponse> GetAttendanceTypeList() => await _attendanceBLL.GetAttendanceTypeList();
        public async Task<CommonResponse> AddAttendance(AddAttendanceReqDTO addAttendanceReqDTO) => await _attendanceBLL.AddAttendance(addAttendanceReqDTO);
        public async Task<CommonResponse> GetAttendanceListByMonth(GetAttendanceListByMonthReqDTO getAttendanceListByMonthReqDTO) => await _attendanceBLL.GetAttendanceListByMonth(getAttendanceListByMonthReqDTO);
        public async Task<CommonResponse> UpdateAttendance(UpdateAttendanceReqDTO updateAttendanceReqDTO) => await _attendanceBLL.UpdateAttendance(updateAttendanceReqDTO);
    }

    public interface IAttendance
    {
        public Task<CommonResponse> GetAttendanceTypeList();
        public Task<CommonResponse> AddAttendance(AddAttendanceReqDTO addAttendanceReqDTO);
        public Task<CommonResponse> GetAttendanceListByMonth(GetAttendanceListByMonthReqDTO getAttendanceListByMonthReqDTO);
        public Task<CommonResponse> UpdateAttendance(UpdateAttendanceReqDTO updateAttendanceReqDTO);
    }
}
