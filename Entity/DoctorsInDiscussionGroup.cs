using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class DoctorsInDiscussionGroup
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int DiscussionGroupId { get; set; }
        public string DoctorsOpinion { get; set; }
        public string Comment { get; set; }
        public byte[] LinkToImage { get; set; }

        [JsonIgnore]
        public virtual DiscussionGroup DiscussionGroup { get; set; }

        [JsonIgnore]
        public virtual User Doctor { get; set; }
    }
}
