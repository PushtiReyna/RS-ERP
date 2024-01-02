using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel.ReqViewModel
{
    public class GetAttendanceListByMonthReqViewModel
    {
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
