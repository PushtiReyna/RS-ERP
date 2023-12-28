

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
                var userDetail = await  _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == changePasswordReqDTO.EmployeeId);
                if (userDetail != null)
                {
                    if (userDetail.Password.Trim() == changePasswordReqDTO.Password.Trim())
                    {
                        userDetail.Password = changePasswordReqDTO.NewPassword.Trim();
                        userDetail.UpdatedDate = DateTime.Now;
                        userDetail.UpdatedBy = 1;
                        _dbContext.Entry(userDetail).State = EntityState.Modified;
                        _dbContext.SaveChanges();

                        changePasswordResDTO.EmployeeId = userDetail.EmployeeId;
                        response.Data = changePasswordResDTO;
                        response.Message = "changepassword successfully";
                        response.Status = true;
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else if (userDetail.Password.Trim() == changePasswordReqDTO.NewPassword.Trim())
                    {
                        response.Message = " password is already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return response;
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
                var userDetail = _commonRepo.UserMstList().FirstOrDefault(x => x.EmployeeId == resetPasswordReqDTO.EmployeeId);
                if (userDetail != null)
                {
                    userDetail.Password = resetPasswordReqDTO.NewPassword.Trim();
                    userDetail.UpdatedDate = DateTime.Now;
                    userDetail.UpdatedBy = 1;
                    _dbContext.Entry(userDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    resetPasswordResDTO.EmployeeId = userDetail.EmployeeId;
                    response.Data = resetPasswordResDTO;
                    response.Message = "reset password successfully";
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
                var userDetail = _commonRepo.UserMstList().FirstOrDefault(x => x.Email == forgotPasswordReqDTO.Email);
                if(userDetail != null)
                {
                    await _commonHelper.SendLinkEmail(forgotPasswordReqDTO.Email, userDetail.EmployeeId);
                    response.Message = "reset password link send";
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
