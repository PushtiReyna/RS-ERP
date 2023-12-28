using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class AddLeaveReqDTO
    {
        public int EmployeeId { get; set; }

        public DateTime LeaveFrom { get; set; }

        public DateTime LeaveTo { get; set; }

        public int NumberOfDays { get; set; }

        public int RemainingLeaves { get; set; }

        public string LeaveReason { get; set; }
    }
}
