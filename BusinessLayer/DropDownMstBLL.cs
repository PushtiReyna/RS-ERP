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
        public DropDownMstBLL(DBContext dbContext, CommonRepo commonRepo)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
        }
        public async Task<CommonResponse> AddEmployeeType(EmployeeTypeReqDTO employeeTypeReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                EmployeeTypeMst employeeTypeMst = new EmployeeTypeMst();
                EmployeeTypeResDTO employeeTypeResDTO = new EmployeeTypeResDTO();

                //var employeeTypeDetail = _dbContext.EmployeeTypeMsts.FirstOrDefault(x => x.EmployeeType.Trim() == employeeTypeReqDTO.EmployeeType.Trim());
                var employeeTypeDetail = await _commonRepo.EmployeeTypeMstList().FirstOrDefaultAsync(x => x.EmployeeType.Trim() == employeeTypeReqDTO.EmployeeType.Trim());
                if (!string.IsNullOrWhiteSpace(employeeTypeReqDTO.EmployeeType))
                {
                    if (employeeTypeDetail == null)
                    {
                        employeeTypeMst.EmployeeType = employeeTypeReqDTO.EmployeeType.Trim();
                        employeeTypeMst.CreatedDate = DateTime.Now;
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
                var designationDetail = await _commonRepo.DesignationMstList().FirstOrDefaultAsync(x => x.DesignationName.Trim() == designationReqDTO.DesignationName.Trim());
                if (!string.IsNullOrWhiteSpace(designationReqDTO.DesignationName))
                {
                    if (designationDetail == null)
                    {
                        designationMst.DesignationName = designationReqDTO.DesignationName.Trim();
                        designationMst.CreatedDate = DateTime.Now;
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

                var departmentDetail = await _commonRepo.DepartmentMstList().FirstOrDefaultAsync(x => x.DepartmentName.Trim() == departmentReqDTO.DepartmentName.Trim());

                if (!string.IsNullOrWhiteSpace(departmentReqDTO.DepartmentName))
                {
                    if (departmentDetail == null)
                    {
                        departmentMst.DepartmentName = departmentReqDTO.DepartmentName.Trim();
                        departmentMst.CreatedDate = DateTime.Now;
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

                var roleDetail = await _commonRepo.RoleMstList().FirstOrDefaultAsync(x => x.RoleType.Trim() == roleReqDTO.RoleType.Trim());

                if (!string.IsNullOrWhiteSpace(roleReqDTO.RoleType))
                {
                    if (roleDetail == null)
                    {
                        roleMst.RoleType = roleReqDTO.RoleType.Trim();
                        roleMst.CreatedDate = DateTime.Now;
                        roleMst.CreatedBy = 1;
                        roleMst.IsActive = true;
                        roleMst.IsDelete = false;
                        _dbContext.RoleMsts.Add(roleMst);
                        _dbContext.SaveChanges();

                        roleResDTO.RoleId = roleMst.RoleId;
                        roleResDTO.RoleType = roleMst.RoleType;
                        response.Data = roleResDTO;
                        response.Status = true;
                        response.Message = "Role Type add successfully";
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

                var reportingManagerDetail = await _commonRepo.ReportingManagerMstsList().FirstOrDefaultAsync(x => x.ReportingManagerName.Trim() == reportingManagerReqDTO.ReportingManagerName.Trim());

                if (!string.IsNullOrWhiteSpace(reportingManagerReqDTO.ReportingManagerName))
                {
                    if (reportingManagerDetail == null)
                    {
                        reportingManager.ReportingManagerName = reportingManagerReqDTO.ReportingManagerName.Trim();
                        reportingManager.CreatedDate = DateTime.Now;
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

                var attritionDetail = await _commonRepo.AttritionTypeMstsList().FirstOrDefaultAsync(x => x.AttritionTypeName.Trim() == attritionTypeReqDTO.AttritionTypeName.Trim());

                if (!string.IsNullOrWhiteSpace(attritionTypeReqDTO.AttritionTypeName))
                {
                    if (attritionDetail == null)
                    {
                        attritionType.AttritionTypeName = attritionTypeReqDTO.AttritionTypeName.Trim();
                        attritionType.CreatedDate = DateTime.Now;
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

                var leaveStatusDetail = await _commonRepo.LeaveStatusMstsList().FirstOrDefaultAsync(x => x.LeaveStatusName.Trim() == leaveStatusReqDTO.LeaveStatusName.Trim());

                if (!string.IsNullOrWhiteSpace(leaveStatusReqDTO.LeaveStatusName))
                {
                    if (leaveStatusDetail == null)
                    {
                        leaveStatusMst.LeaveStatusName = leaveStatusReqDTO.LeaveStatusName.Trim();
                        _dbContext.LeaveStatusMsts.Add(leaveStatusMst);
                        _dbContext.SaveChanges();

                        leaveStatusResDTO.LeaveStatusId = leaveStatusMst.LeaveStatusId;
                        response.Data = leaveStatusResDTO;
                        response.Status = true;
                        response.Message = "leave Status add successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "leave Status  Name already exists";
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
