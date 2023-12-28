using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class UpdateHolidayReqDTO
    {
        public int HolidayId { get; set; }
        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }

    }
}
