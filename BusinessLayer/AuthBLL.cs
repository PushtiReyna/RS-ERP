

using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.CommonHelpers;
using ServiceLayer.CommonModels;

namespace BusinessLayer
{
    public class AuthBLL
    {
        private readonly DBContext _dbContext;
        private readonly AuthHelper _authHelper;
        private readonly CommonRepo _commonRepo;
        private readonly CommonHelper _commonHelper;
        public AuthBLL(AuthHelper authHelper, CommonRepo commonRepo, DBContext dbContext,CommonHelper commonHelper)
        {
            _authHelper = authHelper;
            _commonRepo = commonRepo;
            _dbContext = dbContext;
            _commonHelper = commonHelper;
        }
        public async Task<CommonResponse> Login(LoginReqDTO loginReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _authHelper.Login(loginReqDTO);
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> CreateNewToken(TokenReqDTO tokenReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _authHelper.CreateNewToken(tokenReqDTO);
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> ChangePassword(ChangePasswordReqDTO changePasswordReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                ChangePasswordResDTO changePasswordResDTO = new ChangePasswordResDTO();
                var employeeDetail = await _commonRepo.EmployeeMstList().FirstOrDefaultAsync(x => x.EmployeeId == changePasswordReqDTO.EmployeeId);
                if (employeeDetail != null)
                {
                    //var encryptPassword = _commonHelper.EncryptString(changePasswordReqDTO.Password.Trim());
                    var decryptPassword = _commonHelper.DecryptString(employeeDetail.Password.Trim());

                    if (decryptPassword == changePasswordReqDTO.NewPassword.Trim())
                    {
                        response.Message = "password is already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return response;
                    }
                    else  if (decryptPassword == changePasswordReqDTO.Password.Trim())
                    {
                        employeeDetail.Password = _commonHelper.EncryptString(changePasswordReqDTO.NewPassword.Trim());
                        employeeDetail.UpdatedDate = _commonHelper.GetCurrentDateTime();
                        employeeDetail.UpdatedBy = 1;
                        _dbContext.Entry(employeeDetail).State = EntityState.Modified;
                        _dbContext.SaveChanges();

                        changePasswordResDTO.EmployeeId = employeeDetail.EmployeeId;
                        response.Data = changePasswordResDTO;
                        response.Message = "changepassword successfully!";
                        response.Status = true;
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Message = "old password is not correct";
                        response.Status = false;
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Message = "data are not correct";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> ResetPassword(ResetPasswordReqDTO resetPasswordReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                ResetPasswordResDTO resetPasswordResDTO = new ResetPasswordResDTO();
                var employeeDetail = _commonRepo.EmployeeMstList().FirstOrDefault(x => x.EmployeeId == resetPasswordReqDTO.EmployeeId);
                if (employeeDetail != null)
                {
                    employeeDetail.Password = _commonHelper.EncryptString(resetPasswordReqDTO.NewPassword.Trim());
                    employeeDetail.UpdatedDate = _commonHelper.GetCurrentDateTime();
                    employeeDetail.UpdatedBy = 1;
                    _dbContext.Entry(employeeDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    resetPasswordResDTO.EmployeeId = employeeDetail.EmployeeId;
                    response.Data = resetPasswordResDTO;
                    response.Message = "reset password successfully!";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "data are not correct";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> ForgetPassword(ForgotpasswordReqDTO forgotPasswordReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                var employeeDetail = _commonRepo.EmployeeMstList().FirstOrDefault(x => x.Email == forgotPasswordReqDTO.Email);
                if(employeeDetail != null)
                {
                    await _commonHelper.SendLinkEmail(forgotPasswordReqDTO.Email, employeeDetail.EmployeeId);
                    response.Message = "reset password link send!";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "data are not correct";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

    }
}
