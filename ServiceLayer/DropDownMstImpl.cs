﻿using BusinessLayer;
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
    }

    public interface IDropDownMst
    {
        public Task<CommonResponse> AddEmployeeType(EmployeeTypeReqDTO employeeTypeReqDTO);
        public Task<CommonResponse> AddDepartment(DepartmentReqDTO departmentReqDTO);
        public Task<CommonResponse> AddDesignation(DesignationReqDTO designationReqDTO);
        public Task<CommonResponse> AddRoleType(RoleReqDTO roleReqDTO);
    }
}