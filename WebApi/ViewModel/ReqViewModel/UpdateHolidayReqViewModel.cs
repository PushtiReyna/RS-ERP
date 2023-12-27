namespace WebApi.ViewModel.ReqViewModel
{
    public class UpdateHolidayReqViewModel
    {
        public int HolidayId { get; set; }
        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Day { get; set; }
    }
}
