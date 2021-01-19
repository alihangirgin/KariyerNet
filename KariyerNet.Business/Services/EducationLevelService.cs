using KariyerNet.Business.Interfaces;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
    public class EducationLevelService: IEducationLevelService
    {
        private readonly IEducationLevelRepository _educationLevelRepository;
        public EducationLevelService(IEducationLevelRepository educationLevelRepository)
        {
            _educationLevelRepository = educationLevelRepository;
        }



        public List<SelectListItem> GetEducationLevelList()
        {

            var model = new List<SelectListItem>();
            _educationLevelRepository.GetAll().ToList().ForEach(x =>
            {
                model.Add(new SelectListItem()
                {
                    Text = x.EducationName,
                    Value = x.Id.ToString()
                });

            });

            return model;
        }


        public string GetEdcuationLevelNameByEducationLevelId(int educationLevelId)
        {
            return _educationLevelRepository.Get(x => x.Id == educationLevelId).EducationName.ToString();
        }
    }
}
