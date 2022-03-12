﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
namespace BL
{
    public interface IUserBL
    {
        Task<User> Get(string id, string password);

        Task<List<User>> GetAllUsers();
        Task<int> Post(User user);
        Task<int> sendCodePassword(string email);
        Task updatePassword(string code, string newPassword, int id);
    }
}


