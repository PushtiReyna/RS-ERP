using DTO.ReqDTO;
using DTO.ResDTO;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.CommonModels;
using WebApi.ViewModel.ReqViewModel;
using WebApi.ViewModel.ResViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownMstController : ControllerBase
    {
        private readonly IDropDownMst _iDropDownMst;

        public DropDownMstController(IDropDownMst idropDownMst)
        {
            _iDropDownMst = idropDownMst;
        }

        [HttpPost("AddEmployeeType")]
        public async Task<CommonResponse> AddEmployeeType(EmployeeTypeReqViewModel employeeTypeReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iDropDownMst.AddEmployeeType(employeeTypeReqViewModel.Adapt<EmployeeTypeReqDTO>());
                EmployeeTypeResDTO employeeTypeResDTO =  response.Data;
                response.Data = employeeTypeResDTO.Adapt<EmployeeTypeResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddDepartment")]
        public async Task<CommonResponse> AddDepartment(DepartmentReqViewModel departmentReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iDropDownMst.AddDepartment(departmentReqViewModel.Adapt<DepartmentReqDTO>());
                DepartmentResDTO departmentResDTO = response.Data;
                response.Data = departmentResDTO.Adapt<DepartmentResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddDesignation")]
        public async Task<CommonResponse>AddDesignation(DesignationReqViewModel designationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iDropDownMst.AddDesignation(designationReqViewModel.Adapt<DesignationReqDTO>());
                DesignationResDTO designationResDTO = response.Data;
                response.Data = designationResDTO.Adapt<DesignationResViewModel>();
            }
            catch { throw; }
            return response;
        }
        [HttpPost("AddRoleType")]
        public async Task<CommonResponse> AddRoleType(RoleReqViewModel roleReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iDropDownMst.AddRoleType(roleReqViewModel.Adapt<RoleReqDTO>());
                RoleResDTO roleResDTO  = response.Data;
                response.Data = roleResDTO.Adapt<RoleResViewModel>();
            }
            catch { throw; }
            return response;
        }
        [HttpPost("AddReportingManager")]
        public async Task<CommonResponse> AddReportingManager(ReportingManagerReqViewModel reportingManagerReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iDropDownMst.AddReportingManager(reportingManagerReqViewModel.Adapt<ReportingManagerReqDTO>());
                ReportingManagerResDTO reportingManagerResDTO = response.Data;
                response.Data = reportingManagerResDTO.Adapt<ReportingManagerResViewModel>();
            }
            catch { throw; }
            return response;
        }
        [HttpPost("AddAttretionType")]
        public async Task<CommonResponse> AddAttritionType(AttritionTypeReqViewModel attritionTypeReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iDropDownMst.AddAttritionType(attritionTypeReqViewModel.Adapt<AttritionTypeReqDTO>());
                AttritionTypeResDTO attritionTypeResDTO = response.Data;
                response.Data = attritionTypeResDTO.Adapt<AttritionTypeResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddLeaveStatus")]
        public async Task<CommonResponse> AddLeaveStatus(LeaveStatusReqViewModel leaveStatusReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iDropDownMst.AddLeaveStatus(leaveStatusReqViewModel.Adapt<LeaveStatusReqDTO>());
                LeaveStatusResDTO leaveStatusResDTO = response.Data;
                response.Data = leaveStatusResDTO.Adapt<LeaveStatusResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddAttendanceType")]
        public async Task<CommonResponse> AddAttendanceType(AttendanceTypeReqViewModel attendanceTypeReqView)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iDropDownMst.AddAttendanceType(attendanceTypeReqView.Adapt<AttendanceTypeReqDTO>());
                AttendanceTypeResDTO attendanceTypeResDTO = response.Data;
                response.Data = attendanceTypeResDTO.Adapt<AttendanceTypeResViewModel>();
            }
            catch { throw; }
            return response;
        }

    }
}
