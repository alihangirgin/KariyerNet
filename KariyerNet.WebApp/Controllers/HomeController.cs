using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KariyerNet.WebApp.Models;
using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels;

namespace KariyerNet.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobAdvertisementService _jobAdvertisementService;
        private readonly ICityService _cityService;


        public HomeController(ILogger<HomeController> logger,IJobAdvertisementService jobAdvertisementService,ICityService cityService)
        {
            _logger = logger;
            _jobAdvertisementService = jobAdvertisementService;
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            

            var homePageViewModel = new HomePageViewModel();
            
            homePageViewModel.TotalJobAdvertisement= _jobAdvertisementService.JobAdvertisementCount();
            homePageViewModel.SearchCityList = _cityService.GetCityListToForm();
            homePageViewModel.GetHomeSliderViewModels = _jobAdvertisementService.GetMostViewedJobAdvertisement();
            return View(homePageViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
