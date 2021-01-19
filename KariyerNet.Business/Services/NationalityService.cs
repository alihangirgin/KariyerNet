using KariyerNet.Business.Interfaces;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
  public class NationalityService:INationalityService
    {
        private readonly INationalityRepository _nationalityRepository;
        public NationalityService(INationalityRepository nationalityRepository)
        {
            _nationalityRepository = nationalityRepository;
        }
        public List<SelectListItem> GetNationalityList()
        {

            var model = new List<SelectListItem>();
            _nationalityRepository.GetAll().ToList().ForEach(x =>
            {
                model.Add(new SelectListItem()
                {
                    Text = x.NationalityName,
                    Value = x.Id.ToString()
                });

            });

            return model;
        }
    }
}
