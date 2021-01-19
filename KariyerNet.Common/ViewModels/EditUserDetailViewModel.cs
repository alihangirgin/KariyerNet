using KariyerNet.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class EditUserDetailViewModel
    {
        public int numberOfUnreadMessages { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string NameSurname { get; set; }
        public string ProfileImage { get; set; }
        public IFormFile ProfileImageFile { get; set; }
        public string ProfileImageFileName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public int? DrivingLicenseId { get; set; }
        public string DrivingLicenseName { get; set; }
        public string NationalityName { get; set; }
        public int NationalityId { get; set; }
        public List<SelectListItem> DrivingLicenseList { get; set; }
        public List<SelectListItem> NationalityList { get; set; }
    }
}
