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
    public class LeaveController : ControllerBase
    {
        private readonly ILeave _iLeave;

        public LeaveController(ILeave iLeave)
        {
            _iLeave = iLeave;
        }

        [HttpPost("Get Leave")]
        public async Task<CommonResponse> GetLeave(GetLeaveReqViewModel getLeaveReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iLeave.GetLeave(getLeaveReqViewModel.Adapt<GetLeaveReqDTO>());
                GetLeaveResDTO lstGetLeaveResDTO = response.Data;
                response.Data = lstGetLeaveResDTO.Adapt<GetLeaveResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("Add Leave")]
        public async Task<CommonResponse> AddLeave(AddLeaveReqViewModel addLeaveReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iLeave.AddLeave(addLeaveReqViewModel.Adapt<AddLeaveReqDTO>());
                AddLeaveResDTO addLeaveResDTO = response.Data;
                response.Data = addLeaveResDTO.Adapt<AddLeaveResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("Update Leave")]
        public async Task<CommonResponse> UpdateLeave(UpdateLeaveReqViewModel updateLeaveReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iLeave.UpdateLeave(updateLeaveReqViewModel.Adapt<UpdateLeaveReqDTO>());
                UpdateLeaveResDTO updateLeaveResDTO = response.Data;
                response.Data = updateLeaveResDTO.Adapt<UpdateLeaveResViewModel>();
            }
            catch { throw; }
            return response;
        }
    }
}
