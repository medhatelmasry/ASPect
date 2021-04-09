namespace BlazorClient.Shared.Models
{
    public class JwtToken
    {
        public string token { get; set; }
        public string expiration { get; set; }
    }
}