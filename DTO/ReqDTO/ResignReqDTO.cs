using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class ResignReqDTO
    {
        public int EmployeeId { get; set; }

        public DateTime DateOfResignation { get; set; }

        public int AttritionId { get; set; }

        public string? Reason { get; set; }

        public string? Region { get; set; }

        public DateTime? FinalDate { get; set; }

        public string? FinalStatus { get; set; }
    }
}
