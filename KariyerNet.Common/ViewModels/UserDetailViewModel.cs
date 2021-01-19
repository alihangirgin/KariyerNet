using KariyerNet.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class UserDetailViewModel
    {
        public int UserId { get; set; }
        public string NameSurname { get; set; }
        public string FileName { get; set; }
        public string CVFileName { get; set; }
        public string NationalityName { get; set; }
        public string DrivingLicenseName { get; set; }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }

    }
}
