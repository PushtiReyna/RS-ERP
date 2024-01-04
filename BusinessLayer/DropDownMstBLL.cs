using Azure.Core;
using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.CommonHelpers;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DropDownMstBLL
    {
        private readonly DBContext _dbContext;
        private readonly CommonRepo _commonRepo;
        private readonly CommonHelper _commonHelper;

        public DropDownMstBLL(DBContext dbContext, CommonRepo commonRepo, CommonHelper commonHelper)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
            _commonHelper = commonHelper;
        }
        public async Task<CommonResponse> AddEmployeeType(EmployeeTypeReqDTO employeeTypeReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                EmployeeTypeMst employeeTypeMst = new EmployeeTypeMst();
                EmployeeTypeResDTO employeeTypeResDTO = new EmployeeTypeResDTO();

                //var employeeTypeDetail = _dbContext.EmployeeTypeMsts.FirstOrDefault(x => x.EmployeeType.Trim() == employeeTypeReqDTO.EmployeeType.Trim());
                bool isExist = await _commonRepo.EmployeeTypeMstList().AnyAsync(x => x.EmployeeType.Trim().ToLower() == employeeTypeReqDTO.EmployeeType.Trim().ToLower());

                if (employeeTypeReqDTO.EmployeeType.Trim() != null && !string.IsNullOrWhiteSpace(employeeTypeReqDTO.EmployeeType.Trim()))
                {
                    if (isExist == false)
                    {
                        employeeTypeMst.EmployeeType = employeeTypeReqDTO.EmployeeType.Trim();
                        employeeTypeMst.CreatedDate = _commonHelper.GetCurrentDateTime();
                        employeeTypeMst.CreatedBy = 1;
                        employeeTypeMst.IsActive = true;
                        employeeTypeMst.IsDelete = false;
                        _dbContext.EmployeeTypeMsts.Add(employeeTypeMst);
                        _dbContext.SaveChanges();

                        employeeTypeResDTO.EmployeeTypeId = employeeTypeMst.EmployeeTypeId;
                        employeeTypeResDTO.EmployeeType = employeeTypeMst.EmployeeType;
                        response.Data = employeeTypeResDTO;
                        response.Status = true;
                        response.Message = "EmployeeType add successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "EmployeeType  already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> AddDesignation(DesignationReqDTO designationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                DesignationMst designationMst = new DesignationMst();
                DesignationResDTO designationResDTO = new DesignationResDTO();

                // var designationDetail = _dbContext.DesignationMsts.FirstOrDefault(x => x.DesignationName.Trim() == designationReqDTO.DesignationName.Trim());

                bool isExist = await _commonRepo.DesignationMstList().AnyAsync(x => x.DesignationName.Trim().ToLower() == designationReqDTO.DesignationName.Trim().ToLower());
                if (designationReqDTO.DesignationName.Trim() != null && !string.IsNullOrWhiteSpace(designationReqDTO.DesignationName.Trim()))
                {
                    if (isExist == false)
                    {
                        designationMst.DesignationName = designationReqDTO.DesignationName.Trim();
                        designationMst.CreatedDate = _commonHelper.GetCurrentDateTime();
                        designationMst.CreatedBy = 1;
                        designationMst.IsActive = true;
                        designationMst.IsDelete = false;
                        _dbContext.DesignationMsts.Add(designationMst);
                        _dbContext.SaveChanges();

                        designationResDTO.DesignationId = designationMst.DesignationId;
                        designationResDTO.DesignationName = designationMst.DesignationName;
                        response.Data = designationResDTO;
                        response.Status = true;
                        response.Message = "Designation add successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Designation name already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> AddDepartment(DepartmentReqDTO departmentReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                DepartmentMst departmentMst = new DepartmentMst();
                DepartmentResDTO departmentResDTO = new DepartmentResDTO();

                bool isExist = await _commonRepo.DepartmentMstList().AnyAsync(x => x.DepartmentName.Trim().ToLower() == departmentReqDTO.DepartmentName.Trim().ToLower());

                if (departmentReqDTO.DepartmentName.Trim() != null && !string.IsNullOrWhiteSpace(departmentReqDTO.DepartmentName.Trim()))
                {
                    if (isExist == false)
                    {
                        departmentMst.DepartmentName = departmentReqDTO.DepartmentName.Trim();
                        departmentMst.CreatedDate = _commonHelper.GetCurrentDateTime();
                        departmentMst.CreatedBy = 1;
                        departmentMst.IsActive = true;
                        departmentMst.IsDelete = false;
                        _dbContext.DepartmentMsts.Add(departmentMst);
                        _dbContext.SaveChanges();

                        departmentResDTO.DepartmentId = departmentMst.DepartmentId;
                        departmentResDTO.DepartmentName = departmentMst.DepartmentName;
                        response.Data = departmentResDTO;
                        response.Status = true;
                        response.Message = "department add successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "department name already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> AddRoleType(RoleReqDTO roleReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                RoleMst roleMst = new RoleMst();
                RoleResDTO roleResDTO = new RoleResDTO();

                bool isExist = await _commonRepo.RoleMstList().AnyAsync(x => x.RoleType.Trim().ToLower() == roleReqDTO.RoleType.Trim().ToLower());

                if (roleReqDTO.RoleType.Trim() != null && !string.IsNullOrWhiteSpace(roleReqDTO.RoleType.Trim()))
                {
                    if (isExist == false)
                    {
                        roleMst.RoleType = roleReqDTO.RoleType.Trim();
                        roleMst.CreatedDate = _commonHelper.GetCurrentDateTime(); 
                        roleMst.CreatedBy = 1;
                        roleMst.IsActive = true;
                        roleMst.IsDelete = false;
                        _dbContext.RoleMsts.Add(roleMst);
                        _dbContext.SaveChanges();

                        roleResDTO.RoleId = roleMst.RoleId;
                        roleResDTO.RoleType = roleMst.RoleType;
                        response.Data = roleResDTO;
                        response.Status = true;
                        response.Message = "Role Type add successfully!";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Role Type already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> AddReportingManager(ReportingManagerReqDTO reportingManagerReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                ReportingManagerMst reportingManager = new ReportingManagerMst();
                ReportingManagerResDTO reportingManagerResDTO = new ReportingManagerResDTO();

                bool isExist = await _commonRepo.ReportingManagerMstsList().AnyAsync(x => x.ReportingManagerName.Trim().ToLower() == reportingManagerReqDTO.ReportingManagerName.Trim().ToLower());

                if (reportingManagerReqDTO.ReportingManagerName.Trim() != null && !string.IsNullOrWhiteSpace(reportingManagerReqDTO.ReportingManagerName.Trim()))
                {
                    if (isExist == false)
                    {
                        reportingManager.ReportingManagerName = reportingManagerReqDTO.ReportingManagerName.Trim();
                        reportingManager.CreatedDate = _commonHelper.GetCurrentDateTime();
                        reportingManager.CreatedBy = 1;
                        reportingManager.IsActive = true;
                        reportingManager.IsDelete = false;
                        _dbContext.ReportingManagerMsts.Add(reportingManager);
                        _dbContext.SaveChanges();

                        reportingManagerResDTO.ReportingManagerId = reportingManager.ReportingManagerId;
                        reportingManagerResDTO.ReportingManagerName = reportingManager.ReportingManagerName;
                        response.Data = reportingManagerResDTO;
                        response.Status = true;
                        response.Message = "Reprting Manager add successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Reprting Manager Name already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> AddAttritionType(AttritionTypeReqDTO attritionTypeReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AttritionTypeMst attritionType = new AttritionTypeMst();
                AttritionTypeResDTO attritionTypeResDTO = new AttritionTypeResDTO();

                bool isExist = await _commonRepo.AttritionTypeMstsList().AnyAsync(x => x.AttritionTypeName.Trim().ToLower() == attritionTypeReqDTO.AttritionTypeName.Trim().ToLower());

                if (attritionTypeReqDTO.AttritionTypeName.Trim() != null && !string.IsNullOrWhiteSpace(attritionTypeReqDTO.AttritionTypeName.Trim()))
                {
                    if (isExist == false)
                    {
                        attritionType.AttritionTypeName = attritionTypeReqDTO.AttritionTypeName.Trim();
                        attritionType.CreatedDate = _commonHelper.GetCurrentDateTime();
                        attritionType.CreatedBy = 1;
                        attritionType.IsActive = true;
                        attritionType.IsDelete = false;
                        _dbContext.AttritionTypeMsts.Add(attritionType);
                        _dbContext.SaveChanges();

                        attritionTypeResDTO.AttritionTypeId = attritionType.AttritionTypeId;
                        attritionTypeResDTO.AttritionTypeName = attritionType.AttritionTypeName;
                        response.Data = attritionTypeResDTO;
                        response.Status = true;
                        response.Message = "Attrition Type add successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Attrition Type  Name already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> AddLeaveStatus(LeaveStatusReqDTO leaveStatusReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                LeaveStatusMst leaveStatusMst  = new LeaveStatusMst();
                LeaveStatusResDTO leaveStatusResDTO  = new LeaveStatusResDTO();

                bool isExist = await _commonRepo.LeaveStatusMstsList().AnyAsync(x => x.LeaveStatusName.Trim().ToLower() == leaveStatusReqDTO.LeaveStatusName.Trim().ToLower());

                if (leaveStatusReqDTO.LeaveStatusName.Trim() != null && !string.IsNullOrWhiteSpace(leaveStatusReqDTO.LeaveStatusName.Trim()))
                {
                    if (isExist == false)
                    {
                        leaveStatusMst.LeaveStatusName = leaveStatusReqDTO.LeaveStatusName.Trim();
                        _dbContext.LeaveStatusMsts.Add(leaveStatusMst);
                        _dbContext.SaveChanges();

                        leaveStatusResDTO.LeaveStatusId = leaveStatusMst.LeaveStatusId;
                        response.Data = leaveStatusResDTO;
                        response.Status = true;
                        response.Message = "leave Status add successfully!";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "leave Status Name already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> AddAttendanceType(AttendanceTypeReqDTO attendanceTypeReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AttendanceTypeMst attendanceTypeMst = new AttendanceTypeMst();
                AttendanceTypeResDTO attendanceTypeResDTO = new AttendanceTypeResDTO();

                bool isExist = await _commonRepo.AttendanceTypeMstsList().AnyAsync(x => x.AttendanceTypeName.Trim().ToLower() == attendanceTypeReqDTO.AttendanceTypeName.Trim().ToLower());

                if (attendanceTypeReqDTO.AttendanceTypeName.Trim() != null && !string.IsNullOrWhiteSpace(attendanceTypeReqDTO.AttendanceTypeName.Trim()))
                {
                    if (isExist == false)
                    {
                        attendanceTypeMst.AttendanceTypeName = attendanceTypeReqDTO.AttendanceTypeName.Trim();
                        _dbContext.AttendanceTypeMsts.Add(attendanceTypeMst);
                        _dbContext.SaveChanges();

                        attendanceTypeResDTO.AttendanceTypeId = attendanceTypeMst.AttendanceTypeId;
                        response.Data = attendanceTypeResDTO;
                        response.Status = true;
                        response.Message = "Attendance type add successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Attendance type Name already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "data can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
