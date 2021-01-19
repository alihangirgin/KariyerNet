using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class DrivingLicense:BaseEntity
    {
        public string DrivingLicenseType { get; set; }
        public int UserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public User User { get; set; }
        public virtual ICollection<UserDetail> UserDetails { get; set; }
    }
}
