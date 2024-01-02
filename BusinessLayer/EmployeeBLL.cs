using Azure;
using Azure.Core;
using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Mapster;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.CommonHelpers;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DTO.ResDTO.GetEmployeeResDTO;

namespace BusinessLayer
{
    public class EmployeeBLL
    {
        private readonly DBContext _dbContext;
        private readonly CommonRepo _commonRepo;
        public readonly IHostingEnvironment _hostEnvironment;
        public EmployeeBLL(DBContext dbContext, CommonRepo commonRepo, IHostingEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<CommonResponse> GetEmployee(GetEmployeeReqDTO getEmployeeReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                GetEmployeeResDTO getEmployeeResDTO = new GetEmployeeResDTO();

                List<EmployeeeList> lstEmployeeeList = new List<EmployeeeList>();
                lstEmployeeeList = (from employeeDetail in _commonRepo.EmployeeMstList().Where(x => x.EmployeeStatus == true)
                                    join roleDetail in _commonRepo.RoleMstList()
                                           on employeeDetail.RoleId equals roleDetail.RoleId
                                    select new EmployeeeList
                                    {
                                        EmployeeId = employeeDetail.EmployeeId,
                                        Email = employeeDetail.Email,
                                        ContactNumber = employeeDetail.ContactNumber,
                                        RoleType = roleDetail.RoleType,
                                        EmployeeStatus = employeeDetail.EmployeeStatus,
                                        JoiningDate = employeeDetail.JoiningDate,
                                        Image = employeeDetail.Image,
                                        FullName = employeeDetail.FirstName + " " + employeeDetail.MiddleName + " " + employeeDetail.LastName
                                    }).ToList()/*.Adapt<List<GetUserResDTO>>()*/;

                getEmployeeResDTO.TotalCount = lstEmployeeeList.Count;
                getEmployeeResDTO.EmployeeeLists = lstEmployeeeList.OrderBy(x => x.EmployeeId)
                                                                  .Skip((getEmployeeReqDTO.Page - 1) * getEmployeeReqDTO.ItemsPerPage)
                                                                  .Take(getEmployeeReqDTO.ItemsPerPage).ToList();

                if (lstEmployeeeList.Count > 0)
                {
                    response.Data = getEmployeeResDTO;
                    response.Message = "data found successfully!";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = " data not found!";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetEmployeeByName(GetEmployeeByNameReqDTO getEmployeeByNameReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                GetEmployeeByNameResDTO getEmployeeByNameResDTO = new GetEmployeeByNameResDTO();


                List<GetEmployeeByNameResDTO> lstGetEmployeeByNameResDTO = (from employeeDetail in _commonRepo.EmployeeMstList().Where(x => x.FirstName == getEmployeeByNameReqDTO.FirstName)
                                                                            join roleDetail in _commonRepo.RoleMstList()
                                                                                   on employeeDetail.RoleId equals roleDetail.RoleId
                                                                            select new GetEmployeeByNameResDTO
                                                                            {
                                                                                EmployeeId = employeeDetail.EmployeeId,
                                                                                Email = employeeDetail.Email,
                                                                                ContactNumber = employeeDetail.ContactNumber,
                                                                                RoleType = roleDetail.RoleType,
                                                                                EmployeeStatus = employeeDetail.EmployeeStatus,
                                                                                JoiningDate = employeeDetail.JoiningDate,
                                                                                Image = employeeDetail.Image,
                                                                                FullName = employeeDetail.FirstName + " " + employeeDetail.MiddleName + " " + employeeDetail.LastName
                                                                            }).ToList().Adapt<List<GetEmployeeByNameResDTO>>();

                if (lstGetEmployeeByNameResDTO.Count > 0)
                {
                    response.Data = lstGetEmployeeByNameResDTO;
                    response.Message = "data found successfully!";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "employee data not found";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetEmployeeByIdPersonalInformation(GetEmployeeByIdPersonalInformationReqDTO getEmployeeByIdPersonalInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                List<GetEmployeeByIdPersonalInformationResDTO> lstGetEmployeeByIdPersonalInformationResDTO = _commonRepo.EmployeeMstList().Where(x => x.EmployeeId == getEmployeeByIdPersonalInformationReqDTO.EmployeeId).ToList().Adapt<List<GetEmployeeByIdPersonalInformationResDTO>>();

                if (lstGetEmployeeByIdPersonalInformationResDTO.Count > 0)
                {
                    response.Data = lstGetEmployeeByIdPersonalInformationResDTO;
                    response.Message = "Employee personal information data are found";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Employee data not found";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }

            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetEmployeeByIdJobInformation(GetEmployeeByIdJobInformationReqDTO getEmployeeByIdJobInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                List<GetEmployeeByIdJobInformationResDTO> lstGetEmployeeByIdJobInformationResDTO = _commonRepo.EmployeeMstList().Where(x => x.EmployeeId == getEmployeeByIdJobInformationReqDTO.EmployeeId).ToList().Adapt<List<GetEmployeeByIdJobInformationResDTO>>();

                if (lstGetEmployeeByIdJobInformationResDTO.Count > 0)
                {
                    response.Data = lstGetEmployeeByIdJobInformationResDTO;
                    response.Message = "Employee Job information data are found";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Employee data not found";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }

            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetEmployeeByIdBankAndSalaryInformation(GetEmployeeByIdBankAndSalaryInformationReqDTO getEmployeeByIdBankAndSalaryInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                List<GetEmployeeByIdBankAndSalaryInformationResDTO> lstGetEmployeeByIdBankAndSalaryInformationResDTO = _commonRepo.EmployeeMstList().Where(x => x.EmployeeId == getEmployeeByIdBankAndSalaryInformationReqDTO.EmployeeId).ToList().Adapt<List<GetEmployeeByIdBankAndSalaryInformationResDTO>>();

                if (lstGetEmployeeByIdBankAndSalaryInformationResDTO.Count > 0)
                {
                    response.Data = lstGetEmployeeByIdBankAndSalaryInformationResDTO;
                    response.Message = "Employee Bank & Salary information data are found";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Employee data not found";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }

            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddEmployeePersonalInformation(AddEmployeePersonalInformationReqDTO addEmployeePersonalInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                EmployeeMst employeeMst = new EmployeeMst();
                AddEmployeePersonalInformationResDTO addEmployeePersonalInformationResDTO = new AddEmployeePersonalInformationResDTO();

                var employeeDetail = await _commonRepo.EmployeeMstList().FirstOrDefaultAsync(x => x.EmployeeId == addEmployeePersonalInformationReqDTO.EmployeeId || x.Email == addEmployeePersonalInformationReqDTO.Email);

                if (employeeDetail == null)
                {
                    if (_dbContext.EmployeeMsts.FirstOrDefault(x => x.EmployeeId == addEmployeePersonalInformationReqDTO.EmployeeId && (x.IsDelete == true || x.IsActive == true)) == null)
                    {
                        employeeMst.EmployeeId = addEmployeePersonalInformationReqDTO.EmployeeId;
                    }
                    else
                    {
                        response.Message = "Employee Id Already exists";
                        response.Status = false;
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return response;
                    }
                       
                    if (addEmployeePersonalInformationReqDTO.Image != null)
                    {
                        string imgName = uploadUserImage(addEmployeePersonalInformationReqDTO.Image);
                        employeeMst.Image = imgName;
                    }
                    else
                    {
                        employeeMst.Image = addEmployeePersonalInformationReqDTO.Image;
                    }

                    employeeMst.FirstName = addEmployeePersonalInformationReqDTO.FirstName;
                    employeeMst.MiddleName = addEmployeePersonalInformationReqDTO.MiddleName;
                    employeeMst.LastName = addEmployeePersonalInformationReqDTO.LastName;
                    employeeMst.Email = addEmployeePersonalInformationReqDTO.Email;
                    employeeMst.Gender = addEmployeePersonalInformationReqDTO.Gender;
                    employeeMst.DateOfBirth = addEmployeePersonalInformationReqDTO.DateOfBirth;
                    employeeMst.ContactNumber = addEmployeePersonalInformationReqDTO.ContactNumber;
                    employeeMst.EmergencyContactName = addEmployeePersonalInformationReqDTO.EmergencyContactName;
                    employeeMst.EmergencyContactNo = addEmployeePersonalInformationReqDTO.EmergencyContactNo;
                    employeeMst.Password = addEmployeePersonalInformationReqDTO.Password;
                    employeeMst.MartialStatus = addEmployeePersonalInformationReqDTO.MartialStatus;
                    employeeMst.PermanentAddress = addEmployeePersonalInformationReqDTO.PermanentAddress;
                    employeeMst.PermanentAddressPostalCode = addEmployeePersonalInformationReqDTO.PermanentAddressPostalCode;
                    employeeMst.CurrentAddress = addEmployeePersonalInformationReqDTO.CurrentAddress;
                    employeeMst.CurrentAddressPostalCode = addEmployeePersonalInformationReqDTO.CurrentAddressPostalCode;
                    employeeMst.EmployeeStatus = true;
                    employeeMst.CreatedBy = 1;
                    employeeMst.IsActive = true;
                    employeeMst.IsDelete = false;
                    employeeMst.CreatedDate = DateTime.Now;

                    _dbContext.EmployeeMsts.Add(employeeMst);
                    _dbContext.SaveChanges();

                    addEmployeePersonalInformationResDTO.EmployeeId = employeeMst.EmployeeId;
                    response.Data = addEmployeePersonalInformationResDTO;
                    response.Message = "Employee personal information added successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Employee already exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddEmployeeJobInformation(AddEmployeeJobInformationReqDTO addEmployeeJobInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AddEmployeeJobInformationResDTO addEmployeeJobInformationResDTO = new AddEmployeeJobInformationResDTO();
                var employeeDetail = await _commonRepo.EmployeeMstList().FirstOrDefaultAsync(x => x.EmployeeId == addEmployeeJobInformationReqDTO.EmployeeId);

                if (employeeDetail != null)
                {
                    employeeDetail.EmployeeTypeId = addEmployeeJobInformationReqDTO.EmployeeTypeId;
                    employeeDetail.CompanyName = addEmployeeJobInformationReqDTO.CompanyName;
                    employeeDetail.DepartmentId = addEmployeeJobInformationReqDTO.DepartmentId;
                    employeeDetail.DesignationId = addEmployeeJobInformationReqDTO.DesignationId;
                    employeeDetail.JoiningDate = addEmployeeJobInformationReqDTO.JoiningDate;
                    employeeDetail.OfferDate = addEmployeeJobInformationReqDTO.OfferDate;
                    employeeDetail.ExitDate = addEmployeeJobInformationReqDTO.ExitDate;
                    employeeDetail.ComapanyAddress = addEmployeeJobInformationReqDTO.ComapanyAddress;
                    employeeDetail.ProbationPeriod = addEmployeeJobInformationReqDTO.ProbationPeriod;
                    employeeDetail.NoticePeriod = addEmployeeJobInformationReqDTO.NoticePeriod;
                    employeeDetail.RoleId = addEmployeeJobInformationReqDTO.RoleId;
                    employeeDetail.ReportingManagerId = addEmployeeJobInformationReqDTO.ReportingManagerId;
                    employeeDetail.UpdatedBy = 1;
                    employeeDetail.UpdatedDate = DateTime.Now;

                    _dbContext.Entry(employeeDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    addEmployeeJobInformationResDTO.EmployeeId = employeeDetail.EmployeeId;
                    response.Data = addEmployeeJobInformationResDTO;
                    response.Message = "Employee Job information added successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Employee not exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddEmployeeBankAndSalaryInformation(AddEmployeeBankAndSalaryInformationReqDTO addEmployeeBankAndSalaryInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AddEmployeeBankAndSalaryInformationResDTO addEmployeeBankAndSalaryInformationResDTO = new AddEmployeeBankAndSalaryInformationResDTO();
                var employeeDetail = await _commonRepo.EmployeeMstList().FirstOrDefaultAsync(x => x.EmployeeId == addEmployeeBankAndSalaryInformationReqDTO.EmployeeId);

                if (employeeDetail != null)
                {
                    employeeDetail.BankName = addEmployeeBankAndSalaryInformationReqDTO.BankName;
                    employeeDetail.NameOnTheAccount = addEmployeeBankAndSalaryInformationReqDTO.NameOnTheAccount;
                    employeeDetail.AccountNo = addEmployeeBankAndSalaryInformationReqDTO.AccountNo;
                    employeeDetail.BankBranch = addEmployeeBankAndSalaryInformationReqDTO.BankBranch;
                    employeeDetail.BankIfsc = addEmployeeBankAndSalaryInformationReqDTO.BankIfsc;
                    employeeDetail.PfaccountNo = addEmployeeBankAndSalaryInformationReqDTO.PfaccountNo;
                    employeeDetail.AadharNo = addEmployeeBankAndSalaryInformationReqDTO.AadharNo;
                    employeeDetail.Panno = addEmployeeBankAndSalaryInformationReqDTO.Panno;
                    employeeDetail.MonthlySalary = addEmployeeBankAndSalaryInformationReqDTO.MonthlySalary;
                    employeeDetail.Pfamount = addEmployeeBankAndSalaryInformationReqDTO.Pfamount;
                    employeeDetail.Esiamount = addEmployeeBankAndSalaryInformationReqDTO.Esiamount;
                    employeeDetail.Ptamount = addEmployeeBankAndSalaryInformationReqDTO.Ptamount;
                    employeeDetail.PfApplicable = addEmployeeBankAndSalaryInformationReqDTO.PfApplicable;
                    employeeDetail.PtApplicable = addEmployeeBankAndSalaryInformationReqDTO.PtApplicable;
                    employeeDetail.EsiApplicable = addEmployeeBankAndSalaryInformationReqDTO.EsiApplicable;
                    employeeDetail.UpdatedBy = 1;
                    employeeDetail.UpdatedDate = DateTime.Now;

                    _dbContext.Entry(employeeDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    addEmployeeBankAndSalaryInformationResDTO.EmployeeId = employeeDetail.EmployeeId;
                    response.Data = addEmployeeBankAndSalaryInformationResDTO;
                    response.Message = "Employee bank & salary information added successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Employee not exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> UpdateEmployeePersonalInformation(UpdateEmployeePersonalInformationReqDTO updateEmployeePersonalInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateEmployeePersonalInformationResDTO updateEmployeePersonalInformationResDTO = new UpdateEmployeePersonalInformationResDTO();

                var employeeDetail = await _commonRepo.EmployeeMstList().FirstOrDefaultAsync(x => x.EmployeeId == updateEmployeePersonalInformationReqDTO.EmployeeId);
                if (employeeDetail != null)
                {

                    if (_commonRepo.EmployeeMstList().FirstOrDefault(x => x.Email.Trim() == updateEmployeePersonalInformationReqDTO.Email.Trim() && x.EmployeeId != updateEmployeePersonalInformationReqDTO.EmployeeId) != null)
                    {
                        response.Message = "Employee email already exists";
                        response.Status = false;
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                    else
                    {
                        if (updateEmployeePersonalInformationReqDTO.Image != null)
                        {
                            string imgName = uploadUserImage(updateEmployeePersonalInformationReqDTO.Image);
                            employeeDetail.Image = imgName;
                        }
                        else
                        {
                            employeeDetail.Image = updateEmployeePersonalInformationReqDTO.Image;
                        }

                        employeeDetail.FirstName = updateEmployeePersonalInformationReqDTO.FirstName;
                        employeeDetail.MiddleName = updateEmployeePersonalInformationReqDTO.MiddleName;
                        employeeDetail.LastName = updateEmployeePersonalInformationReqDTO.LastName;
                        employeeDetail.Email = updateEmployeePersonalInformationReqDTO.Email;
                        employeeDetail.Gender = updateEmployeePersonalInformationReqDTO.Gender;
                        employeeDetail.DateOfBirth = updateEmployeePersonalInformationReqDTO.DateOfBirth;
                        employeeDetail.ContactNumber = updateEmployeePersonalInformationReqDTO.ContactNumber;
                        employeeDetail.EmergencyContactName = updateEmployeePersonalInformationReqDTO.EmergencyContactName;
                        employeeDetail.EmergencyContactNo = updateEmployeePersonalInformationReqDTO.EmergencyContactNo;
                        employeeDetail.Password = updateEmployeePersonalInformationReqDTO.Password;
                        employeeDetail.MartialStatus = updateEmployeePersonalInformationReqDTO.MartialStatus;
                        employeeDetail.PermanentAddress = updateEmployeePersonalInformationReqDTO.PermanentAddress;
                        employeeDetail.PermanentAddressPostalCode = updateEmployeePersonalInformationReqDTO.PermanentAddressPostalCode;
                        employeeDetail.CurrentAddress = updateEmployeePersonalInformationReqDTO.CurrentAddress;
                        employeeDetail.CurrentAddressPostalCode = updateEmployeePersonalInformationReqDTO.CurrentAddressPostalCode;
                        employeeDetail.UpdatedBy = 1;
                        employeeDetail.UpdatedDate = DateTime.Now;

                        _dbContext.Entry(employeeDetail).State = EntityState.Modified;
                        _dbContext.SaveChanges();

                        updateEmployeePersonalInformationResDTO.EmployeeId = employeeDetail.EmployeeId;
                        response.Data = updateEmployeePersonalInformationResDTO;
                        response.Message = "Employee personal information updated successfully";
                        response.Status = true;
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "Employee not exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> UpdateEmployeeJobInformation(UpdateEmployeeJobInformationReqDTO updateEmployeeJobInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateEmployeeJobInformationResDTO updateEmployeeJobInformationResDTO = new UpdateEmployeeJobInformationResDTO();
                var employeeDetail = await _commonRepo.EmployeeMstList().FirstOrDefaultAsync(x => x.EmployeeId == updateEmployeeJobInformationReqDTO.EmployeeId);

                if (employeeDetail != null)
                {
                    employeeDetail.EmployeeTypeId = updateEmployeeJobInformationReqDTO.EmployeeTypeId;
                    employeeDetail.CompanyName = updateEmployeeJobInformationReqDTO.CompanyName;
                    employeeDetail.DepartmentId = updateEmployeeJobInformationReqDTO.DepartmentId;
                    employeeDetail.DesignationId = updateEmployeeJobInformationReqDTO.DesignationId;
                    employeeDetail.JoiningDate = updateEmployeeJobInformationReqDTO.JoiningDate;
                    employeeDetail.OfferDate = updateEmployeeJobInformationReqDTO.OfferDate;
                    employeeDetail.ExitDate = updateEmployeeJobInformationReqDTO.ExitDate;
                    employeeDetail.ComapanyAddress = updateEmployeeJobInformationReqDTO.ComapanyAddress;
                    employeeDetail.ProbationPeriod = updateEmployeeJobInformationReqDTO.ProbationPeriod;
                    employeeDetail.NoticePeriod = updateEmployeeJobInformationReqDTO.NoticePeriod;
                    employeeDetail.RoleId = updateEmployeeJobInformationReqDTO.RoleId;
                    employeeDetail.ReportingManagerId = updateEmployeeJobInformationReqDTO.ReportingManagerId;
                    employeeDetail.UpdatedBy = 1;
                    employeeDetail.UpdatedDate = DateTime.Now;

                    _dbContext.Entry(employeeDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    updateEmployeeJobInformationReqDTO.EmployeeId = employeeDetail.EmployeeId;
                    response.Data = updateEmployeeJobInformationReqDTO;
                    response.Message = "Employee Job information updated successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Employee not exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> UpdateEmployeeBankAndSalaryInformation(UpdateEmployeeBankAndSalaryInformationReqDTO updateEmployeeBankAndSalaryInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateEmployeeBankAndSalaryInformationResDTO updateEmployeeBankAndSalaryInformationResDTO = new UpdateEmployeeBankAndSalaryInformationResDTO();
                var employeeDetail = await _commonRepo.EmployeeMstList().FirstOrDefaultAsync(x => x.EmployeeId == updateEmployeeBankAndSalaryInformationReqDTO.EmployeeId);

                if (employeeDetail != null)
                {
                    employeeDetail.BankName = updateEmployeeBankAndSalaryInformationReqDTO.BankName;
                    employeeDetail.NameOnTheAccount = updateEmployeeBankAndSalaryInformationReqDTO.NameOnTheAccount;
                    employeeDetail.AccountNo = updateEmployeeBankAndSalaryInformationReqDTO.AccountNo;
                    employeeDetail.BankBranch = updateEmployeeBankAndSalaryInformationReqDTO.BankBranch;
                    employeeDetail.BankIfsc = updateEmployeeBankAndSalaryInformationReqDTO.BankIfsc;
                    employeeDetail.PfaccountNo = updateEmployeeBankAndSalaryInformationReqDTO.PfaccountNo;
                    employeeDetail.AadharNo = updateEmployeeBankAndSalaryInformationReqDTO.AadharNo;
                    employeeDetail.Panno = updateEmployeeBankAndSalaryInformationReqDTO.Panno;
                    employeeDetail.MonthlySalary = updateEmployeeBankAndSalaryInformationReqDTO.MonthlySalary;
                    employeeDetail.Pfamount = updateEmployeeBankAndSalaryInformationReqDTO.Pfamount;
                    employeeDetail.Esiamount = updateEmployeeBankAndSalaryInformationReqDTO.Esiamount;
                    employeeDetail.Ptamount = updateEmployeeBankAndSalaryInformationReqDTO.Ptamount;
                    employeeDetail.PfApplicable = updateEmployeeBankAndSalaryInformationReqDTO.PfApplicable;
                    employeeDetail.PtApplicable = updateEmployeeBankAndSalaryInformationReqDTO.PtApplicable;
                    employeeDetail.EsiApplicable = updateEmployeeBankAndSalaryInformationReqDTO.EsiApplicable;
                    employeeDetail.UpdatedBy = 1;
                    employeeDetail.UpdatedDate = DateTime.Now;

                    _dbContext.Entry(employeeDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    updateEmployeeBankAndSalaryInformationResDTO.EmployeeId = employeeDetail.EmployeeId;
                    response.Data = updateEmployeeBankAndSalaryInformationResDTO;
                    response.Message = "Employee bank & salary information updated successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Status = false;
                    response.Message = "Employee not exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> DeleteEmployee(DeleteEmployeeReqDTO deleteEmployeeReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                DeleteEmployeeResDTO deleteEmployeeResDTO = new DeleteEmployeeResDTO();
                var employeeDetail = await _commonRepo.EmployeeMstList().FirstOrDefaultAsync(x => x.EmployeeId == deleteEmployeeReqDTO.EmployeeId);

                if (employeeDetail != null)
                {
                    employeeDetail.IsDelete = true;
                    employeeDetail.UpdatedBy = 1;
                    employeeDetail.UpdatedDate = DateTime.Now;
                    employeeDetail.EmployeeStatus = false;
                    _dbContext.Entry(employeeDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    deleteEmployeeResDTO.EmployeeId = employeeDetail.EmployeeId;
                    response.Data = deleteEmployeeResDTO;
                    response.Message = "User deleted successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;

                }
                else
                {
                    response.Status = false;
                    response.Message = "User not exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddResign(ResignReqDTO resignReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                ResignMst resignMst = new ResignMst();
                ResignResDTO resignResDTO = new ResignResDTO();
                var employeeDetail = await _commonRepo.EmployeeMstList().FirstOrDefaultAsync(x => x.EmployeeId == resignReqDTO.EmployeeId);
                if (employeeDetail != null)
                {
                    var EmployeeIdExists = _commonRepo.ResignMstsList().FirstOrDefault(x => x.EmployeeId == resignReqDTO.EmployeeId);
                    if (EmployeeIdExists == null)
                    {

                        resignMst.EmployeeId = resignReqDTO.EmployeeId;
                        resignMst.DateOfResignation = resignReqDTO.DateOfResignation;
                        resignMst.AttritionId = resignReqDTO.AttritionId;
                        resignMst.Reason = resignReqDTO.Reason;
                        resignMst.Region = resignReqDTO.Region;
                        resignMst.FinalDate = resignReqDTO.FinalDate;
                        resignMst.FinalStatus = resignReqDTO.FinalStatus;
                        resignMst.CreatedBy = 1;
                        resignMst.CreatedDate = DateTime.Now;

                        _dbContext.ResignMsts.Add(resignMst);
                        _dbContext.SaveChanges();

                        resignResDTO.EmployeeId = resignMst.EmployeeId;
                        response.Data = resignResDTO;
                        response.Message = "User resign added successfully";
                        response.Status = true;
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "User has already applied for the resignation";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "User not exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }

            }
            catch { throw; }
            return response;
        }

        public string uploadUserImage(dynamic imgPath)
        {
            string path = Path.Combine(_hostEnvironment.WebRootPath, "Images");
            string fileName = imgPath.FileName;
            string filePath = Path.Combine(path, fileName);
            string relativePath = Path.Combine("Images", fileName);

            if (fileName != null)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imgPath.CopyTo(fileStream);
                }
            }
            return relativePath;
        }

    }
}
