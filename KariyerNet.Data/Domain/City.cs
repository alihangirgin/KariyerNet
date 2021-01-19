using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class City:BaseEntity
    {
        public string CityName { get; set; }
        public int UserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public User User { get; set; }
        public virtual ICollection<JobAdvertisement> JobAdvertisements { get; set; }
    }
}
