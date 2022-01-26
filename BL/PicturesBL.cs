using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PicturesBL:IPicturesBL
    {
        IPicturesDL picturesDL;
        public PicturesBL(IPicturesDL _picturesDL)
        {
            picturesDL = _picturesDL;
        }
        public async Task Post(PicturesCollection picture)
        {
            await picturesDL.Post(picture);
        }
    }
}
