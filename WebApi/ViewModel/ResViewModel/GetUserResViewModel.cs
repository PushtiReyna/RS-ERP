namespace WebApi.ViewModel.ResViewModel
{
    public class GetUserResViewModel
    {
        public int TotalCount { get; set; }
        public List<UserList> UserLists { get; set; }
    }

    public class UserList
    {
        public string? Image { get; set; }
        public int EmployeeId { get; set; }
        public string? FullName { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }

        public bool? EmployeeStatus { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string RoleType { get; set; }

    }
}
