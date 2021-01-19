using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class Sector:BaseEntity
    {
        public string SectorName { get; set; }
        public int UserId { get; set; }
        public DateTime? DeleteDate { get; set; }

        public ICollection<CompanyDetail> CompanyDetails { get; set; }
        public User User { get; set; }
    }
}
