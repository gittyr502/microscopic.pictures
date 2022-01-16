using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual Examination DiagnosisNavigation { get; set; }
        
        [JsonIgnore]
        public virtual Examination Examination { get; set; }

        [JsonIgnore]
        public virtual ICollection<DoctorsInDiscussionGroup> DoctorsInDiscussionGroups { get; set; }
    }
}
