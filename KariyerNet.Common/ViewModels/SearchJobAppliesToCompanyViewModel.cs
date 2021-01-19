using KariyerNet.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class SearchJobAppliesToCompanyViewModel
    {
       
        public List<UserProfileViewModel> userProfiles { get; set; }
        public string JobAdvertisementTitle { get; set; }
        public string NameSurname { get; set; }
        public DateTime? DateOne { get; set; }
        public DateTime? DateTwo { get; set; }
        public GenderEnum Gender { get; set; }
        public int DrivingLicenseId { get; set; }
        public int NationalityId { get; set; }
        public List<SelectListItem> DrivingLicenseList { get; set; }
        public List<SelectListItem> NationalityList { get; set; }

    }
}
