using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stackoverflow.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Desc { get; set; }
        public int UserId { get; set; }
        public int AnswerId { get; set; }
    }
}
