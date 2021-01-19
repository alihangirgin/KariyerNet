using KariyerNet.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerNet.WebApp.ViewComponents
{
    public class NavBarEmployeeViewComponent:ViewComponent
    {
        private readonly IUserDetailService _userDetailService;
        public NavBarEmployeeViewComponent(IUserDetailService userDetailService)
        {
            _userDetailService = userDetailService;
        }
        public ViewViewComponentResult Invoke()
        {
            var userDetail = _userDetailService.GetEditUserDetail();
            return View(userDetail);
        }
    }
}
