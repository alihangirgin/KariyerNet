using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class CreateJobAdvertisementViewModel
    {
        public bool Publish { get; set; }
        public int CompanyUserId { get; set; }
        public int CityId { get; set; }
        public string JobTitle { get; set; }
        public int EducationLevelId { get; set; }
        public int DepartmantId { get; set; }
        public int WorkTypeId { get; set; }
        public int PositionId { get; set; }
        public string JobDefinition { get; set; }
        public int RequiredExperience { get; set; }
        public int AvailableJobCount { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime ExpireDate { get; set; }

        public List<SelectListItem> CityList { get; set; }
        public List<SelectListItem> EducationLevelList { get; set; }
        public List<SelectListItem> DepartmantList { get; set; }
        public List<SelectListItem> WorkTypeList { get; set; }
        public List<SelectListItem> PositionList { get; set; }

    }
}
