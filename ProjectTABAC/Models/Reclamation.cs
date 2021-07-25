using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTABAC.Models
{
    public partial class Reclamation
    {
        public int ReclamationId { get; set; }
        public byte[] ReclamationText { get; set; }
        public int UserId { get; set; }
        public int CommantaireId { get; set; }

        public virtual Commantaire Commantaire { get; set; }
        public virtual User User { get; set; }
    }
}
