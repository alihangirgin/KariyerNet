using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class AdvertisementApply:BaseEntity
	{
        public int JobAdvertisementId { get; set; }
        public int UserId { get; set; }
		public DateTime? DeleteDate { get; set; }

        public virtual JobAdvertisement JobAdvertisement { get; set; }
        public User User { get; set; }


    }
}
