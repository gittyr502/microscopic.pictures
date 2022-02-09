using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
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
        public string Password { get; set; }
        [JsonIgnore]
        public virtual UserKind UserKind { get; set; }
        [JsonIgnore]
        public virtual ICollection<DoctorsInDiscussionGroup> DoctorsInDiscussionGroups { get; set; }
        [JsonIgnore]
        public virtual ICollection<Examination> Examinations { get; set; }
        [JsonIgnore]
        public virtual ICollection<Patient> Patients { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
