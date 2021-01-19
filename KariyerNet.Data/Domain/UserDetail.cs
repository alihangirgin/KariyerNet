using KariyerNet.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class UserDetail:BaseEntity
	{

        public int UserId { get; set; }
        public string NameSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public string ProfileImage { get; set; }
        public GenderEnum Gender { get; set; }
        public int? DrivingLicenseId { get; set; }
        public int NationalityId { get; set; }
        public User User { get; set; }
        public virtual DrivingLicense DrivingLicense { get; set; }
        public virtual Nationality Nationality { get; set; }

	}
}
