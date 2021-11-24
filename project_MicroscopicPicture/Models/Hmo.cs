using System;
using System.Collections.Generic;

#nullable disable

namespace project_MicroscopicPicture.Models
{
    public partial class Hmo
    {
        public Hmo()
        {
            Patients = new HashSet<Patient>();
        }

        public int Id { get; set; }
        public string NameOfHmo { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
    }
}
