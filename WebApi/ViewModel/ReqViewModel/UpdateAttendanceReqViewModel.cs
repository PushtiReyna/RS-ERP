using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel.ReqViewModel
{
    public class UpdateAttendanceReqViewModel
    {
        public int AttendanceId { get; set; }
        public int AttendanceTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
