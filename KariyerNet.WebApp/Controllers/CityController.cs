using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KariyerNet.WebApp.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddCity()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddCity(AddCityViewModel model)
        {
            _cityService.AddCity(model);
            return Redirect(Url.Action("ListCities", "City"));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditCity()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditCity(EditCityViewModel model,int cityId)
        {
            _cityService.EditCity(model, cityId);
            return Redirect(Url.Action("ListCities", "City"));
        }
        public IActionResult DeleteCity(int cityId)
        {
            _cityService.DeleteCity(cityId);
            return Redirect(Url.Action("ListCities", "City"));
        }
        public IActionResult ListCities()
        {
            var model = _cityService.GetCityList();
            return View(model);
        }

    }
}
