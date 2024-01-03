namespace WebApi.ViewModel.ResViewModel
{
    public class GetHolidayListResViewModel
    {
        public int TotalCount { get; set; }
        public List<HolidayList> HolidayLists { get; set; }
    }
    public class HolidayList
    {
        public int HolidayId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime Date { get; set; }

        public string Day { get; set; }
    }
}
