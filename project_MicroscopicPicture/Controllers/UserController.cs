using BL;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Authorization;
using DTO;

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
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Get([FromBody] UserDTO loginUser)
        {
           User u= await userBL.Get(loginUser.id, loginUser.password);
            if (u == null)
                return NoContent();
            else return Ok(u);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<int> Post([FromBody] User user)
        {
            return await userBL.Post(user);

        }


        
    }
}
