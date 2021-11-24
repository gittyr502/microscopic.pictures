using System;
using System.Collections.Generic;

#nullable disable

namespace project_MicroscopicPicture.Models
{
    public partial class PicturesCollection
    {
        public int Id { get; set; }
        public int BacteriumId { get; set; }
        public string LinkToImage { get; set; }

        public virtual Bacterium Bacterium { get; set; }
    }
}
