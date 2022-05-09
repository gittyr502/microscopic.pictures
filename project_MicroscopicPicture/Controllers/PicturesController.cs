using BL;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost, DisableRequestSizeLimit]
        [Route("SaveImage")]
        public async  Task<bool> SaveImage([FromForm] IFormFile image)
        {
            //we can send the userId from Client, or get it from Request.HttpContext.User.Identity.Name
            //probably we should replace the user name with user id

            int userId=1;
            if (await picturesBL.ValidateDuplicateFileName(image.FileName))
              return false;

            //save file on disk
            //we put it in the web layer because IFormFile is part of AspNetCore.Http namespace - that is a part of the web layer
            string directory = Path.Combine(@"M:\pictures", userId.ToString());
            var folderName = Path.Combine("Resources", "Images", userId.ToString());
            Directory.CreateDirectory(directory);
            string filePath = Path.Combine(directory, image.FileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            return true;
            
        }


    }
}
