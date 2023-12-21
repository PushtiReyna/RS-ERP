using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.CommonModels;
using ServiceLayer;
using WebApi.ViewModel.ReqViewModel;
using DTO.ReqDTO;
using DTO.ResDTO;
using Mapster;
using WebApi.ViewModel.ResViewModel;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _iAuth;

        public AuthController(IAuth iAuth)
        {
            _iAuth = iAuth;
        }

        //[AllowAnonymous]
        [HttpPost("Login")]
        public async Task<CommonResponse> Login(LoginReqViewModel loginReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAuth.Login(loginReqViewModel.Adapt<LoginReqDTO>());
                LoginResDTO loginResDTO = response.Data;
                response.Data = loginResDTO.Adapt<LoginResViewModel>();
            }
            catch { throw; }
            return response;
        }

        //[AllowAnonymous]
        [HttpPost("GenerateNewToken")]
        public async Task<CommonResponse> CreateNewToken(TokenReqViewModel tokenReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAuth.CreateNewToken(tokenReqViewModel.Adapt<TokenReqDTO>());
                TokenResDTO tokenResDTO = response.Data;
                response.Data = tokenResDTO.Adapt<TokenResViewModel>();
            }
            catch { throw; }
            return response;
        }


        [HttpPost("ChangePassword")]
        public async Task<CommonResponse> ChangePassword(ChangePasswordReqViewModel changePasswordReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAuth.ChangePassword(changePasswordReqViewModel.Adapt<ChangePasswordReqDTO>());
                ChangePasswordResDTO changePasswordResDTO = response.Data;
                response.Data = changePasswordResDTO.Adapt<ChangePasswordResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("ResetPassword")]
        public async Task<CommonResponse> ResetPassword(ResetPasswordReqViewModel resetPasswordReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAuth.ResetPassword(resetPasswordReqViewModel.Adapt<ResetPasswordReqDTO>());
                ResetPasswordResDTO resetPasswordResDTO = response.Data;
                response.Data = resetPasswordResDTO.Adapt<ResetPasswordResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("Forgetpassword")]
        public async Task<CommonResponse> ForgetPassword(ForgotpasswordReqViewModel forgotpasswordReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAuth.ForgetPassword(forgotpasswordReqViewModel.Adapt<ForgotpasswordReqDTO>());
                ForgotpasswordResDTO forgotpasswordResDTO = response.Data;
                response.Data = forgotpasswordResDTO.Adapt<ForgotpasswordResViewModel>();
            }
            catch { throw; }
            return response;
        }
    }
    
}
