using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class GetHolidayResDTO
    {
        public int HolidayId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Day { get; set; }
    }
}
