using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Mapster;
using Microsoft.EntityFrameworkCore;
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
        private readonly DBContext _dbContext;
        private readonly CommonRepo _commonRepo;
        public HolidayBLL(DBContext dbContext, CommonRepo commonRepo)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
        }

        public async Task<CommonResponse> GetHolidayList()
        {
            CommonResponse response = new CommonResponse();
            try
            {
               
                List<GetHolidayResDTO> lstGetHolidayResDTO = _commonRepo.HolidayMstsList().ToList().Adapt<List<GetHolidayResDTO>>();

                if (lstGetHolidayResDTO.Count > 0)
                {
                   
                    response.Data = lstGetHolidayResDTO;
                    response.Message = "Holiday list data are found";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "Holiday list  data not found";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddHoliday(AddHolidayReqDTO addHolidayReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                HolidaysMst holidaysMst = new HolidaysMst();
                AddHolidayResDTO addHolidayResDTO = new AddHolidayResDTO();

                if (!string.IsNullOrWhiteSpace(addHolidayReqDTO.Name))
                {
                    var holidayDetail = await _commonRepo.HolidayMstsList().FirstOrDefaultAsync(x => x.Name.Trim() == addHolidayReqDTO.Name.Trim());
                    if (holidayDetail == null)
                    {
                        holidaysMst.Name = addHolidayReqDTO.Name;
                        holidaysMst.Date = addHolidayReqDTO.Date;
                        holidaysMst.Day = addHolidayReqDTO.Date.DayOfWeek.ToString();
                        holidaysMst.IsActive = true;
                        holidaysMst.IsDelete = false;
                        holidaysMst.CreatedBy = 1;
                        holidaysMst.CreatedDate = DateTime.Now;

                        _dbContext.HolidaysMsts.Add(holidaysMst);
                        _dbContext.SaveChanges();

                        addHolidayResDTO.HolidayId = holidaysMst.HolidayId;
                        response.Data = addHolidayResDTO;
                        response.Status = true;
                        response.Message = "Holiday Name added successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;

                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Holiday Name already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "Holiday Name can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> UpdateHoliday(UpdateHolidayReqDTO updateHolidayReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateHolidayResDTO updateHolidayResDTO = new UpdateHolidayResDTO();

                if (!string.IsNullOrWhiteSpace(updateHolidayReqDTO.Name))
                {
                    var holidayDetail = await _commonRepo.HolidayMstsList().FirstOrDefaultAsync(x => x.HolidayId == updateHolidayReqDTO.HolidayId);
                    if (holidayDetail != null)
                    {
                        if (_commonRepo.HolidayMstsList().FirstOrDefault(x => x.Name.Trim() == updateHolidayReqDTO.Name.Trim() && x.HolidayId != updateHolidayReqDTO.HolidayId) != null)
                        {
                            response.Message = "Holiday name already exists";
                            response.Status = false;
                            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        }
                        else
                        {
                            holidayDetail.Name = updateHolidayReqDTO.Name;
                            holidayDetail.Date = updateHolidayReqDTO.Date;
                            holidayDetail.Day = updateHolidayReqDTO.Date.DayOfWeek.ToString();
                            holidayDetail.UpdatedBy = 1;
                            holidayDetail.UpdatedDate = DateTime.Now;

                            _dbContext.Entry(holidayDetail).State = EntityState.Modified;
                            _dbContext.SaveChanges();

                            updateHolidayResDTO.HolidayId = holidayDetail.HolidayId;
                            response.Data = updateHolidayResDTO;
                            response.Status = true;
                            response.Message = "Holiday Name added successfully";
                            response.StatusCode = System.Net.HttpStatusCode.OK;
                        }
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Holiday Name already exists";
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "Holiday Name can not be null";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
        public async Task<CommonResponse> DeleteHoliday(DeleteHolidayReqDTO deleteHolidayReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                DeleteHolidayResDTO deleteHolidayResDTO = new DeleteHolidayResDTO();
                var holidayDetail = await _commonRepo.HolidayMstsList().FirstOrDefaultAsync(x => x.HolidayId == deleteHolidayReqDTO.HolidayId);

                if (holidayDetail != null)
                {
                    holidayDetail.IsDelete = true;
                    holidayDetail.UpdatedBy = 1;
                    holidayDetail.UpdatedDate = DateTime.Now;
                    _dbContext.Entry(holidayDetail).State = EntityState.Modified;
                    _dbContext.SaveChanges();

                    deleteHolidayResDTO.HolidayId = holidayDetail.HolidayId;
                    response.Data = deleteHolidayResDTO;
                    response.Message = "Holiday deleted successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Status = false;
                    response.Message = "holiday not exists";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
