using DL;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
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
        string codeOfPassword;
        public UserBL(IUserDL userDL,IPasswordHashHelper passwordHashHelper, IConfiguration configuration)
        {
           _userDL= userDL;
            _passwordHashHelper = passwordHashHelper;
            _configuration = configuration;
        }
        public async Task<User> Get(string id, string password)
        {
            string salt = await _userDL.getSalt(id);
            if (salt == null)
                return null;
            password = _passwordHashHelper.HashPassword(password, salt, 1000, 8);
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

        public async Task<List<User>> GetAllUsers()
        {
            return await _userDL.GetAllUsers();
        }

        public async Task<int> Post(User user)
        {
            user.Salt = _passwordHashHelper.GenerateSalt(8);
            user.Password = _passwordHashHelper.HashPassword (user.Password, user.Salt, 1000, 8);
            return await _userDL.Post(user); 
        }

        public async Task Delete(int id)
        {
            await _userDL.Delete(id);
        }

        public async Task<int> sendCodePassword(string email)
        {
            User u = await _userDL.GetByEmail(email);
            if (u != null)
                {     string code =sendMail(email);
                if (code != null)
                {
                    codeOfPassword = code.ToString();
                    return u.Id;
                }
              
            }
            return 0;

        }

        

        public string randStr()
        {
            int length = 7;
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }

         public  string sendMail(string email)
        {
           
                //string to = "212382261@mby.co.il"; //To address    
                //string from = "324102417@mby.co.il"; //From address    
                MailMessage message = new MailMessage();
                message.From = new MailAddress("212853055@mby.co.il");
                message.To.Add(new MailAddress(email));
                string randstring = randStr();
                string mailbody = "your identifier is: \n" + randstring;
                //  string link = "<a href= https://localhost:44317/swagger/index.html > enter to match  </a>";
                message.Subject = "Sending Email Using Asp.Net & C#";
                message.Body = mailbody; //+ mapurl;
                message.BodyEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.office365.com", 587); //Gmail smtp    
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("212853055@mby.co.il", "Student@264");
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = basicCredential1;
                try
                {
                    client.Send(message);
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                return randstring;
            

        }

     
        public  async Task updatePassword(string code, string newPassword, int id)
        {//if (code==codeOfPassword)
                if (code!=null)
                { 
            User u = await _userDL.getByIdNumber(id);
                if (u != null)
                {
                    u.Password = _passwordHashHelper.HashPassword(newPassword, u.Salt, 1000, 8);

                    await _userDL.updatePassword(u);
                }

            }
        }
    }

   
}
