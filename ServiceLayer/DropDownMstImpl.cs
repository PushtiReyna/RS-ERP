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
    public class DropDownMstImpl : IDropDownMst
    {
        private readonly DropDownMstBLL _dropDownMstBLL;

        public DropDownMstImpl(DropDownMstBLL dropDownMstBLL)
        {
            _dropDownMstBLL = dropDownMstBLL;
        }
        public async Task<CommonResponse> AddEmployeeType(EmployeeTypeReqDTO employeeTypeReqDTO) => await _dropDownMstBLL.AddEmployeeType(employeeTypeReqDTO);
        public async Task<CommonResponse> AddDepartment(DepartmentReqDTO departmentReqDTO) => await _dropDownMstBLL.AddDepartment(departmentReqDTO);
        public async Task<CommonResponse> AddDesignation(DesignationReqDTO designationReqDTO) => await _dropDownMstBLL.AddDesignation(designationReqDTO);
        public async Task<CommonResponse> AddRoleType(RoleReqDTO roleReqDTO) => await _dropDownMstBLL.AddRoleType(roleReqDTO);    
        public async Task<CommonResponse> AddReportingManager(ReportingManagerReqDTO reportingManagerReqDTO) => await _dropDownMstBLL.AddReportingManager(reportingManagerReqDTO);
        public async Task<CommonResponse> AddAttritionType(AttritionTypeReqDTO attritionTypeReqDTO) => await _dropDownMstBLL.AddAttritionType(attritionTypeReqDTO);
        public async Task<CommonResponse> AddLeaveStatus(LeaveStatusReqDTO leaveStatusReqDTO) => await _dropDownMstBLL.AddLeaveStatus(leaveStatusReqDTO);
        public async Task<CommonResponse> AddAttendanceType(AttendanceTypeReqDTO attendanceTypeReqDTO) => await _dropDownMstBLL.AddAttendanceType(attendanceTypeReqDTO);
    }

    public interface IDropDownMst
    {
        public Task<CommonResponse> AddEmployeeType(EmployeeTypeReqDTO employeeTypeReqDTO);
        public Task<CommonResponse> AddDepartment(DepartmentReqDTO departmentReqDTO);
        public Task<CommonResponse> AddDesignation(DesignationReqDTO designationReqDTO);
        public Task<CommonResponse> AddRoleType(RoleReqDTO roleReqDTO);
        public Task<CommonResponse> AddReportingManager(ReportingManagerReqDTO reportingManagerReqDTO);
        public Task<CommonResponse> AddAttritionType(AttritionTypeReqDTO attritionTypeReqDTO);
        public Task<CommonResponse> AddLeaveStatus(LeaveStatusReqDTO leaveStatusReqDTO);
        public Task<CommonResponse> AddAttendanceType(AttendanceTypeReqDTO attendanceTypeReqDTO); 
    }
}
