namespace WebApi.Models
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
        public AuthMetadata AuthTokenMetadata { get; set; }
    }
}