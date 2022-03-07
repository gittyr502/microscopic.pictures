using Entity;
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
        MicroscopicPicture1Context myDB;

        public UserDL(MicroscopicPicture1Context _myDB)
        {
            myDB = _myDB;
        }
        public async Task<User> Get(string id, string password)
        {
           
            User u = await myDB.Users.Where(u =>  u.IdNumber.Equals(id)&&u.Password.Equals(password)).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }
         public async Task<User> GetByMail(string email)
        {
           
            User u = await myDB.Users.Where(u =>  u.Email.Equals(email)).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<int> Post(User user)
        {
            await myDB.Users.AddAsync(user);
            await myDB.SaveChangesAsync();
            return user.Id;
        }

        public async Task updatePassword(int userId, User newUser )
        {
        User u=  await myDB.Users.FindAsync(userId);
         myDB.Entry(u).CurrentValues.SetValues(newUser);
           await myDB..SaveChangesAsync();
        }

    }
}   