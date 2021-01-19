using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class GetAdvertisementApplyToCompanyViewModel
    {
        public int JobAdvertisementId { get; set; }

        public int UserId { get; set;}
        public string UserName { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
