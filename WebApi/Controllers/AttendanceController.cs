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

        [HttpGet("GetAttendanceList")]
        public async Task<CommonResponse> GetAttendanceList()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                response = await _iAttendance.GetAttendanceList();
               List<GetAttendanceListResDTO> lstGetLeaveResDTO = response.Data;
                response.Data = lstGetLeaveResDTO.Adapt<List <GetAttendanceListResViewModel>>();
            }
            catch { throw; }
            return response;
        }
    }
}
