using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.Data.Entity
{
    public class Comment : IBaseEntity
    {
        public int Id { get ; set ; }
        public string Desc { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
