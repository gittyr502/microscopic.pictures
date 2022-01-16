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
        MicroscopicPicture1Context myDB;

        public PicturesDL(MicroscopicPicture1Context _myDB)
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
