using KariyerNet.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.WebApp.ViewComponents
{
    public class NavBarEmployerViewComponent:ViewComponent
    {
        private readonly ICompanyDetailService _companyDetailService;

        public NavBarEmployerViewComponent(ICompanyDetailService companyDetailService)
        {
            _companyDetailService = companyDetailService;
        }
        public ViewViewComponentResult Invoke()
        {
            var companyDetail = _companyDetailService.GetCompanyDetail();
            return View(companyDetail);
        }
    }
}
