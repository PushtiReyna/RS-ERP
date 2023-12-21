namespace WebApi.ViewModel.ResViewModel
{
    public class TokenResViewModel
    {
        public string Token { get; set; } 
        public DateTime TokenExpiryTime { get; set; }
        public string RefreshToken { get; set; } 

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
