using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
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
        //public bool SaveImage(UserImage img)
        //{
        //    img.ImageFullPath = @"D:\Temp" + Path.GetFileName(img.FileName);
        //    using (FileStream srReadFile = new FileStream(img.ImageFullPath, FileMode.Create))
        //    {
        //        using (BinaryWriter writer = new BinaryWriter(srReadFile))
        //        {
        //            writer.Write(img.BinaryData);

        //            writer.Close();
        //        }
        //    }
        //    return picturesDL.SaveUserImage(img);
        //}

        public async  Task<bool> ValidateDuplicateFileName(string fileName)
        {
            if (await picturesDL.ImgExist(fileName))
                return true;
            return false;
        }
    }
}
