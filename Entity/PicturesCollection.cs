using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class PicturesCollection
    {
        public int Id { get; set; }
        public int BacteriumId { get; set; }
        public string LinkToImage { get; set; }
        [JsonIgnore]
        public virtual Bacterium Bacterium { get; set; }
    }
}
