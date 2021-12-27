using System;
using System.Collections.Generic;

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
        public string LinkToImage { get; set; }

        public virtual DiscussionGroup DiscussionGroup { get; set; }
        public virtual User Doctor { get; set; }
    }
}
