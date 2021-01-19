using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class HomePageViewModel
    {

        public int TotalJobAdvertisement { get; set; }
        public int CityId { get; set; }
        public string Text { get; set; }
        public List<SelectListItem> SearchCityList { get; set; }
        public List<GetHomeSliderViewModel> GetHomeSliderViewModels { get; set; }
    }
}
