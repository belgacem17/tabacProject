using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTABAC.Models
{
    public partial class News
    {
        public News()
        {
            Commantaires = new HashSet<Commantaire>();
        }

        public int NewsId { get; set; }
        public string NewsText { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Commantaire> Commantaires { get; set; }
    }
}
