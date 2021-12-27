using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Bacterium
    {
        public Bacterium()
        {
            PicturesCollections = new HashSet<PicturesCollection>();
        }

        public int Id { get; set; }
        public string BacteriumName { get; set; }
        public string InformationOfBacterium { get; set; }
        public string Medicine { get; set; }

        public virtual ICollection<PicturesCollection> PicturesCollections { get; set; }
    }
}
