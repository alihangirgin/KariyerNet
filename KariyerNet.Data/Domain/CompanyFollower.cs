using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class CompanyFollower:BaseEntity
	{
        public int CompanyUserId { get; set; } //takip edilen
		public int UserId { get; set; } //takip eden
		public DateTime? DeleteDate { get; set; }
		public User User { get; set; }
		//public User CompanyUser { get; set; }//takip edilen şirket
	}
}
