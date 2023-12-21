namespace WebApi.ViewModel.ResViewModel
{
    public class LoginResViewModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public DateTime TokenExpiryTime { get; set; }
    }
}
