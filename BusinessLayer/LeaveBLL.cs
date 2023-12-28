using DataLayer.Entities;
using DTO.ReqDTO;
using DTO.ResDTO;
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
    public class LeaveBLL
    {
        private readonly DBContext _dbContext;
        private readonly CommonRepo _commonRepo;
        public LeaveBLL(DBContext dbContext, CommonRepo commonRepo)
        {
            _dbContext = dbContext;
            _commonRepo = commonRepo;
        }
        public async Task<CommonResponse> GetLeave(GetLeaveReqDTO getLeaveReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                LeaveList leaveList = new LeaveList();
                List<LeaveList> lstLeaveList = new List<LeaveList>();
                GetLeaveResDTO getLeaveResDTO = new GetLeaveResDTO();

                foreach (LeaveMst leaveMst in _commonRepo.LeaveMstsList().ToList())
                {
                    leaveList = new LeaveList();
                    var userDetail = _commonRepo.UserMstList().FirstOrDefault(x => x.EmployeeId == leaveMst.EmployeeId);

                    if (userDetail != null)
                    {
                        leaveList.FullName = userDetail.FirstName + " " + userDetail.MiddleName + " " + userDetail.LastName;
                        leaveList.Image = userDetail.Image;
                        leaveList.Email = userDetail.Email;
                        leaveList.LeaveFrom = leaveMst.LeaveFrom;
                        leaveList.LeaveTo = leaveMst.LeaveTo;
                        leaveList.NumberOfDays = leaveMst.NumberOfDays;
                        leaveList.LeaveReason = leaveMst.LeaveReason;
                        leaveList.LeaveStatus = leaveMst.LeaveStatus;

                        lstLeaveList.Add(leaveList);

                    }
                    else
                    {
                        response.Message = "users data not found";
                        response.Status = false;
                        response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        return response;
                    }   
                }

                getLeaveResDTO.TotalCount = lstLeaveList.Count;
                getLeaveResDTO.LeaveLists = lstLeaveList.OrderBy(x => x.FullName)
                                                         .Skip((getLeaveReqDTO.Page - 1) * getLeaveReqDTO.ItemsPerPage)
                                                          .Take(getLeaveReqDTO.ItemsPerPage).ToList(); ;

                if(lstLeaveList.Count > 0)
                {
                   
                   
                    response.Data = getLeaveResDTO;
                    response.Message = "list of leaves get successfully";
                    response.Status = true;
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
                else
                {
                    response.Message = "leaves data not found";
                    response.Status = false;
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> AddLeave(AddLeaveReqDTO addLeaveReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                LeaveMst leaveMst = new LeaveMst();
                AddLeaveResDTO addLeaveResDTO = new AddLeaveResDTO();

                var userDetail = await _commonRepo.UserMstList().FirstOrDefaultAsync(x => x.EmployeeId == addLeaveReqDTO.EmployeeId);

                var leaveList = await _commonRepo.LeaveMstsList().Where(x => x.EmployeeId == addLeaveReqDTO.EmployeeId && x.LeaveFrom == addLeaveReqDTO.LeaveFrom).ToListAsync();

                if (leaveList.Count <= 0)
                {
                    if (userDetail != null)
                    {
                        if (addLeaveReqDTO.LeaveTo >= addLeaveReqDTO.LeaveFrom)
                        {
                            leaveMst.LeaveFrom = addLeaveReqDTO.LeaveFrom;
                            leaveMst.LeaveTo = addLeaveReqDTO.LeaveTo;
                            leaveMst.LeaveReason = addLeaveReqDTO.LeaveReason;
                            leaveMst.RemainingLeaves = addLeaveReqDTO.RemainingLeaves;
                            leaveMst.NumberOfDays = addLeaveReqDTO.NumberOfDays;
                            leaveMst.EmployeeId = userDetail.EmployeeId;
                            leaveMst.CreatedBy = 1;
                            leaveMst.CreatedDate = DateTime.Now;
                            leaveMst.IsActive = true;
                            leaveMst.IsDelete = false;

                            _dbContext.LeaveMsts.Add(leaveMst);
                            _dbContext.SaveChanges();

                            addLeaveResDTO.EmployeeId = leaveMst.EmployeeId;
                            response.Data = addLeaveResDTO;
                            response.Status = true;
                            response.Message = "leave added successfully";
                            response.StatusCode = System.Net.HttpStatusCode.OK;
                        }
                        else
                        {
                            response.Status = false;
                            response.Message = "leave to value not correct";
                            response.StatusCode = System.Net.HttpStatusCode.OK;
                        }
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "user data not found";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "already leave added ";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
            }
            catch { throw; }
            return response;
        }

        public async Task<CommonResponse> UpdateLeave(UpdateLeaveReqDTO updateLeaveReqDTO)
        {
            CommonResponse response = new CommonResponse();
            try
            {
                UpdateLeaveResDTO updateLeaveResDTO = new UpdateLeaveResDTO();
                var leaveDetail = await _commonRepo.LeaveMstsList().FirstOrDefaultAsync(x => x.LeaveId == updateLeaveReqDTO.LeaveId);

                if (leaveDetail != null)
                {
                    if (_commonRepo.LeaveMstsList().FirstOrDefault(x => x.LeaveFrom == updateLeaveReqDTO.LeaveFrom && x.LeaveId != updateLeaveReqDTO.LeaveId) != null)
                    {
                        response.Status = false;
                        response.Message = "already data exist";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                    else if (updateLeaveReqDTO.LeaveTo >= updateLeaveReqDTO.LeaveFrom)
                    {
                        leaveDetail.RemainingLeaves = updateLeaveReqDTO.RemainingLeaves;
                        leaveDetail.LeaveTo = updateLeaveReqDTO.LeaveTo;
                        leaveDetail.LeaveFrom = updateLeaveReqDTO.LeaveFrom;
                        leaveDetail.LeaveReason = updateLeaveReqDTO.LeaveReason;
                        leaveDetail.LeaveStatus = updateLeaveReqDTO.LeaveStatus;
                        leaveDetail.NumberOfDays = updateLeaveReqDTO.NumberOfDays;
                        leaveDetail.UpdatedBy = 1;
                        leaveDetail.UpdatedDate = DateTime.Now;

                        _dbContext.Entry(leaveDetail).State = EntityState.Modified;
                        _dbContext.SaveChanges();

                        updateLeaveResDTO.EmployeeId = leaveDetail.EmployeeId;
                        response.Data = updateLeaveResDTO;
                        response.Status = true;
                        response.Message = "leave updated successfully";
                        response.StatusCode = System.Net.HttpStatusCode.OK;

                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "leave to value not correct";
                        response.StatusCode = System.Net.HttpStatusCode.OK;
                    }
                }
                else
                {
                    response.Status = false;
                    response.Message = "leave data not found";
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                }
            }
            catch { throw; }
            return response;
        }
    }
}
