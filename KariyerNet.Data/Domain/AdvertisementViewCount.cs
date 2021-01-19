using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class AdvertisementViewCount:BaseEntity
    {

        public int JobAdvertisementId { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public virtual JobAdvertisement JobAdvertisement { get; set; }

    }
}
