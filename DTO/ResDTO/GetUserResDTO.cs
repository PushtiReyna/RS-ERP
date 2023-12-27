using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class GetUserResDTO
    {
        public List<UserList> userLists { get; set; }
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
