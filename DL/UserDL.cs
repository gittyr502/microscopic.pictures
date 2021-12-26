using project_MicroscopicPicture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DL
{
   public class UserDL
    {
        MicroscopicPictureContext myDB;
        public async Task Post(User user)
        {
            await myDB.Users.AddAsync(user);
            await myDB.SaveChangesAsync();
        }
    }
}