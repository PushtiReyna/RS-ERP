using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ResDTO
{
    public class GetEmployeeResDTO
    {
        public int TotalCount { get; set; }
        public List<EmployeeeList> EmployeeeLists { get; set; }
    }
    public class EmployeeeList
    {
        public string? Image { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public bool? EmployeeStatus { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string RoleType { get; set; }
    }
}
