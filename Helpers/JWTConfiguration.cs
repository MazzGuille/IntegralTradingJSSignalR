using IntegralTradingJS.Models;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegralTradingJS.Helpers
{
    public class JWTConfiguration
    {
        User user = new();
        private string _secretKey;
        IConfiguration config; 
        

        public string token(Login request)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();

            _secretKey = builder.GetSection("settings").GetSection("secretkey").ToString();
            var keyBytes = Encoding.ASCII.GetBytes(_secretKey);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.Id.ToString()));
            claims.AddClaim(new Claim(ClaimTypes.Email, request.Email));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokencreado = tokenHandler.WriteToken(tokenConfig);

            return tokencreado;         
        }

        public JwtSecurityToken Verify(string jwt)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json").Build();

            _secretKey = builder.GetSection("settings").GetSection("secretkey").ToString();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);

            tokenHandler.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false
            },
            out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken; //HAY QUE USAR CASTING YA QUE validatedToken ES UN string Y NECESITAMOS UN TIPO "JwtSecurityToken"
        }
    }
}
