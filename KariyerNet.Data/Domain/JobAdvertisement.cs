using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class JobAdvertisement : BaseEntity
    {
        public int CompanyUserId { get; set; }
        public int CityId { get; set; }
        public int EducationLevelId { get; set; }
        public int DepartmantId { get; set; }
        public int WorkTypeId { get; set; }
        public int PositionId { get; set; }
        public string JobTitle { get; set; }
        public string JobDefinition { get; set; }
        public int RequiredExperience { get; set; }
        public int AvailableJobCount { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime? PublishDate {get; set;}

        //public int UserId { get; set; }
        public User User { get; set; }
        public virtual City City { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }
        public virtual Departmant Departmant { get; set; }
        public virtual WorkType WorkType { get; set; }
        public virtual Position Position { get; set; }

        public ICollection<AdvertisementApply> AdvertisementApplies { get; set; }
        public ICollection<AdvertisementViewCount> AdvertisementViewCounts { get; set; }
    }
}
