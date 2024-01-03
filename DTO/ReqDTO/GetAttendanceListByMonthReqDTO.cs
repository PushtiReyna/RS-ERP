using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class GetAttendanceListByMonthReqDTO
    {
        public int Page { get; set; }

        public int ItemsPerPage { get; set; }

        public bool OrderBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
