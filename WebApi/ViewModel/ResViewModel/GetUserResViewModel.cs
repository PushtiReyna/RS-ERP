namespace WebApi.ViewModel.ResViewModel
{
    public class GetUserResViewModel
    {
        public string? Image { get; set; }
        public int EmployeeId { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }

        public bool? EmployeeStatus { get; set; }
        public string RoleType { get; set; }
        public DateTime? JoiningDate { get; set; }
    }
}
