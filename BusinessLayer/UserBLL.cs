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

namespace BusinessLayer
{
    public class UserBLL
    {
        private readonly DBContext _dbContext;
        private readonly CommonRepo _commonRepo;
        public readonly IHostingEnvironment _hostEnvironment;
        public UserBLL(DBContext dbContext, CommonRepo commonRepo, IHostingEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<CommonResponse> GetUser()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                GetUserResDTO getUserResDTO = new GetUserResDTO();
                List<GetUserResDTO> lstGetSubCategoryResDTO = (from userDetail in _commonRepo.UserMstList().Where(x => x.EmployeeStatus == true)
                                                               join roleDetail in _commonRepo.RoleMstList()
                                                                      on userDetail.RoleId equals roleDetail.RoleId
                                                               select new GetUserResDTO
                                                               {
                                                                   EmployeeId = userDetail.EmployeeId,
                                                                   Email = userDetail.Email,
                                                                   ContactNumber = userDetail.ContactNumber,
                                                                   RoleType = roleDetail.RoleType,
                                                                   EmployeeStatus = userDetail.EmployeeStatus,
                                                                   JoiningDate = userDetail.JoiningDate,
                                                                   Image = userDetail.Image,
                                                                   FullName = userDetail.FirstName + " " + userDetail.MiddleName + " " + userDetail.LastName
                                                               }).ToList().Adapt<List<GetUserResDTO>>();
                if (lstGetSubCategoryResDTO.Count > 0)
                {
                    response.Data = lstGetSubCategoryResDTO;
                    response.Message = "list of users get successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "users data not found";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddUserPersonalInformation(AddUserPersonalInformationReqDTO addUserPersonalInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UserMst userMst = new UserMst();
                AddUserPersonalInformationResDTO addUserPersonalInformationResDTO = new AddUserPersonalInformationResDTO();

                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == addUserPersonalInformationReqDTO.EmployeeId || x.Email == addUserPersonalInformationReqDTO.Email);
                if (userDetail == null)
                {
                    userMst.EmployeeId = addUserPersonalInformationReqDTO.EmployeeId;
                    string imgName = uploadUserImage(addUserPersonalInformationReqDTO.Image);
                    userMst.Image = imgName;
                    userMst.FirstName = addUserPersonalInformationReqDTO.FirstName;
                    userMst.MiddleName = addUserPersonalInformationReqDTO.MiddleName;
                    userMst.LastName = addUserPersonalInformationReqDTO.LastName;
                    userMst.Email = addUserPersonalInformationReqDTO.Email;
                    userMst.Gender = addUserPersonalInformationReqDTO.Gender;
                    userMst.DateOfBirth = addUserPersonalInformationReqDTO.DateOfBirth;
                    userMst.ContactNumber = addUserPersonalInformationReqDTO.ContactNumber;
                    userMst.EmergencyContactName = addUserPersonalInformationReqDTO.EmergencyContactName;
                    userMst.EmergencyContactNo = addUserPersonalInformationReqDTO.EmergencyContactNo;
                    userMst.Password = addUserPersonalInformationReqDTO.Password;
                    userMst.MartialStatus = addUserPersonalInformationReqDTO.MartialStatus;
                    userMst.PermanentAddress = addUserPersonalInformationReqDTO.PermanentAddress;
                    userMst.PermanentAddressPostalCode = addUserPersonalInformationReqDTO.PermanentAddressPostalCode;
                    userMst.CurrentAddress = addUserPersonalInformationReqDTO.CurrentAddress;
                    userMst.CurrentAddressPostalCode = addUserPersonalInformationReqDTO.CurrentAddressPostalCode;
                    userMst.EmployeeStatus = true;
                    userMst.CreatedBy = 1;
                    userMst.IsActive = true;
                    userMst.IsDelete = false;
                    userMst.CreatedDate = DateTime.Now;

                    _dbContext.UserMsts.Add(userMst);
                    _dbContext.SaveChanges();

                    addUserPersonalInformationResDTO.EmployeeId = userMst.EmployeeId;
                    response.Data = addUserPersonalInformationResDTO;
                    response.Message = "user personal information added successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Status = false;
                    response.Message = "user already exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }

            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddUserJobInformation(AddUserJobInformationReqDTO addUserJobInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AddUserJobInformationResDTO addUserJobInformationResDTO = new AddUserJobInformationResDTO();
                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == addUserJobInformationReqDTO.EmployeeId);

                if (userDetail != null)
                {
                    userDetail.EmployeeTypeId = addUserJobInformationReqDTO.EmployeeTypeId;
                    userDetail.CompanyName = addUserJobInformationReqDTO.CompanyName;
                    userDetail.DepartmentId = addUserJobInformationReqDTO.DepartmentId;
                    userDetail.DesignationId = addUserJobInformationReqDTO.DesignationId;
                    userDetail.JoiningDate = addUserJobInformationReqDTO.JoiningDate;
                    userDetail.OfferDate = addUserJobInformationReqDTO.OfferDate;
                    userDetail.ExitDate = addUserJobInformationReqDTO.ExitDate;
                    userDetail.ComapanyAddress = addUserJobInformationReqDTO.ComapanyAddress;
                    userDetail.ProbationPeriod = addUserJobInformationReqDTO.ProbationPeriod;
                    userDetail.NoticePeriod = addUserJobInformationReqDTO.NoticePeriod;
                    userDetail.RoleId = addUserJobInformationReqDTO.RoleId;
                    userDetail.ReportingManagerId = addUserJobInformationReqDTO.ReportingManagerId;
                    userDetail.UpdatedBy = userDetail.EmployeeId;
                    userDetail.UpdatedDate = DateTime.Now;

                    _dbContext.Entry(userDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    addUserJobInformationReqDTO.EmployeeId = userDetail.EmployeeId;
                    response.Data = addUserJobInformationResDTO;
                    response.Message = "user Job information added successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Status = false;
                    response.Message = "user not exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddUserBankAndSalaryInformation(AddUserBankAndSalaryInformationReqDTO addUserBankAndSalaryInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                AddUserBankAndSalaryInformationResDTO addUserBankAndSalaryInformationResDTO = new AddUserBankAndSalaryInformationResDTO();
                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == addUserBankAndSalaryInformationReqDTO.EmployeeId);

                if (userDetail != null)
                {
                    userDetail.BankName = addUserBankAndSalaryInformationReqDTO.BankName;
                    userDetail.NameOnTheAccount = addUserBankAndSalaryInformationReqDTO.NameOnTheAccount;
                    userDetail.AccountNo = addUserBankAndSalaryInformationReqDTO.AccountNo;
                    userDetail.BankBranch = addUserBankAndSalaryInformationReqDTO.BankBranch;
                    userDetail.BankIfsc = addUserBankAndSalaryInformationReqDTO.BankIfsc;
                    userDetail.PfaccountNo = addUserBankAndSalaryInformationReqDTO.PfaccountNo;
                    userDetail.AadharNo = addUserBankAndSalaryInformationReqDTO.AadharNo;
                    userDetail.Panno = addUserBankAndSalaryInformationReqDTO.Panno;
                    userDetail.MonthlySalary = addUserBankAndSalaryInformationReqDTO.MonthlySalary;
                    userDetail.Pfamount = addUserBankAndSalaryInformationReqDTO.Pfamount;
                    userDetail.Esiamount = addUserBankAndSalaryInformationReqDTO.Esiamount;
                    userDetail.Ptamount = addUserBankAndSalaryInformationReqDTO.Ptamount;
                    userDetail.PfApplicable = addUserBankAndSalaryInformationReqDTO.PfApplicable;
                    userDetail.PtApplicable = addUserBankAndSalaryInformationReqDTO.PtApplicable;
                    userDetail.EsiApplicable = addUserBankAndSalaryInformationReqDTO.EsiApplicable;
                    userDetail.UpdatedBy = userDetail.EmployeeId;
                    userDetail.UpdatedDate = DateTime.Now;

                    _dbContext.Entry(userDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    addUserBankAndSalaryInformationResDTO.EmployeeId = userDetail.EmployeeId;
                    response.Data = addUserBankAndSalaryInformationResDTO;
                    response.Message = "User bank & salary information added successfully";
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

        public async Task<CommonResponse> UpdateUserPersonalInformation(UpdateUserPersonalInformationReqDTO updateUserPersonalInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateUserPersonalInformationResDTO updateUserPersonalInformationResDTO = new UpdateUserPersonalInformationResDTO();

                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == updateUserPersonalInformationReqDTO.EmployeeId);
                if (userDetail != null)
                {
                    string imgName = uploadUserImage(updateUserPersonalInformationReqDTO.Image);
                    userDetail.Image = imgName;
                    userDetail.FirstName = updateUserPersonalInformationReqDTO.FirstName;
                    userDetail.MiddleName = updateUserPersonalInformationReqDTO.MiddleName;
                    userDetail.LastName = updateUserPersonalInformationReqDTO.LastName;
                    userDetail.Email = updateUserPersonalInformationReqDTO.Email;
                    userDetail.Gender = updateUserPersonalInformationReqDTO.Gender;
                    userDetail.DateOfBirth = updateUserPersonalInformationReqDTO.DateOfBirth;
                    userDetail.ContactNumber = updateUserPersonalInformationReqDTO.ContactNumber;
                    userDetail.EmergencyContactName = updateUserPersonalInformationReqDTO.EmergencyContactName;
                    userDetail.EmergencyContactNo = updateUserPersonalInformationReqDTO.EmergencyContactNo;
                    userDetail.Password = updateUserPersonalInformationReqDTO.Password;
                    userDetail.MartialStatus = updateUserPersonalInformationReqDTO.MartialStatus;
                    userDetail.PermanentAddress = updateUserPersonalInformationReqDTO.PermanentAddress;
                    userDetail.PermanentAddressPostalCode = updateUserPersonalInformationReqDTO.PermanentAddressPostalCode;
                    userDetail.CurrentAddress = updateUserPersonalInformationReqDTO.CurrentAddress;
                    userDetail.CurrentAddressPostalCode = updateUserPersonalInformationReqDTO.CurrentAddressPostalCode;
                    userDetail.UpdatedBy = userDetail.EmployeeId;
                    userDetail.UpdatedDate = DateTime.Now;

                    _dbContext.Entry(userDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    updateUserPersonalInformationResDTO.EmployeeId = userDetail.EmployeeId;
                    response.Data = updateUserPersonalInformationResDTO;
                    response.Message = "User personal information updated successfully";
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

        public async Task<CommonResponse> UpdateUserJobInformation(UpdateUserJobInformationReqDTO updateUserJobInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateUserJobInformationResDTO updateUserJobInformationResDTO = new UpdateUserJobInformationResDTO();
                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == updateUserJobInformationReqDTO.EmployeeId);

                if (userDetail != null)
                {
                    userDetail.EmployeeTypeId = updateUserJobInformationReqDTO.EmployeeTypeId;
                    userDetail.CompanyName = updateUserJobInformationReqDTO.CompanyName;
                    userDetail.DepartmentId = updateUserJobInformationReqDTO.DepartmentId;
                    userDetail.DesignationId = updateUserJobInformationReqDTO.DesignationId;
                    userDetail.JoiningDate = updateUserJobInformationReqDTO.JoiningDate;
                    userDetail.OfferDate = updateUserJobInformationReqDTO.OfferDate;
                    userDetail.ExitDate = updateUserJobInformationReqDTO.ExitDate;
                    userDetail.ComapanyAddress = updateUserJobInformationReqDTO.ComapanyAddress;
                    userDetail.ProbationPeriod = updateUserJobInformationReqDTO.ProbationPeriod;
                    userDetail.NoticePeriod = updateUserJobInformationReqDTO.NoticePeriod;
                    userDetail.RoleId = updateUserJobInformationReqDTO.RoleId;
                    userDetail.ReportingManagerId = updateUserJobInformationReqDTO.ReportingManagerId;
                    userDetail.UpdatedBy = userDetail.EmployeeId;
                    userDetail.UpdatedDate = DateTime.Now;

                    _dbContext.Entry(userDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    updateUserJobInformationResDTO.EmployeeId = userDetail.EmployeeId;
                    response.Data = updateUserJobInformationResDTO;
                    response.Message = "User Job information updated successfully";
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

        public async Task<CommonResponse> UpdateUserBankAndSalaryInformation(UpdateUserBankAndSalaryInformationReqDTO updateUserBankAndSalaryInformationReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateUserBankAndSalaryInformationResDTO updateUserBankAndSalaryInformationResDTO = new UpdateUserBankAndSalaryInformationResDTO();
                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == updateUserBankAndSalaryInformationReqDTO.EmployeeId);

                if (userDetail != null)
                {
                    userDetail.BankName = updateUserBankAndSalaryInformationReqDTO.BankName;
                    userDetail.NameOnTheAccount = updateUserBankAndSalaryInformationReqDTO.NameOnTheAccount;
                    userDetail.AccountNo = updateUserBankAndSalaryInformationReqDTO.AccountNo;
                    userDetail.BankBranch = updateUserBankAndSalaryInformationReqDTO.BankBranch;
                    userDetail.BankIfsc = updateUserBankAndSalaryInformationReqDTO.BankIfsc;
                    userDetail.PfaccountNo = updateUserBankAndSalaryInformationReqDTO.PfaccountNo;
                    userDetail.AadharNo = updateUserBankAndSalaryInformationReqDTO.AadharNo;
                    userDetail.Panno = updateUserBankAndSalaryInformationReqDTO.Panno;
                    userDetail.MonthlySalary = updateUserBankAndSalaryInformationReqDTO.MonthlySalary;
                    userDetail.Pfamount = updateUserBankAndSalaryInformationReqDTO.Pfamount;
                    userDetail.Esiamount = updateUserBankAndSalaryInformationReqDTO.Esiamount;
                    userDetail.Ptamount = updateUserBankAndSalaryInformationReqDTO.Ptamount;
                    userDetail.PfApplicable = updateUserBankAndSalaryInformationReqDTO.PfApplicable;
                    userDetail.PtApplicable = updateUserBankAndSalaryInformationReqDTO.PtApplicable;
                    userDetail.EsiApplicable = updateUserBankAndSalaryInformationReqDTO.EsiApplicable;
                    userDetail.UpdatedBy = userDetail.EmployeeId;
                    userDetail.UpdatedDate = DateTime.Now;

                    _dbContext.Entry(userDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    updateUserBankAndSalaryInformationResDTO.EmployeeId = userDetail.EmployeeId;
                    response.Data = updateUserBankAndSalaryInformationResDTO;
                    response.Message = "User bank & salary information updated successfully";
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

        public async Task<CommonResponse> DeleteUser(DeleteUserReqDTO deleteUserReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                DeleteUserResDTO deleteUserResDTO = new DeleteUserResDTO();
                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == deleteUserReqDTO.EmployeeId);

                if (userDetail != null)
                {
                    userDetail.IsDelete = true;
                    userDetail.UpdatedBy = userDetail.EmployeeId;
                    userDetail.UpdatedDate = DateTime.Now;
                    userDetail.EmployeeStatus = false;
                    _dbContext.Entry(userDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    deleteUserResDTO.EmployeeId = userDetail.EmployeeId;
                    response.Data = deleteUserResDTO;
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
                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == resignReqDTO.EmployeeId);
                if (userDetail != null)
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
                        resignMst.CreatedBy = userDetail.EmployeeId;
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
