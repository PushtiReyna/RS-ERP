using BusinessLayer;
using DTO.ReqDTO;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AuthImpl : IAuth
    {
        private readonly AuthBLL _authBLL;
        public AuthImpl(AuthBLL authBLL)
        {
            _authBLL = authBLL;
        }

        public async Task<CommonResponse> Login(LoginReqDTO loginReqDTO) => await _authBLL.Login(loginReqDTO);

        public async Task<CommonResponse> CreateNewToken(TokenReqDTO tokenReqDTO) => await _authBLL.CreateNewToken(tokenReqDTO);

        public async Task<CommonResponse> ChangePassword(ChangePasswordReqDTO changePasswordReqDTO) => await _authBLL.ChangePassword(changePasswordReqDTO);
        public async Task<CommonResponse> ResetPassword(ResetPasswordReqDTO resetPasswordReqDTO) => await _authBLL.ResetPassword(resetPasswordReqDTO);
        public async Task<CommonResponse> ForgetPassword(ForgotpasswordReqDTO forgotPasswordReqDTO) => await _authBLL.ForgetPassword(forgotPasswordReqDTO);

    }

    public interface IAuth
    {
        public Task<CommonResponse> Login(LoginReqDTO loginReqDTO);
        public  Task<CommonResponse> CreateNewToken(TokenReqDTO tokenReqDTO);
        public  Task<CommonResponse> ChangePassword(ChangePasswordReqDTO changePasswordReqDTO);
        public  Task<CommonResponse> ResetPassword(ResetPasswordReqDTO resetPasswordReqDTO);
        public  Task<CommonResponse> ForgetPassword(ForgotpasswordReqDTO forgotPasswordReqDTO);
    }
}
