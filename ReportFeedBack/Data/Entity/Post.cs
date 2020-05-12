﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.Data.Entity
{
    public class Post:IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public int  UserId { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
