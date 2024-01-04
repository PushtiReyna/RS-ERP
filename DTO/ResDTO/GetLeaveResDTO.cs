using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class GetLeaveResDTO
    {
        public int TotalCount { get; set; }
        public List<LeaveList> LeaveLists { get; set; }
    }
    public class LeaveList
    {
        public string? Image { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
        public int NumberOfDays { get; set; }
        public string LeaveReason { get; set; }
        public string? LeaveStatus { get; set; }
    }
}
