using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#nullable disable

namespace Entity
{
    public partial class PicturesCollection
    {
        public int Id { get; set; }
        public byte[] LinkToImage { get; set; }
        public bool? InStock { get; set; }
    }
}
