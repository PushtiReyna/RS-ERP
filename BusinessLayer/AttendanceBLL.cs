using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
using Helper.CommonModels;
using Mapster;
using Mapster.Utils;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.CommonHelpers;
using ServiceLayer.CommonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using AttendanceList = Helper.CommonModels.AttendanceList;
//using AttendanceList = Helper.CommonModels.AttendanceList;

namespace BusinessLayer
{
    public class AttendanceBLL
    {
        //public readonly AttendanceList _attendanceList;
        //public AttendanceBLL(AttendanceList attendanceList)
        //{ 
        //    _attendanceList = attendanceList;
        //}

        private readonly CommonRepo _commonRepo;
        private readonly DBContext _dbContext;
        public AttendanceBLL(CommonRepo commonRepo, DBContext dbContext)
        {
            _commonRepo = commonRepo;
            _dbContext = dbContext;
        }

        public async Task<CommonResponse> GetAttendanceTypeList()
        {

            //var getAttendanceListResDTO = Enum.GetValues(typeof(AttendanceList)).Cast<AttendanceList>().ToList();

            CommonResponse response = new CommonResponse();
            try
            {
                GetAttendanceTypeListResDTO getAttendanceTypeListResDTO = new GetAttendanceTypeListResDTO();

                List<GetAttendanceTypeListResDTO> lstGetAttendanceTypeListResDTO = _commonRepo.AttendanceTypeMstsList().ToList().Adapt<List<GetAttendanceTypeListResDTO>>();
                if (lstGetAttendanceTypeListResDTO.Count > 0)
                {
                    response.Data = lstGetAttendanceTypeListResDTO;
                    response.Message = "data found successfully!";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "data not found successfully!";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> GetAttendanceListByMonth(GetAttendanceListByMonthReqDTO getAttendanceListByMonthReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {       
                GetAttendanceListByMonthResDTO getAttendanceListByMonthResDTO = new GetAttendanceListByMonthResDTO();

                List<GetAttendanceListByMonthResDTO> lstGetAttendanceListByMonthResDTO = (from attendancedetail in _commonRepo.AttendanceMstsList().Where(x => x.Date.Month == getAttendanceListByMonthReqDTO.Date.Month)
                                    join employeeDetail in _commonRepo.EmployeeMstList()
                                           on attendancedetail.EmployeeId equals employeeDetail.EmployeeId
                                    select new GetAttendanceListByMonthResDTO
                                    {
                                        DayNoOfMonth = attendancedetail.DayNoOfMonth,
                                        AttendanceTypeName = attendancedetail.AttendanceTypeName,
                                        Image = employeeDetail.Image,
                                        Name = employeeDetail.FirstName + " " + employeeDetail.MiddleName + " " + employeeDetail.LastName
                                    }).ToList().Adapt<List<GetAttendanceListByMonthResDTO>>();

                if(lstGetAttendanceListByMonthResDTO.Count > 0 )
                {
                    response.Data = lstGetAttendanceListByMonthResDTO;
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

        public async Task<CommonResponse> AddAttendance(AddAttendanceReqDTO addAttendanceReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {               
                AttendanceMst attendanceMst = new AttendanceMst();
                AddAttendanceResDTO attendanceResDTO = new AddAttendanceResDTO();

                var attendanceList = _commonRepo.AttendanceMstsList().FirstOrDefault(x => x.Date == addAttendanceReqDTO.Date && x.EmployeeId == addAttendanceReqDTO.EmployeeId);
                if (attendanceList == null)
                {
                    var employeeDetail = _commonRepo.EmployeeMstList().FirstOrDefault(x => x.EmployeeId == addAttendanceReqDTO.EmployeeId);
                    var attendanceTypeDetail = await _commonRepo.AttendanceTypeMstsList().FirstOrDefaultAsync(x => x.AttendanceTypeId == addAttendanceReqDTO.AttendanceTypeId);
                    if (employeeDetail != null && attendanceTypeDetail != null)
                    {
                        attendanceMst.EmployeeId = employeeDetail.EmployeeId;
                        attendanceMst.AttendanceTypeName = attendanceTypeDetail.AttendanceTypeName;
                        attendanceMst.Date = addAttendanceReqDTO.Date;
                        attendanceMst.Year = addAttendanceReqDTO.Date.Year;
                        attendanceMst.Month = addAttendanceReqDTO.Date.Month;
                        attendanceMst.DayNoOfMonth = addAttendanceReqDTO.Date.ToString("dd"); // DateTime.DaysInMonth(attendanceMst.Year, attendanceMst.Month);
                        attendanceMst.IsActive = true;
                        attendanceMst.IsDelete = false;
                        attendanceMst.CreatedBy = 1;
                        attendanceMst.CreatedDate = DateTime.Now;

                        _dbContext.AttendanceMsts.Add(attendanceMst);
                        _dbContext.SaveChanges();

                        attendanceResDTO.AttendanceId = attendanceMst.AttendanceId;
                        attendanceResDTO.AttendanceTypeName = attendanceMst.AttendanceTypeName;
                        response.Data = attendanceResDTO;
                        response.Status = true;
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                        response.Message = "attendance add succesfully!";
                    }
                    else
                    {
                        response.Status = true;
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        response.Message = "data are not valid!";
                    }
                }
                else
                {
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    response.Message = "attendance already added!";
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> UpdateAttendance(UpdateAttendanceReqDTO updateAttendanceReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateAttendanceResDTO updateAttendanceResDTO = new UpdateAttendanceResDTO();
                var attendanceDetail = _commonRepo.AttendanceMstsList().FirstOrDefault(x => x.AttendanceId ==  updateAttendanceReqDTO.AttendanceId);

                if (attendanceDetail != null)
                {
                    var attendanceList = _commonRepo.AttendanceMstsList().FirstOrDefault(x => x.Date == updateAttendanceReqDTO.Date && x.AttendanceId != updateAttendanceReqDTO.AttendanceId && x.EmployeeId == attendanceDetail.EmployeeId);

                    var attendanceTypeDetail = await _commonRepo.AttendanceTypeMstsList().FirstOrDefaultAsync(x => x.AttendanceTypeId == updateAttendanceReqDTO.AttendanceTypeId);

                    if (attendanceList == null && attendanceTypeDetail != null)
                    {
                        attendanceDetail.Date = updateAttendanceReqDTO.Date;
                        attendanceDetail.Year = updateAttendanceReqDTO.Date.Year;
                        attendanceDetail.Month = updateAttendanceReqDTO.Date.Month;
                        attendanceDetail.DayNoOfMonth = updateAttendanceReqDTO.Date.ToString("dd");
                        attendanceDetail.AttendanceTypeName = attendanceTypeDetail.AttendanceTypeName;
                        attendanceDetail.UpdatedBy = 1;
                        attendanceDetail.UpdatedDate = DateTime.Now;

                        _dbContext.Entry(attendanceDetail).State = EntityState.Modified;
                        _dbContext.SaveChanges();

                        updateAttendanceResDTO.AttendanceId = attendanceDetail.AttendanceId;
                        response.Data = updateAttendanceResDTO;
                        response.Message = "updated successfully!";
                        response.Status = true;
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else
                    {
                        response.Message = "data are invalid";
                        response.Status = false;
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                    }
                }
                else
                {
                    response.Message = "data are invalid ";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
