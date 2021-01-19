using KariyerNet.Business.Interfaces;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
   public class DrivingLicenseService: IDrivingLicenseService
    {
        private readonly IDrivingLicenseRepository _drivingLicenseRepository;
        public DrivingLicenseService(IDrivingLicenseRepository drivingLicenseRepository)
        {
            _drivingLicenseRepository = drivingLicenseRepository;
        }
        public List<SelectListItem> GetDrivingLicenseList()
        {

            var model = new List<SelectListItem>();
            _drivingLicenseRepository.GetAll().ToList().ForEach(x =>
            {
                model.Add(new SelectListItem()
                {
                    Text = x.DrivingLicenseType,
                    Value = x.Id.ToString()
                });

            });

            return model;
        }
    }
}
