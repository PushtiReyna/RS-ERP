using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel.ReqViewModel
{
    public class AddAttendanceReqViewModel
    {
        public int EmployeeId { get; set; }

        public int AttendanceTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
