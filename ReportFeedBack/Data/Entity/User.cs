using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.Data.Entity
{
    public class User:IBaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public List<Post> Post { get; set; }
        public List<Comment> Comment { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
