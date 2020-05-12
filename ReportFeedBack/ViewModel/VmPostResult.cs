using Microsoft.EntityFrameworkCore;
using ReportFeedBack.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.ViewModel
{
    public class VmPostResult
    {
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public List<PostVm> Posts { get; set; }

        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

    }
}
