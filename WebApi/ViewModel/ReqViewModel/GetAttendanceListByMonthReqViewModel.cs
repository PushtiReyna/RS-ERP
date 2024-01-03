using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel.ReqViewModel
{
    public class GetAttendanceListByMonthReqViewModel
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public bool OrderBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
