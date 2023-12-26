using DTO.ReqDTO;
using DTO.ResDTO;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using ServiceLayer.CommonModels;
using WebApi.ViewModel.ReqViewModel;
using WebApi.ViewModel.ResViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _iUser;  
        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }

        [HttpGet("Get User")]
        public async Task<CommonResponse> GetUser()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.GetUser();
                List<GetUserResDTO> lstGetClientResDTO = response.Data;
                response.Data = lstGetClientResDTO.Adapt<List<GetUserResViewModel>>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("Add UserPersonalInformation")]
        public async Task<CommonResponse> AddUserPersonalInformation([FromForm] AddUserPersonalInformationReqViewModel addUserPersonalInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.AddUserPersonalInformation(addUserPersonalInformationReqViewModel.Adapt<AddUserPersonalInformationReqDTO>());
                AddUserPersonalInformationResDTO addUserPersonalInformationResDTO = response.Data;
                response.Data = addUserPersonalInformationResDTO.Adapt<AddUserPersonalInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("Add UserJobInformation")]
        public async Task<CommonResponse> AddUserJobInformation(AddUserJobInformationReqViewModel addUserJobInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.AddUserJobInformation(addUserJobInformationReqViewModel.Adapt<AddUserJobInformationReqDTO>());
                AddUserJobInformationResDTO addUserJobInformationResDTO = response.Data;
                response.Data = addUserJobInformationResDTO.Adapt<AddUserJobInformationReqViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("Add UserBankAndSalaryInformation")]
        public async Task<CommonResponse> AddUserBankAndSalaryInformation(AddUserBankAndSalaryInformationReqViewModel addUserBankAndSalaryInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.AddUserBankAndSalaryInformation(addUserBankAndSalaryInformationReqViewModel.Adapt<AddUserBankAndSalaryInformationReqDTO>());
                AddUserBankAndSalaryInformationResDTO addUserBankAndSalaryInformationResDTO = response.Data;
                response.Data = addUserBankAndSalaryInformationResDTO.Adapt<AddUserBankAndSalaryInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("Update UserPersonalInformation")]
        public async Task<CommonResponse> UpdateUserPersonalInformation([FromForm] UpdateUserPersonalInformationReqViewModel updateUserPersonalInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.UpdateUserPersonalInformation(updateUserPersonalInformationReqViewModel.Adapt<UpdateUserPersonalInformationReqDTO>());
                UpdateUserPersonalInformationResDTO updateUserPersonalInformationResDTO = response.Data;
                response.Data = updateUserPersonalInformationResDTO.Adapt<UpdateUserPersonalInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("Update UserJobInformation")]
        public async Task<CommonResponse> UpdateUserJobInformation(UpdateUserJobInformationReqViewModel updateUserJobInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.UpdateUserJobInformation(updateUserJobInformationReqViewModel.Adapt<UpdateUserJobInformationReqDTO>());
                UpdateUserJobInformationResDTO updateUserJobInformationResDTO = response.Data;
                response.Data = updateUserJobInformationResDTO.Adapt<UpdateUserJobInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("Update UserBankAndSalaryInformation")]
        public async Task<CommonResponse> UpdateUserBankAndSalaryInformation(UpdateUserBankAndSalaryInformationReqViewModel updateUserBankAndSalaryInformationReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.UpdateUserBankAndSalaryInformation(updateUserBankAndSalaryInformationReqViewModel.Adapt<UpdateUserBankAndSalaryInformationReqDTO>());
                UpdateUserBankAndSalaryInformationResDTO updateUserBankAndSalaryInformationResDTO = response.Data;
                response.Data = updateUserBankAndSalaryInformationResDTO.Adapt<UpdateUserBankAndSalaryInformationResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpDelete("Delete User")]
        public async Task<CommonResponse> DeleteUser(DeleteUserReqViewModel deleteUserReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.DeleteUser(deleteUserReqViewModel.Adapt<DeleteUserReqDTO>());
                DeleteUserResDTO deleteUserResDTO = response.Data;
                response.Data = deleteUserResDTO.Adapt<DeleteUserResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("Add Resign")]
        public async Task<CommonResponse> AddResign(ResignReqViewModel resignReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iUser.AddResign(resignReqViewModel.Adapt<ResignReqDTO>());
                ResignResDTO resignResDTO = response.Data;
                response.Data = resignResDTO.Adapt<ResignResViewModel>();
            }
            catch { throw; }
            return response;
        }

    }
}
