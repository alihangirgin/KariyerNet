using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class SearchJobAdvertisementViewModel
    {
        public List<SearchResultJobAdvertisementViewModel> searchResultJobAdvertisementViewModel { get; set; }
        public string Text { get; set; }
        public int WhereToSearch { get; set; }
        public int DateSearch { get; set; }
        public int RequiredExperience { get; set; }
        public List<int?> CityId { get; set; }
        public List<int?> SectorId { get; set; }
        public List<int?> DepartmantId { get; set; }
        public List<int?> WorkTypeId { get; set; }
        public List<int?> PositionId { get; set; }
        public List<int?> EducationLevelId { get; set; }
        public DateTime? CreateDate { get; set; }      
        public List<SelectListItem> SectorList { get; set; }
        public List<SelectListItem> CityList { get; set; }
        public List<SelectListItem> DepartmantList { get; set; }
        public List<SelectListItem> WorkTypeList { get; set; }
        public List<SelectListItem> PositionList { get; set; }
        public List<SelectListItem> EducationLevelList { get; set; }
   




    }
}
