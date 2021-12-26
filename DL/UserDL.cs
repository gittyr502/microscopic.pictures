using project_MicroscopicPicture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DL
{
   public class UserDL: IUserDL
    {
        MicroscopicPictureContext myDB;
        public async Task<User> Get(string id, string password)
        {
           
            User u = await myDB.Users.Where(u =>  u.Id.Equals(id)).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }
        public async Task Post(User user)
        {
            await myDB.Users.AddAsync(user);
            await myDB.SaveChangesAsync();
        }
    }
}