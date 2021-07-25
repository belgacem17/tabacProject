using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTABAC.Models
{
    public partial class Commantaire
    {
        public Commantaire()
        {
            Reclamations = new HashSet<Reclamation>();
        }

        public int CommantaireId { get; set; }
        public string CommantaireText { get; set; }
        public int? UserId { get; set; }
        public int? NewsId { get; set; }

        public virtual News News { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Reclamation> Reclamations { get; set; }
    }
}
