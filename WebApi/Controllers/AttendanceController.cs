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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendance _iAttendance;
        public AttendanceController(IAttendance iAttendance)
        {
            _iAttendance = iAttendance;
        }

        [HttpGet("GetAttendanceTypeList")]
        public async Task<CommonResponse> GetAttendanceTypeList()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAttendance.GetAttendanceTypeList();
                List<GetAttendanceTypeListResDTO> lstGetAttendanceTypeResDTO = response.Data;
                response.Data = lstGetAttendanceTypeResDTO.Adapt<List<GetAttendanceTypeListResViewModel>>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("GetAttendanceListByMonth")]
        public async Task<CommonResponse> GetAttendanceListByMonth(GetAttendanceListByMonthReqViewModel getAttendanceListByMonthReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAttendance.GetAttendanceListByMonth(getAttendanceListByMonthReqViewModel.Adapt<GetAttendanceListByMonthReqDTO>());
                GetAttendanceListByMonthResDTO lstGetAttendanceListByMonthResDTO = response.Data;
                response.Data = lstGetAttendanceListByMonthResDTO.Adapt<GetAttendanceListByMonthResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPost("AddAttendance")]
        public async Task<CommonResponse> AddAttendance(AddAttendanceReqViewModel addAttendanceReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAttendance.AddAttendance(addAttendanceReqViewModel.Adapt<AddAttendanceReqDTO>());
                AddAttendanceResDTO addAttendanceResDTO = response.Data;
                response.Data = addAttendanceResDTO.Adapt<AddAttendanceResViewModel>();
            }
            catch { throw; }
            return response;
        }

        [HttpPut("UpdateAttendance")]
        public async Task<CommonResponse> UpdateAttendance(UpdateAttendanceReqViewModel addAttendanceReqViewModel)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAttendance.UpdateAttendance(addAttendanceReqViewModel.Adapt<UpdateAttendanceReqDTO>());
                UpdateAttendanceResDTO addAttendanceResDTO = response.Data;
                response.Data = addAttendanceResDTO.Adapt<UpdateAttendanceResViewModel>();
            }
            catch { throw; }
            return response;
        }

    }
}
