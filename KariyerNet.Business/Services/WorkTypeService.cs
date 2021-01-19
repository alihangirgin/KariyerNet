using KariyerNet.Business.Interfaces;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
    public class WorkTypeService:IWorkTypeService
    {
        private readonly IWorkTypeRepository _workTypeRepository;
        public WorkTypeService(IWorkTypeRepository workTypeRepository)
        {
            _workTypeRepository = workTypeRepository;
        }

        public List<SelectListItem> GetWorkTypeList()
        {

            var model = new List<SelectListItem>();
            _workTypeRepository.GetAll().ToList().ForEach(x =>
            {
                model.Add(new SelectListItem()
                {
                    Text = x.WorkTypeName,
                    Value = x.Id.ToString()
                });

            });

            return model;
        }


        public string GetWorkTypeNameByWorkTypeId(int workTypeId)
        {
            return _workTypeRepository.Get(x => x.Id == workTypeId).WorkTypeName.ToString();
        }

    }

}

