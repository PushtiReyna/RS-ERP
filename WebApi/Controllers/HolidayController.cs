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
    public class HolidayController : ControllerBase
    {
        private readonly IHoliday _iHoliday;

        public HolidayController(IHoliday iHoliday)
        {
            _iHoliday = iHoliday;
        }

        [HttpGet("Get HolidayList")]
        public async Task<CommonResponse> GetHolidayList()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iHoliday.GetHolidayList();
                List<GetHolidayResDTO> lstGetHolidayResDTO = response.Data;
                response.Data = lstGetHolidayResDTO.Adapt<List<GetHolidayResViewModel>>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("Add Holiday")]
        public async Task<CommonResponse> AddHoliday(AddHolidayReqViewModel addHolidayReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iHoliday.AddHoliday(addHolidayReqViewModel.Adapt<AddHolidayReqDTO>());
                AddHolidayResDTO addHolidayResDTO = response.Data;
                response.Data = addHolidayResDTO.Adapt<AddHolidayResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("Update Holiday")]
        public async Task<CommonResponse> UpdateHoliday(UpdateHolidayReqViewModel updateHolidayReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iHoliday.UpdateHoliday(updateHolidayReqViewModel.Adapt<UpdateHolidayReqDTO>());
                UpdateHolidayResDTO updateHolidayResDTO = response.Data;
                response.Data = updateHolidayResDTO.Adapt<UpdateHolidayResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpDelete("Delete Holiday")]
        public async Task<CommonResponse> DeleteHoliday(DeleteHolidayReqViewModel deleteHolidayReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iHoliday.DeleteHoliday(deleteHolidayReqViewModel.Adapt<DeleteHolidayReqDTO>());
                DeleteHolidayResDTO deleteHolidayResDTO = response.Data;
                response.Data = deleteHolidayResDTO.Adapt<DeleteHolidayResViewModel>();
            }
            catch { throw; }
            return response;
        }
    }
}
