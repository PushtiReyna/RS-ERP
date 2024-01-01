using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel.ReqViewModel
{
    public class UpdateLeaveReqViewModel
    {
        public int LeaveId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LeaveFrom { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LeaveTo { get; set; }

        public int NumberOfDays { get; set; }

        public int RemainingLeaves { get; set; }

        public string LeaveReason { get; set; }
        //public string? LeaveStatus { get; set; }
    }
}
