using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IPicturesDL
    {
        Task Post(PicturesCollection picture);
        Task<bool> ImgExist(string linkToFile);
    }
}
