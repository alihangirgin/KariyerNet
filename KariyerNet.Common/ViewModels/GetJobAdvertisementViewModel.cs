using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class GetJobAdvertisementViewModel
    {
        public int JobAdvertisementId { get; set; }
        public int CompanyUserId { get; set; }
        public string CompanyName { get; set; }
        public int CityId { get; set; }
        public int ViewCount { get; set; }
        public string JobTitle { get; set; }
        public string CityName { get; set; }
        public int EducationLevelId { get; set; }
        public string EducationLevelName { get; set; }
        public int DepartmantId { get; set; }
        public string DepartmantName { get; set; }
        public int WorkTypeId { get; set; }
        public string WorkTypeName { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string JobDefinition { get; set; }
        public int RequiredExperience { get; set; }
        public int AvailableJobCount { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public bool isUserApplied { get; set; }
    }
}
