﻿using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public interface IUserDL
    {
        Task Post(User user);
        Task<User> Get(string id, string password);
        
    }
}
