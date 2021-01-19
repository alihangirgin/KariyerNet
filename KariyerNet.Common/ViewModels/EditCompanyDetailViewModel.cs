using KariyerNet.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class EditCompanyDetailViewModel
    {
        public int NumberOfUnreadSendedMessages { get; set; }

        public int UserId { get; set; }//CompanyUserId

        [Required]
        public int SectorId { get; set; }
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public int FoundationYear { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public NumberEmployeeEnum NumberOfEmployees { get; set; }

        [Required]
        public string WebSite { get; set; }

        [Required]
        public string About { get; set; }

        [Required]
        public IFormFile ImageUrl { get; set; }

        public string ImagePath { get; set; }

        public string ImageFileName { get; set; }

        public List<SelectListItem> SectorList { get; set; }

    }
}
