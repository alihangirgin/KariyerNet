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
    public class AdvertisementApplyController : Controller
    {

        private readonly IJobAdvertisementService _jobAdvertisementService;

        public AdvertisementApplyController(IJobAdvertisementService jobAdvertisementService)
        {
            _jobAdvertisementService = jobAdvertisementService;
        }

        [Authorize(Roles = "Employee")]
        public IActionResult AddAdvertisementApply(int jobAdvertisementId)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
        
            _jobAdvertisementService.CreateAdvertisementApply(jobAdvertisementId, int.Parse(userId));
            return Redirect(Url.Action("GetJobAdvertisement", "JobAdvertisement", new { jobAdvertisementId = jobAdvertisementId }));
        }

        [Authorize(Roles = "Employee")]
        public IActionResult RemoveAdvertisementApply(int jobAdvertisementId)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;     
            _jobAdvertisementService.DeleteAdvirtisementApply(jobAdvertisementId, int.Parse(userId));
            return Redirect(Url.Action("GetJobAdvertisement", "JobAdvertisement", new { jobAdvertisementId = jobAdvertisementId }));
        }

    }
}
