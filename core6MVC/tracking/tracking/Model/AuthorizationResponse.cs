namespace tracking.Model
{
    public class AuthorizationResponse
    {
        public string AccessToken { get; set; }
        public string? Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
