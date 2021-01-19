using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class Position:BaseEntity
    {
        public string PositionName { get; set; }
        public int UserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual ICollection<JobAdvertisement> JobAdvertisements { get; set; }

        public User User { get; set; }
    }
}
