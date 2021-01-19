using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class EditJobAdvertisementViewModel
    {
        public int JobAdvertisementId { get; set; }
        public GetJobAdvertisementViewModel GetJobAdvertisementViewModel { get; set; }
        public CreateJobAdvertisementViewModel createJobAdvertisementViewModel { get; set; }

    }
}
