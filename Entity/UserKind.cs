using System;
using System.Collections.Generic;

#nullable disable

namespace project_MicroscopicPicture.Models
{
    public partial class UserKind
    {
        public UserKind()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string UserKind1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
