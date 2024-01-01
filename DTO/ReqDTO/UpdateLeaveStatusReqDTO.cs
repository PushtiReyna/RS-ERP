using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class UpdateLeaveStatusReqDTO
    {
        public int LeaveId { get; set; }
        public int LeaveStatusId { get; set; }
    }
}
