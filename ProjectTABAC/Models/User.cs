using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTABAC.Models
{
    public partial class User
    {
        public User()
        {
            Commantaires = new HashSet<Commantaire>();
            News = new HashSet<News>();
            Reclamations = new HashSet<Reclamation>();
            Responses = new HashSet<Response>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? UserType { get; set; }
        public string Mobile { get; set; }

        public virtual ICollection<Commantaire> Commantaires { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Reclamation> Reclamations { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
}
