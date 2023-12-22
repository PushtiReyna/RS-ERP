using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel.ReqViewModel
{
    public class AddUserPersonalInformationReqViewModel
    {
        public int EmployeeId { get; set; }
        public IFormFile Image { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Gender { get; set; } = null!;

        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        public string EmergencyContactName { get; set; } = null!;

        public string EmergencyContactNo { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string MartialStatus { get; set; } = null!;

        public string PermanentAddress { get; set; } = null!;

        public string? PermanentAddressPostalCode { get; set; }

        public string CurrentAddress { get; set; } = null!;

        public string? CurrentAddressPostalCode { get; set; }
    }
}
