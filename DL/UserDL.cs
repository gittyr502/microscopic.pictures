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
           
            User u = await myDB.Users.Where(a =>  a.IdNumber.Equals(id)&&a.Password.Equals(password)).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }
         public async Task<User> GetByEmail(string email)
        {
           
            User u = await myDB.Users.Where(u =>  u.Email.Equals(email)).FirstOrDefaultAsync();
            if (u != null)
            {
                return u;
            }
            return null;
        }

        public async Task<List<User>> GetAllUsers()
        {
            List<User> l = await myDB.Users.ToListAsync();
            return l;
        }

        public async Task<User> getByIdNumber(int id)
        {
            User u = await myDB.Users.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();
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

        public async Task updatePassword(User u)
        {
            User u1 = await myDB.Users.Where(u1 => u1.IdNumber.Equals(u.IdNumber)).FirstOrDefaultAsync();
            myDB.Entry(u1).CurrentValues.SetValues(u);
            await myDB.SaveChangesAsync();
        }


        //public async Task sendCodePassword(string email)
        //{
        //    User u = await myDB.Users.FindAsync(userId);
        //    myDB.Entry(u).CurrentValues.SetValues(newUser);
        //    await myDB.SaveChangesAsync();
        //}


    }
}   