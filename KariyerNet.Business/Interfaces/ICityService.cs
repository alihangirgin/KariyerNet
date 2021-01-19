using KariyerNet.Common.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface ICityService
    {
        void AddCity(AddCityViewModel model);
        public void EditCity(EditCityViewModel model, int cityId);
        public void DeleteCity(int cityId);
        List<EditCityViewModel> GetCityList();
        List<SelectListItem> GetCityListToForm();
        string GetCityNameByCityId(int cityId);
    }
}
