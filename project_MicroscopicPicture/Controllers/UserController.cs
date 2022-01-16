using BL;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
     
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_MicroscopicPicture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {    IUserBL userBL;
       public UserController(IUserBL _userBL)
        {
            userBL =_userBL;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}/{password}")]
        public async Task<User> Get(string id,string password)
        {
           return await userBL.Get(id, password);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<int> Post([FromBody] User user)
        {
            return await userBL.Post(user);

        }


        
    }
}
