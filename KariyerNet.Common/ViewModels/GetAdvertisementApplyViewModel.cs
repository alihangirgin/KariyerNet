using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class GetAdvertisementApplyViewModel
    {
        public int JobAdvertisementId { get; set; }
        public string JobAdvertisementName { get; set; }
        public string CompanyName { get; set; }
        //public int CompanyUserId { get; set; }
        //public DateTime? DeleteDate { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
