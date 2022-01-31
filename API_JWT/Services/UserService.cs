using API_JWT.Models;
using API_JWT.Models.Common;
using API_JWT.Models.Request;
using API_JWT.Models.Response;
using API_JWT.Models.Tools;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace API_JWT.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public UserResponse Auth(AuthRequest model)
        {
            UserResponse Userresponse = new UserResponse();
            using (var db = new PruebaJWTContext())
            {
             
                string passwordEncript = Encrypt.Encryption(model.Password);
                var user = db.Users.Where(x=>x.Email == model.Email && 
                                          x.Password == passwordEncript).FirstOrDefault();
                if (user == null) return null;

                Userresponse.Email = user.Email;
                Userresponse.Token = GetToken(user);
            }
            return Userresponse;
            
        }

        private string GetToken(User user)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                        new Claim(ClaimTypes.Email, user.Email.ToString())

                    }
                    ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), (SecurityAlgorithms.HmacSha256Signature))
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            return tokenhandler.WriteToken(token);
        }

    }
}
