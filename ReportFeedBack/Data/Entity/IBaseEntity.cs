using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportFeedBack.Data.Entity
{
   public interface IBaseEntity
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
