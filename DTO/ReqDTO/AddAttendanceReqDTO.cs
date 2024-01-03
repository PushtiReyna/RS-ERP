using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class AddAttendanceReqDTO
    {
        public int EmployeeId { get; set; }
        public int AttendanceTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
