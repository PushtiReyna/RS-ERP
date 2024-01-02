using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class GetAttendanceListByMonthResDTO
    {
        public string? Image { get; set; }
        public string Name { get; set; }
        public string DayNoOfMonth { get; set; }
        public string AttendanceTypeName { get; set; }
    }
}
