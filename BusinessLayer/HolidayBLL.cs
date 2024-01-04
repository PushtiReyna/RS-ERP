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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLayer
{
    public class HolidayBLL
    {
        private readonly DBContext _dbContext;
        private readonly CommonRepo _commonRepo;
        private readonly CommonHelper _commonHelper;
        public HolidayBLL(DBContext dbContext, CommonRepo commonRepo, CommonHelper commonHelper)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
            _commonHelper = commonHelper;
        }

        public async Task<CommonResponse> GetHolidayList(GetHolidayListReqDTO getHolidayListReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                GetHolidayListResDTO getHolidayListResDTO = new GetHolidayListResDTO();

                List<HolidayList> lstHolidayList = new List<HolidayList>();

                lstHolidayList = await (from attendanceDetail in _commonRepo.HolidayMstsList()
                                  select new HolidayList
                                  {
                                      HolidayId = attendanceDetail.HolidayId,
                                      Name = attendanceDetail.Name,
                                      Date = attendanceDetail.Date,
                                      Day = attendanceDetail.Day,
                                  }).ToListAsync();

                if (getHolidayListReqDTO.SearchString != null && !string.IsNullOrWhiteSpace(getHolidayListReqDTO.SearchString.Trim()))
                {
                    lstHolidayList = lstHolidayList.Where(x => x.Name.ToLower().Contains(getHolidayListReqDTO.SearchString.ToLower())).ToList();
                    getHolidayListResDTO.TotalCount = lstHolidayList.Count;
                }
                else
                {
                    getHolidayListResDTO.TotalCount = lstHolidayList.Count;
                }

                if (getHolidayListReqDTO.OrderBy == true) 
                {
                    getHolidayListResDTO.HolidayLists = lstHolidayList.OrderBy(x => x.Date)
                                                                      .Skip((getHolidayListReqDTO.Page - 1) * getHolidayListReqDTO.ItemsPerPage)
                                                                      .Take(getHolidayListReqDTO.ItemsPerPage).ToList();
                }
                else
                {
                    getHolidayListResDTO.HolidayLists = lstHolidayList.OrderByDescending(x => x.Date)
                                                                      .Skip((getHolidayListReqDTO.Page - 1) * getHolidayListReqDTO.ItemsPerPage)
                                                                      .Take(getHolidayListReqDTO.ItemsPerPage).ToList();
                }

                if (lstHolidayList.Count > 0)
                {                   
                    response.Data = getHolidayListResDTO;
                    response.Message = "data found successfully!";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "data not found";
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

                if (addHolidayReqDTO.Name.Trim() != null && !string.IsNullOrWhiteSpace(addHolidayReqDTO.Name.Trim()))
                {
                    bool isExist = await _commonRepo.HolidayMstsList().AnyAsync(x => x.Name.Trim().ToLower() == addHolidayReqDTO.Name.Trim().ToLower());
                    if (isExist == false)
                    {
                        holidaysMst.Name = addHolidayReqDTO.Name;
                        holidaysMst.Date = addHolidayReqDTO.Date;
                        holidaysMst.Day = addHolidayReqDTO.Date.DayOfWeek.ToString();
                        holidaysMst.IsActive = true;
                        holidaysMst.IsDelete = false;
                        holidaysMst.CreatedBy = 1;
                        holidaysMst.CreatedDate = _commonHelper.GetCurrentDateTime();

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

                if (updateHolidayReqDTO.Name.Trim() != null && !string.IsNullOrWhiteSpace(updateHolidayReqDTO.Name.Trim()))
                {
                    var holidayDetail = await _commonRepo.HolidayMstsList().FirstOrDefaultAsync(x => x.HolidayId == updateHolidayReqDTO.HolidayId);
                    if (holidayDetail != null)
                    {
                        if (_commonRepo.HolidayMstsList().FirstOrDefault(x => x.Name.Trim().ToLower() == updateHolidayReqDTO.Name.Trim().ToLower() && x.HolidayId != updateHolidayReqDTO.HolidayId) != null)
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
                            holidayDetail.UpdatedDate = _commonHelper.GetCurrentDateTime();

                            _dbContext.Entry(holidayDetail).State = EntityState.Modified;
                            _dbContext.SaveChanges();

                            updateHolidayResDTO.HolidayId = holidayDetail.HolidayId;
                            response.Data = updateHolidayResDTO;
                            response.Status = true;
                            response.Message = "Holiday Name updated successfully";
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
                    holidayDetail.UpdatedDate = _commonHelper.GetCurrentDateTime();
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
