using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KariyerNet.WebApp.Controllers
{
    public class JobAdvertisementController : Controller
    {

        private readonly IJobAdvertisementService _jobAdvertisementService;
        private readonly ICompanyFollowerService _companyFollowerService;

        public JobAdvertisementController(IJobAdvertisementService jobAdvertisementService, ICompanyFollowerService companyFollowerService)
        {
            _jobAdvertisementService = jobAdvertisementService;
            _companyFollowerService = companyFollowerService;
        }

        [Authorize(Roles = "Employer")]
        public IActionResult AddJobAdvertisement()
        {
            var model = _jobAdvertisementService.GetCreateJobAdvertisementFormData();
            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "Employer")]
        public IActionResult AddJobAdvertisement(CreateJobAdvertisementViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                _jobAdvertisementService.CreateJobAdvertisement(model, int.Parse(userId));
            }
            return Redirect(Url.Action("Index", "Home"));
        }


        [Authorize(Roles = "Employer")]
        public IActionResult EditJobAdvertisement(int jobAdvertisementId)
        {
            var model = new EditJobAdvertisementViewModel();
            model.JobAdvertisementId = jobAdvertisementId;
            model.GetJobAdvertisementViewModel = _jobAdvertisementService.GetJobAdvertisementDetailByJobAdvertisementId(jobAdvertisementId);
            model.createJobAdvertisementViewModel = _jobAdvertisementService.GetCreateJobAdvertisementFormData();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        public IActionResult EditJobAdvertisement(EditJobAdvertisementViewModel model, int jobAdvertisementId)
        {
            model.JobAdvertisementId = jobAdvertisementId;
            _jobAdvertisementService.EditJobAdvertisement(model);
            model.createJobAdvertisementViewModel = _jobAdvertisementService.GetCreateJobAdvertisementFormData();
            model.GetJobAdvertisementViewModel = _jobAdvertisementService.GetJobAdvertisementDetailByJobAdvertisementId(model.JobAdvertisementId);
            return View(model);
        }

        public IActionResult PublishJobAdvertisement(EditJobAdvertisementViewModel model, int jobAdvertisementId)
        {
            _jobAdvertisementService.PublishJobAdvertisement(jobAdvertisementId);
            return Redirect(Url.Action("GetJobAdvertisements", "CompanyDetail"));
        }




        [Authorize]
        public IActionResult GetJobAdvertisement(int jobAdvertisementId)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            _jobAdvertisementService.CreateAdvertisementViewCount(jobAdvertisementId, int.Parse(userId));
            var model = _jobAdvertisementService.GetJobAdvertisementDetailByJobAdvertisementId(jobAdvertisementId);

            return View(model);
        }


        [Authorize]
        public IActionResult GetJobAdvertisementToCompany(int jobAdvertisementId)
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            _jobAdvertisementService.CreateAdvertisementViewCount(jobAdvertisementId, int.Parse(userId));
            var model = _jobAdvertisementService.GetJobAdvertisementDetailToCompanyByJobAdvertisementId(jobAdvertisementId);
            //var modelList = new List<GetAdvertisementApplyToCompanyViewModel>();
            model.GetAdvertisementApplyToCompanyViewModel = _jobAdvertisementService.GetAdvertisementAppliesToCompany(jobAdvertisementId);
            return View(model);
        }



        public IActionResult SearchJobAdvertisement()
        {
            var model = _jobAdvertisementService.GetSearchJobAdvertisementFormData();
            var resultModel = _jobAdvertisementService.SearchJobAdvertisement(model);
            model.searchResultJobAdvertisementViewModel = resultModel;

            return View(model);
        }

        [HttpPost]
        public IActionResult SearchJobAdvertisement(SearchJobAdvertisementViewModel model)
        {
            var resultModel = _jobAdvertisementService.SearchJobAdvertisement(model);
            model = _jobAdvertisementService.GetSearchJobAdvertisementFormData();
            model.searchResultJobAdvertisementViewModel = resultModel;

            //var getFormModel = _jobAdvertisementService.GetSearchJobAdvertisementFormData();
            return View(model);
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
