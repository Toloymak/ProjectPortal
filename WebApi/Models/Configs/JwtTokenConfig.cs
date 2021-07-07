using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Models.Configs
{
    public class JwtTokenConfig
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AccessTokenExpiration { get; set; }

        public SymmetricSecurityKey SymmetricSecurityKey =>
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
    }
}