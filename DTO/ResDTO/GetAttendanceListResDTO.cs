using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class GetAttendanceListResDTO
    {
        //[EnumDataType(typeof(AttendanceList))]
        //public AttendanceList attendanceName {get; set; }

        public string name {  get; set; }   
    }

    //public enum AttendanceList
    //{
    //    Present = 1,
    //    Absent = 2,
    //    HalfDay = 3
    //}
}
