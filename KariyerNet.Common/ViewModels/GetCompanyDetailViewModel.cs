using KariyerNet.Common.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class GetCompanyDetailViewModel
    {
        public int UserId { get; set; }//CompanyUserId
        public int SectorId { get; set; }
        public string SectorName { get; set; }
        public string CompanyName { get; set; }
        public int FoundationYear { get; set; }
        public string Address { get; set; }
        public NumberEmployeeEnum NumberOfEmployees { get; set; }
        public string WebSite { get; set; }
        public string About { get; set; }
        public string ImageUrl { get; set; }
        public List<SelectListItem> SectorList { get; set; }
    }
}
