using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Patient
    {
        public Patient()
        {
            Examinations = new HashSet<Examination>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string IdNumOfMember { get; set; }
        public string FullName { get; set; }
        public string MedicalInformation { get; set; }
        public DateTime BirthDate { get; set; }
        public int HmoId { get; set; }
        [JsonIgnore]
        public virtual Hmo Hmo { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Examination> Examinations { get; set; }
    }
}
