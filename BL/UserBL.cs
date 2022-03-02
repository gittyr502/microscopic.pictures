using DL;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL:IUserBL
    {
        IUserDL _userDL;
        IConfiguration _configuration;
        IPasswordHashHelper _passwordHashHelper;
        public UserBL(IUserDL userDL,IPasswordHashHelper passwordHashHelper, IConfiguration configuration)
        {
           _userDL= userDL;
            _passwordHashHelper = passwordHashHelper;
            _configuration = configuration;
        }
        public async Task<User> Get(string id, string password)
        {
           User user= await _userDL.Get(id, password);
            if (user == null) 
                return null;
           
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return WithoutPassword(user);

        }

        private User WithoutPassword(User user)
        {
            user.Password = null;
            return user;
        }

        public async Task<int> Post(User user)
        {
            user.Salt = _passwordHashHelper.GenerateSalt(8);
            user.Password = _passwordHashHelper.HashPassword (user.Password, user.Salt, 1000, 8);
            return await _userDL.Post(user); 
        }

        public async Task updatePassword(string newPassword, int userId)
        {
            await _userDL.updatePassword(newPassword, userId);
        }
    }

   
}
