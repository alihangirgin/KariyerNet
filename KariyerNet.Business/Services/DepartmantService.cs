using KariyerNet.Business.Interfaces;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
    public class DepartmantService:IDepartmantService
    {
        private readonly IDepartmantRepository _departmantRepository;
        public DepartmantService(IDepartmantRepository departmantRepository)
        {
            _departmantRepository = departmantRepository;
        }

        public List<SelectListItem> GetDepartmantList()
        {

            var model = new List<SelectListItem>();
            _departmantRepository.GetAll().ToList().ForEach(x =>
            {
                model.Add(new SelectListItem()
                {
                    Text = x.DepartmantName,
                    Value = x.Id.ToString()
                });

            });

            return model;
        }
        public string GetDepartmantNameByDepartmantId(int departmantId)
        {
            return _departmantRepository.Get(x => x.Id == departmantId).DepartmantName.ToString();
        }
    }
}

