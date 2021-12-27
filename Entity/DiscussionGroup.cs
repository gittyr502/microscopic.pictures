using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class DiscussionGroup
    {
        public DiscussionGroup()
        {
            DoctorsInDiscussionGroups = new HashSet<DoctorsInDiscussionGroup>();
        }

        public int Id { get; set; }
        public int ExaminationId { get; set; }
        public int Diagnosis { get; set; }

        public virtual Examination DiagnosisNavigation { get; set; }
        public virtual Examination Examination { get; set; }
        public virtual ICollection<DoctorsInDiscussionGroup> DoctorsInDiscussionGroups { get; set; }
    }
}
