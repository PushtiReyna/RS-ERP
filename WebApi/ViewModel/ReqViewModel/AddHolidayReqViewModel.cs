using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel.ReqViewModel
{
    public class AddHolidayReqViewModel
    {
        public string Name { get; set; } = null!;

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

    }
}
