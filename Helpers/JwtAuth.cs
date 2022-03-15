using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Apicursos.Models;
using GestaoCursos.Context;

namespace Apicursos.Helpers
{
    public class JwtAuth
    {
        public static string GenerateToken(User user)
        {

        var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=");
            //var secret = Encoding.ASCII.GetBytes(GetSection("JwtSettings:Key").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Role, RoleFactory(user.Type))
                }),
                Expires = DateTime.UtcNow.AddHours(10),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static string RoleFactory(int roleNumber)
        {
            switch (roleNumber)
            {
                case 1:
                    return "Secretary";

                case 2:
                    return "Manager";

                case 3:
                    return "Students";


                default:
                    throw new Exception();
            }
        }
    }
}
