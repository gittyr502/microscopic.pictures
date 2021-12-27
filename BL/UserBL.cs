using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class UserBL:IUserBL
    {
        IUserDL userDL;
        public UserBL(IUserDL _userDL)
        {
            userDL=_userDL;
        }
        public async Task<User> Get(string id, string password)
        {
            await userDL.Get(id, password);
            return null;
        }
        public async Task Post(User user)
        {
            userDL.Post(user);
        }

       

        
    }

   
}
