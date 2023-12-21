using System.ComponentModel.DataAnnotations;

namespace WebApi.ViewModel.ReqViewModel
{
    public class ChangePasswordReqViewModel
    {
        public int EmployeeId { get; set; }
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New password and confirm password does not match")]
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
