using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;




namespace KariyerNet.WebApp.Controllers
{
    public class CompanyDetailController : Controller
    {

        private readonly ICompanyDetailService _companyDetailService;
        private readonly ISectorService _sectorService;
        private readonly IUserService _userService;
        private readonly IJobAdvertisementService _jobAdvertisementService;
        private readonly IUserDetailService _userDetailService;
        private readonly IUserCurriculumVitaeService _userCurriculumVitaeService;

        public CompanyDetailController(ICompanyDetailService companyDetailService, ISectorService sectorService, IUserService userService, IJobAdvertisementService jobAdvertisementService, IUserDetailService userDetailService, IUserCurriculumVitaeService userCurriculumVitaeService)
        {
            _companyDetailService = companyDetailService;
            _sectorService = sectorService;
            _userService = userService;
            _jobAdvertisementService = jobAdvertisementService;
            _userDetailService = userDetailService;
            _userCurriculumVitaeService = userCurriculumVitaeService;
        }

        [Authorize(Roles = "Employer")]
        public IActionResult EditCompanyDetail()
        {
            
            var model = _companyDetailService.GetCompanyDetail();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Employer")]
        public IActionResult EditCompanyDetail(EditCompanyDetailViewModel model)
        {
            if (ModelState.IsValid && model.ImageUrl!=null)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).Select(x => new KeyValuePair<string, string>(x.Key, x.Value.Errors.FirstOrDefault().ErrorMessage)).ToList();

                var uploadedFileExtension = Path.GetExtension(model.ImageUrl.FileName).ToLower();
                var acceptedFileExtensions = new List<string>()
                {
                        ".png",
                        ".jpg",
                        ".gif",
                        ".bmp",
                        ".jpeg"
                };
                //tanımladığınız dosya türleri arasında değil ise
                if (!acceptedFileExtensions.Contains(uploadedFileExtension))
                {
                    errors.Add(new KeyValuePair<string, string>("ProfileImageFile", "Düzgün dosya gir andaval!"));

                    return View();
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CompanyProfileImages", model.ImageUrl.FileName.Replace(" ", "_") + "");/* + Path.GetFileNameWithoutExtension(model.ProfileImageFile.FileName))*/

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.ImageUrl.CopyTo(stream);
                }
                model.ImagePath = path;

                //burayı düzelt resim girmez isen bu ife gelmiyor
                if (_companyDetailService.EditCompanyDetail(model) > 0)
                {
                    //kayıt başarılı tamamlandı, insanları profile geri gönder

                    return Redirect(Url.Action("Index", "Home"));
                }
                ModelState.AddModelError("SectorId", "Hatalı Sektör Seçimi");
            }
            model.SectorList = _sectorService.GetSectorList();
           
            return View(model);

        }

        //using for users
        public IActionResult GetCompanyDetail(int CompanyDetailId)
        {
            var model = _companyDetailService.GetCompanyDetailByCompanyId(CompanyDetailId);
            return View(model);
        }

        //using for companies
        public IActionResult GetCompanyProfileInformation()
        {
            var companyProfile = new CompanyProfileViewModel();
            var company = _userService.GetUser();
            companyProfile.UserClaimViewModel = company;
            companyProfile.CompanyDetail = _companyDetailService.GetCompanyDetail();
            return View(companyProfile);
        }

        public IActionResult GetJobAdvertisements()
        {
            var model= _jobAdvertisementService.GetJobAdvertisementToCompanies();
            return View(model);
        }

        public IActionResult GetJobAdvertisementsPassive()
        {
            var model = _jobAdvertisementService.GetJobAdvertisementToCompaniesPassive();
            return View(model);
        }

        public IActionResult GetJobAdvertisementDraft()
        {
            var model = _jobAdvertisementService.GetJobAdvertisementToCompaniesDraft();
            return View(model);
        }

        [Authorize(Roles = "Employer")]
        public IActionResult GetJobApplies()
        {
            var model = _jobAdvertisementService.GetSearchAppliesFormData();
            
            return View(model);
        }

        [Authorize(Roles = "Employer")]
        [HttpPost]
        public IActionResult GetJobApplies(SearchJobAppliesToCompanyViewModel model)
        {
            var viewModel = _jobAdvertisementService.GetSearchAppliesFormData();
            viewModel.userProfiles = _jobAdvertisementService.SearchJobApplies(model);
            return View(viewModel);
        }


        public IActionResult GetAppliedUserInformation(int userId)
        {
            var model = _userDetailService.GetUserDetailAndCvByUserId(userId);
            return View(model);
        }



        [Authorize(Roles = "Employer")]
        public IActionResult GetUserCurriculumVitaes()
        {
            var model = _userCurriculumVitaeService.GetSearchAppliesFormData();

            return View(model);
        }

        [Authorize(Roles = "Employer")]
        [HttpPost]
        public IActionResult GetUserCurriculumVitaes(SearchUserCurriculumVitaeToCompanyViewModel model)
        {
            var viewModel = _userCurriculumVitaeService.GetSearchAppliesFormData();
            viewModel.userProfiles = _userCurriculumVitaeService.SearchUserCurriculumVitae(model);
            return View(viewModel);
        }


    }
}
