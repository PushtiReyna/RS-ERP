using ServiceLayer;
using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel.ReqViewModel
{
    public class AddLeaveReqViewModel
    {

        public int EmployeeId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LeaveFrom { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime LeaveTo { get; set; }

        public int NumberOfDays { get; set; }

        public int RemainingLeaves { get; set; }

        public string LeaveReason { get; set; }
    }
}
