using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public interface IUserDL
    {
        Task<int> Post(User user);
        Task<User> Get(string id, string password);
        Task updatePassword(string newPassword, int userId);
    }
}
