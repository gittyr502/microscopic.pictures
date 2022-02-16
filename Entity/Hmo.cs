using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#nullable disable

namespace Entity
{
    public partial class Hmo
    {
        public Hmo()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string NameOfHmo { get; set; }
        [JsonIgnore]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
