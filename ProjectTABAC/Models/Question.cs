using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectTABAC.Models
{
    public partial class Question
    {
        public Question()
        {
            Responses = new HashSet<Response>();
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionType { get; set; }
        public int? UserId { get; set; }

        public virtual ICollection<Response> Responses { get; set; }
    }
}
