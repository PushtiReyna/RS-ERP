using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using ServiceLayer.CommonHelpers;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HolidayBLL
    {
        private readonly DBContext _dBContext;
        private readonly CommonRepo _commonRepo;
        public HolidayBLL(DBContext dBContext, CommonRepo commonRepo) 
        {
            _dBContext = dBContext;
            _commonRepo = commonRepo;
        }

        public async Task<CommonResponse> GetHolidayList()
        {
            CommonResponse response = new CommonResponse();
            try
            {
                GetHolidayResDTO getHolidayResDTO = new GetHolidayResDTO();
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddHoliday(AddHolidayReqDTO addHolidayReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {

            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> UpdateHoliday(UpdateHolidayReqDTO updateHolidayReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {

            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> DeleteHoliday(DeleteHolidayReqDTO deleteHolidayReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {

            }
            catch { throw; }
            return response;
        }
    }
}
