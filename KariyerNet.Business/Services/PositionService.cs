using KariyerNet.Business.Interfaces;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
    public class PositionService:IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public List<SelectListItem> GetPositionList()
        {

            var model = new List<SelectListItem>();
            _positionRepository.GetAll().ToList().ForEach(x =>
            {
                model.Add(new SelectListItem()
                {
                    Text = x.PositionName,
                    Value = x.Id.ToString()
                });

            });

            return model;
        }

        public string GetPositionNameByPositionId(int positionId)
        {
            return _positionRepository.Get(x => x.Id == positionId).PositionName.ToString();
        }
    }
}

