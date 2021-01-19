using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class SearchResultJobAdvertisementViewModel
    {
        public int JobAdvertisementId { get; set; }
        public string JobTitle { get; set; }
        public string JobDefinition { get; set; }
        public string CompanyName { get; set; }
        public string CityName { get; set; }
        public string PositionName { get; set; }
        public string EducationLevelName { get; set; }
        public string DepartmantName { get; set; }
        public string WorkTypeName { get; set; }
        public int RequiredExperience { get; set; }
        public int AvailableJobCount { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        


    }
}
