using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class GetAttendanceTypeListResDTO
    {
        public int AttendanceTypeId { get; set; }
        public string AttendanceTypeName { get; set; }
    }
}
