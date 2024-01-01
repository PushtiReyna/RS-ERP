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

        [HttpPost("GetLeave")]
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

        [HttpPost("GetLeaveById")]
        public async Task<CommonResponse> GetLeaveById(GetLeaveByIdReqViewModel getLeaveByIdReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iLeave.GetLeaveById(getLeaveByIdReqViewModel.Adapt<GetLeaveByIdReqDTO>());
                GetLeaveByIdResDTO lstGetLeaveByIdResDTO = response.Data;
                response.Data = lstGetLeaveByIdResDTO.Adapt<GetLeaveByIdResViewModel>();
            }
            catch { throw; }
            return response;
        }


        [HttpPost("AddLeave")]
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

        [HttpPut("UpdateLeave")]
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

        [HttpDelete("DeleteLeave")]
        public async Task<CommonResponse> DeleteLeave(DeleteLeaveReqViewModel deleteLeaveReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iLeave.DeleteLeave(deleteLeaveReqViewModel.Adapt<DeleteLeaveReqDTO>());
                DeleteLeaveResDTO deleteLeaveResDTO = response.Data;
                response.Data = deleteLeaveResDTO.Adapt<DeleteLeaveResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("UpdateLeaveStatus")]
        public async Task<CommonResponse> UpdateLeaveStatus(UpdateLeaveStatusReqViewModel updateLeaveStatusReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iLeave.UpdateLeaveStatus(updateLeaveStatusReqViewModel.Adapt<UpdateLeaveStatusReqDTO>());
                UpdateLeaveStatusResDTO updateLeaveStatusResDTO = response.Data;
                response.Data = updateLeaveStatusResDTO.Adapt<UpdateLeaveStatusResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpGet("SelectStatusList")]
        public async Task<CommonResponse> SelectStatusList()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iLeave.SelectStatusList();
               List<SelectStatusListResDTO> lstSelectStatusListResDTO = response.Data;
                response.Data = lstSelectStatusListResDTO.Adapt<List<SelectStatusListResViewModel>>();
            }
            catch { throw; }
            return response;
        }
    }
}
