using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KariyerNet.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KariyerNet.WebApp.Controllers
{
    public class CompanyFollowerController : Controller
    {

        private readonly ICompanyFollowerService _companyFollowerService;
        private readonly ICompanyDetailService _companyDetailService;


        public CompanyFollowerController(ICompanyFollowerService companyFollowerService, ICompanyDetailService companyDetailService)
        {
            _companyFollowerService = companyFollowerService;
            _companyDetailService = companyDetailService;
        }

        [Authorize]
        public IActionResult AddCompanyFollower(int companyUserId)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            _companyFollowerService.CreateCompanyFollower(companyUserId, int.Parse(userId));
            var returnedCompanyId = _companyDetailService.GetCompanyIdByCompanyUserId(companyUserId);

            return Redirect(Url.Action("GetCompanyDetail", "CompanyDetail", new { CompanyDetailId = returnedCompanyId }));

        }

        [Authorize]
        public IActionResult DeleteCompanyFollower(int companyUserId)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            _companyFollowerService.RemoveCompanyFollower(companyUserId, int.Parse(userId));
            var returnedCompanyId = _companyDetailService.GetCompanyIdByCompanyUserId(companyUserId);

            return Redirect(Url.Action("GetCompanyDetail", "CompanyDetail", new { CompanyDetailId = returnedCompanyId }));
        }
    }
}
