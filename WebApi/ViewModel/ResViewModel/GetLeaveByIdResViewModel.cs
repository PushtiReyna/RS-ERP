namespace WebApi.ViewModel.ResViewModel
{
    public class GetLeaveByIdResViewModel
    {
        public string Image { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime LeaveFrom { get; set; }

        public DateTime LeaveTo { get; set; }

        public int NumberOfDays { get; set; }

        public string LeaveReason { get; set; }

        public string LeaveStatus { get; set; }
    }
}
