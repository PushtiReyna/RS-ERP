namespace WebApi.ViewModel.ResViewModel
{
    public class GetAttendanceListByMonthResViewModel
    {
        public int TotalCount { get; set; }
        public List<AttendanceList> AttendanceLists { get; set; }
    }
    public class AttendanceList
    {
        public string? Image { get; set; }
        public string Name { get; set; }
        public string DayNoOfMonth { get; set; }
        public string AttendanceTypeName { get; set; }
    }
}
