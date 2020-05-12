using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.ViewModel
{
    public class VmCommentEntry
    {
        public int Id { get; set; }
        public string Desc { get; set; }

        public int Like { get; set; }
        public int Dislike { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
