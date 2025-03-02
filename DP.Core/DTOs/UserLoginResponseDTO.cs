namespace DP.Core.DTOs
{
    public class UserLoginResponseDTO
    {
        public string? UserId { get; set; }
        public bool IsEnabled { get; set; }
        public string Token { get; set; }
    }
}
