namespace WebApi.ViewModel.ResViewModel
{
    public class GetUserByIdPersonalInformationResViewModel
    {
        public int EmployeeId { get; set; }

        public dynamic Image { get; set; }

        public string? FirstName { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? ContactNumber { get; set; }

        public string EmergencyContactName { get; set; }

        public string EmergencyContactNo { get; set; }

        public string? Password { get; set; }

        public string MartialStatus { get; set; }

        public string PermanentAddress { get; set; }

        public string PermanentAddressPostalCode { get; set; }

        public string CurrentAddress { get; set; }

        public string CurrentAddressPostalCode { get; set; }
    }
}

