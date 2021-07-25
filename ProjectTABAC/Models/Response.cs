using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTABAC.Models
{
    public partial class Response
    {
        public int ResponseId { get; set; }
        public string ResponseText { get; set; }
        public int? UserId { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question Question { get; set; }
        public virtual User User { get; set; }
    }
}
