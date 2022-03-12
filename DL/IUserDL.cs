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
        //Task sendCodePassword(string newPassword, int userId);

        Task<List<User>> GetAllUsers();
        Task<User> GetByEmail(string email);
        Task updatePassword(User u);
        Task<User> getByIdNumber(int id);
    }
}
