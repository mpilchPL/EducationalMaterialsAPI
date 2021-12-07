using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EducationalMaterialsAPI.Controllers.Authentication
{
    public class JwtAuth : IJwtAuth
    {
        private readonly string[] _usernames = { "admin", "zenek", "gienek" };
        private readonly string _password = "123";
        private readonly string key;
        private readonly int _expiresIn = 24; // hrs
        public JwtAuth(string key)
        {
            this.key = key;
        }
        public string Authentication(string username, string password)
        {
            if (!_usernames.Contains(username) || !password.Equals(_password))
            {
                return null;
            }

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim(ClaimTypes.Role, username == "admin" ? "Admin" : "User")
                    }),
                Expires = DateTime.UtcNow.AddHours(_expiresIn),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
