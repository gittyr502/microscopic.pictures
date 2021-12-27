using System;
using System.Collections.Generic;

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

        public virtual User Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<DiscussionGroup> DiscussionGroupDiagnosisNavigations { get; set; }
        public virtual ICollection<DiscussionGroup> DiscussionGroupExaminations { get; set; }
    }
}
