using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace codeFirstApproach.helpers
{
    public class AuthHelpers
    {
        
        public  string GenerateJWTToken(int userid,string name,string role)
        {
            //your logic for login process
            //If login usrename and password are correct then proceed to generate token
            var claims = new List<Claim> {
                    new Claim(ClaimTypes.NameIdentifier, userid.ToString()),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role) 
                };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["ApplicationSettings:JWT_Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(null,
              null,
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }
    }
}
