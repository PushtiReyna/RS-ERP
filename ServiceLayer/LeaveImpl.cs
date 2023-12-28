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
    public class LeaveImpl : ILeave
    {
        private readonly LeaveBLL _leaveBLL;

        public LeaveImpl(LeaveBLL leaveBLL)
        {
            _leaveBLL = leaveBLL;
        }
        public async Task<CommonResponse> GetLeave(GetLeaveReqDTO getLeaveReqDTO) => await _leaveBLL.GetLeave(getLeaveReqDTO);
        public async Task<CommonResponse> AddLeave(AddLeaveReqDTO addLeaveReqDTO) => await _leaveBLL.AddLeave(addLeaveReqDTO);
        public async Task<CommonResponse> UpdateLeave(UpdateLeaveReqDTO updateLeaveReqDTO) => await _leaveBLL.UpdateLeave(updateLeaveReqDTO);
    }

    public interface ILeave
    {
        public Task<CommonResponse> GetLeave(GetLeaveReqDTO getLeaveReqDTO);
        public Task<CommonResponse> AddLeave(AddLeaveReqDTO addLeaveReqDTO);
        public Task<CommonResponse> UpdateLeave(UpdateLeaveReqDTO updateLeaveReqDTO);
    }
}
