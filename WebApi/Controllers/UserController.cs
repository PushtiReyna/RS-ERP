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
    }
}
