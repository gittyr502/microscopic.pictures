using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
#nullable disable

namespace Entity
{
    public partial class User
    {
        //public User(object id)
        //{
        //    DoctorsInDiscussionGroups = new HashSet<DoctorsInDiscussionGroup>();
        //    Examinations = new HashSet<Examination>();
        //    Patients = new HashSet<Patient>();
        //}  
    //    public User(User u)
    //{
    //    u.Id=id;
    //    u.IdNumber=idNumber;
    //     u.FirstName=firstName;
    //       u.LastName=lastName;
    //        u.Phone=phone;
    //        u.Patients=Patients;
    //        u.Email=email;
    //        u.Password=Password;
    //}

        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserKindId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string Salt { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<DoctorsInDiscussionGroup> DoctorsInDiscussionGroups { get; set; }
        [JsonIgnore]
        public virtual ICollection<Examination> Examinations { get; set; }
        [JsonIgnore]
        public virtual ICollection<Patient> Patients { get; set; } 
        
     
    }
   
}

