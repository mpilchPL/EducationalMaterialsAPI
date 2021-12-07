using EducationalMaterialsAPI.Data.Repository.Users;
using EducationalMaterialsAPI.Model.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EducationalMaterialsAPI.Controllers.Authentication
{
    public class JwtAuth : IJwtAuth
    {
        private readonly string key;
        private readonly int _expiresIn = 24; // hrs
        public JwtAuth(string key)
        {
            this.key = key;
        }
        public async Task<string> Authentication(string username, string password, IUsersRepo usersRepo)
        {
            User? user = await GetUserAsync(username, password, usersRepo);
            if(user == null)
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
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.Role)
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

        private async Task<User> GetUserAsync(string username, string password, IUsersRepo usersRepo)
        {
            return await usersRepo.Get(username, password);
        }
    }
}
