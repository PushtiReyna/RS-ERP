using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ReqDTO
{
    public class AddUserPersonalInformationReqDTO
    {
        public int EmployeeId { get; set; }
        public dynamic Image { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Gender { get; set; } = null!;

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
