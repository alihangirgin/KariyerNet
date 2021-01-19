using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class User : IdentityUser<int>, IBaseEntity
    {
        public string NameSurname { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public ICollection<AdvertisementApply> AdvertisementApplies { get; set; }
        public ICollection<AdvertisementViewCount> AdvertisementViewCounts { get; set; }
        public ICollection<City> Cities { get; set; }
        public virtual CompanyDetail CompanyDetail { get; set; }
        public virtual ICollection<CompanyFollower> CompanyFollowers { get; set; }
        public virtual ICollection<Departmant> Departmants { get; set; }
        public virtual ICollection<DrivingLicense> DrivingLicenses { get; set; }
        public virtual ICollection<EducationLevel> EducationLevels { get; set; }
        public virtual ICollection<JobAdvertisement> JobAdvertisements { get; set; }
        public ICollection<Nationality> Nationalities { get; set; }
        public ICollection<Position> Positions { get; set; }
        public ICollection<Sector> Sectors { get; set; }
        public ICollection<UserCurriculumVitae> UserCurriculumVitaes { get; set; }
        public ICollection<UserDetail> UserDetails { get; set; }
        public ICollection<WorkType> WorkTypes { get; set; }

        public ICollection<Message> Messages { get; set; }
        public ICollection<Message> SendedMessages { get; set; }
    }
}
