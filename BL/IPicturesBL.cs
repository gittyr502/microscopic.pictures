using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IPicturesBL
    {
        Task Post(PicturesCollection picture);
    }
}
