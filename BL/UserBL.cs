using DL;
using project_MicroscopicPicture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL:IUserBL
    {
        IUserDl userDL;
        public async Task Get(string id, string password)
        {
        }
        public async Task Post(User user)
        {
            userDL.Post(user);
        }

        User IUserBL.Get(string id, string password)
        {
            throw new NotImplementedException();
        }

        User IUserBL.Post(User user)
        {
            throw new NotImplementedException();
        }
    }

   
}
