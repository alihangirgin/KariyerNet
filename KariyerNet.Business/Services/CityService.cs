using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels.Admin;
using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IUserService _userService;
        public CityService(ICityRepository cityRepository, IUserService userService)
        {
            _cityRepository = cityRepository;
            _userService = userService;
        }


        public void AddCity(AddCityViewModel model)
        {
            var checkCity = _cityRepository.GetAll(x => x.CityName == model.CityName && x.DeleteDate == null).FirstOrDefault();
            if (checkCity == null)
            {
                var city = new City();
                city.CityName = model.CityName;
                city.CreateDate = DateTime.Now;
                var user = _userService.GetUser();
                city.UserId = user.UserId;

                var entity = _cityRepository.Add(city);

                if (entity != null)
                {
                    try
                    {
                        _cityRepository.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        var errorMessage = ex.Message;
                        throw;
                    }
                }
            }
        }

        public void EditCity(EditCityViewModel model, int cityId)
        {
            var city = _cityRepository.Get(x => x.Id == cityId);
            if (city != null)
            {
                city.CityName = model.CityName;
                city.UpdateDate = DateTime.Now;
                try
                {
                    _cityRepository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }

        }
        public void DeleteCity(int cityId)
        {
            var city = _cityRepository.Get(x => x.Id == cityId);
            if (city != null)
            {
                city.DeleteDate = DateTime.Now;
                city.UpdateDate = DateTime.Now;
                try
                {
                    _cityRepository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }

        }


        public List<EditCityViewModel> GetCityList()
        {
            var cityList = new List<EditCityViewModel>();
            var cities = _cityRepository.GetAll(x => x.DeleteDate == null).ToList();
            if (cities != null)
            {
                foreach (var item in cities)
                {
                    EditCityViewModel city = new EditCityViewModel();
                    city.CityName = item.CityName;
                    city.CityId = item.Id;
                    cityList.Add(city);
                }
            }
            return cityList;
        }

        public List<SelectListItem> GetCityListToForm()
        {

            var model = new List<SelectListItem>();
            _cityRepository.GetAll(x => x.DeleteDate == null).ToList().ForEach(x =>
               {
                   model.Add(new SelectListItem()
                   {
                       Text = x.CityName,
                       Value = x.Id.ToString()
                   });

               });

            return model;
        }

        public string GetCityNameByCityId(int cityId)
        {
            return _cityRepository.Get(x => x.Id == cityId).CityName.ToString();
        }

    }
}
