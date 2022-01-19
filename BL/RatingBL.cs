using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;

namespace BL
{
   public class RatingBL:IRatingBL
    {
        IRatingDL ratingDl;

        public RatingBL(IRatingDL _ratingDL)
        {
            ratingDl = _ratingDL;
        }


        public async Task Post(Rating rating)
        {
            await ratingDl.Post(rating);
            return;
        }

    }
}
