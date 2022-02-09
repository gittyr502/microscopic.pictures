using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class PicturesCollection
    {
        public int Id { get; set; }
        public bool  InStock{ get; set; }
        public byte[] LinkToImage { get; set; }

        public virtual Bacterium Bacterium { get; set; }
    }
}
