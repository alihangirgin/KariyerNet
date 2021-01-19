using KariyerNet.Business.Interfaces;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
    public class SectorService : ISectorService
    {

        private readonly ISectorRepository _sectorRepository;
        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public List<SelectListItem> GetSectorList()
        {

            var model = new List<SelectListItem>();
            _sectorRepository.GetAll().ToList().ForEach(x =>
            {
                model.Add(new SelectListItem()
                {
                    Text = x.SectorName,
                    Value = x.Id.ToString()
                });

            });

            return model;
        }


        public bool isSectorValid(int sectorId)
        {
            return _sectorRepository.Get(x => x.Id == sectorId) != null;
        }


        public string GetSectorNameBySectorId(int sectorId)
        {
            return _sectorRepository.Get(x => x.Id == sectorId).SectorName.ToString();
        }


    }
}
