using ReportFeedBack.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.ViewModel
{
    public class PostVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public UserVm User { get; set; }
        public List<CommentVm> Comments { get; set; }
    }

    public class UserVm
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
    public class CommentVm
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public string UserName { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public int PostId { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
