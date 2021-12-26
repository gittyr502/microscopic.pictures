using BL;
using Microsoft.AspNetCore.Mvc;
using project_MicroscopicPicture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
     
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
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(string id,string password)
        {
           return await userBL.Get(id, password);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
             userBL.Post(user);

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
    }
}
