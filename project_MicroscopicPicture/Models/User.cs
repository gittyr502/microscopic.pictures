using System;
using System.Collections.Generic;

#nullable disable

namespace project_MicroscopicPicture.Models
{
    public partial class User
    {
        public User()
        {
            DoctorsInDiscussionGroups = new HashSet<DoctorsInDiscussionGroup>();
            Examinations = new HashSet<Examination>();
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserKindId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool SendInEmail { get; set; }
        public bool SendInPhone { get; set; }

        public virtual UserKind UserKind { get; set; }
        public virtual ICollection<DoctorsInDiscussionGroup> DoctorsInDiscussionGroups { get; set; }
        public virtual ICollection<Examination> Examinations { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
