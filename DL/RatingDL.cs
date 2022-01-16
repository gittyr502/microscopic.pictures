using DL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RatingDL: IRatingDL
    {
        MicroscopicPicture1Context myDB;
        public RatingDL(MicroscopicPicture1Context _myDB)
        {
            myDB = _myDB;
        }
        public async Task Post(Rating rating)
        {
            await myDB.Rating.AddAsync(rating);
            await myDB.SaveChangesAsync();
        }
    }
}
