using BL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project_MicroscopicPicture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        IPicturesBL picturesBL;

        public PicturesController(IPicturesBL _picturesBL)
        {
            picturesBL = _picturesBL;
        }


        // POST api/<PicturesController>
        [HttpPost]
        public async Task Post([FromBody] PicturesCollection picture)
        {
            await picturesBL.Post(picture);
        }

    }
}
