using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestApi.Data.Entities;
using RestApi.Data.Helper;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;
        private readonly AppSettings _appSettings;

        public UsersController(AppDBContext appDBContext, IOptions<AppSettings> appSettings)
        {
            _appDBContext = appDBContext;
            _appSettings = appSettings.Value;
        }
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel loginV)
        {
            var user = _appDBContext.Users.SingleOrDefault(x => x.UserName == loginV.userName && x.Password == loginV.passWord);
            if (user == null)
            {
                return Ok(new
                {
                    Succes = false,
                    Message = "sai thông tin đăng nhập",
                });

            }

            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim("id",user.UserId.ToString()),
                new Claim(ClaimTypes.Role,"KhachHang")
            };
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                Succes = true,
                Message = "đăng nhập thành công",
                Data = new
                {
                    Token = tokenHandler.WriteToken(token)
                }
            });

        }

    }
}
