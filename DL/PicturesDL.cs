using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class PicturesDL:IPicturesDL
    {
        MicroscopicPictureContext myDB;

        public PicturesDL(MicroscopicPictureContext _myDB)
        {
            myDB = _myDB;
        }
        public async Task Post(PicturesCollection picture)
        {
            await myDB.PicturesCollections.AddAsync(picture);
            await myDB.SaveChangesAsync();
        }
    }
}
