﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Examination
    {
        public Examination()
        {
            DiscussionGroupDiagnosisNavigations = new HashSet<DiscussionGroup>();
            DiscussionGroupExaminations = new HashSet<DiscussionGroup>();
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public int DoctorId { get; set; }
        public string ComputerDiagnosis { get; set; }
        public string DoctorDiagnosis { get; set; }
        public string PrescriptionName { get; set; }
        public string LinkToFile { get; set; }
        public string TissueCultureResult { get; set; }
        public string Comments { get; set; }
        [JsonIgnore]
        public virtual User Doctor { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
        [JsonIgnore]
        public virtual ICollection<DiscussionGroup> DiscussionGroupDiagnosisNavigations { get; set; }
        [JsonIgnore]
        public virtual ICollection<DiscussionGroup> DiscussionGroupExaminations { get; set; }
    }
}
