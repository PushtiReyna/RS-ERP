using BusinessLayer;
using DTO.ReqDTO;
using DTO.ResDTO;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class HolidayImpl : IHoliday
    {
        private readonly HolidayBLL _holidayBLL;
        public HolidayImpl(HolidayBLL holidayBLL)
        { 
            _holidayBLL = holidayBLL;
        }

        public async Task<CommonResponse> GetHolidayList() => await _holidayBLL.GetHolidayList();
        public async Task<CommonResponse> AddHoliday(AddHolidayReqDTO addHolidayReqDTO) => await _holidayBLL.AddHoliday(addHolidayReqDTO);
        public async Task<CommonResponse> UpdateHoliday(UpdateHolidayReqDTO updateHolidayReqDTO) => await _holidayBLL.UpdateHoliday(updateHolidayReqDTO);
        public async Task<CommonResponse> DeleteHoliday(DeleteHolidayReqDTO deleteHolidayReqDTO) => await _holidayBLL.DeleteHoliday(deleteHolidayReqDTO);

    }

    public interface IHoliday
    {
        public Task<CommonResponse> GetHolidayList();
        public Task<CommonResponse> AddHoliday(AddHolidayReqDTO addHolidayReqDTO);
        public Task<CommonResponse> UpdateHoliday(UpdateHolidayReqDTO updateHolidayReqDTO);
        public Task<CommonResponse> DeleteHoliday(DeleteHolidayReqDTO deleteHolidayReqDTO);
    }
}
