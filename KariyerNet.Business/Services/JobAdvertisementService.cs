using KariyerNet.Business.Interfaces;
using KariyerNet.Common.Enums;
using KariyerNet.Common.ViewModels;
using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KariyerNet.Business.Services
{
    public class JobAdvertisementService : IJobAdvertisementService
    {

        private readonly IJobAdvertisementRepository _jobAdvertisementRepository;
        private readonly ICityService _cityService;
        private readonly IEducationLevelService _educationLevelService;
        private readonly IDepartmantService _departmantService;
        private readonly IWorkTypeService _workTypeService;
        private readonly IPositionService _positionService;
        private readonly ICompanyDetailService _companyDetailService;
        private readonly ISectorService _sectorService;
        private readonly IUserService _userService;
        private readonly IAdvertisementApplyRepository _advertisementApplyRepository;
        private readonly IAdvertisementViewCountRepository _advertisementViewCountRepository;
        private readonly INationalityService _nationalityService;
        private readonly IDrivingLicenseService _drivingLicenseService;
        private readonly IUserDetailService _userDetailService;


        public JobAdvertisementService(IJobAdvertisementRepository jobAdvertisementRepository, ICityService cityService, IEducationLevelService educationLevelService, IDepartmantService departmantService, IWorkTypeService workTypeService, IPositionService positionService, ICompanyDetailService companyDetailService, ISectorService sectorService, IUserService userService, IAdvertisementApplyRepository advertisementApplyRepository, IAdvertisementViewCountRepository advertisementViewCountRepository, INationalityService nationalityService, IDrivingLicenseService drivingLicenseService, IUserDetailService userDetailService)
        {
            _jobAdvertisementRepository = jobAdvertisementRepository;
            _cityService = cityService;
            _educationLevelService = educationLevelService;
            _departmantService = departmantService;
            _workTypeService = workTypeService;
            _positionService = positionService;
            _companyDetailService = companyDetailService;
            _sectorService = sectorService;
            _nationalityService = nationalityService;
            _drivingLicenseService = drivingLicenseService;
            _userService = userService;
            _advertisementApplyRepository = advertisementApplyRepository;
            _advertisementViewCountRepository = advertisementViewCountRepository;
            _userDetailService = userDetailService;
        }

        public int CreateJobAdvertisement(CreateJobAdvertisementViewModel model, int userId)
        {

            var jobAdvertisement = new JobAdvertisement();
            jobAdvertisement.CompanyUserId = userId;
            jobAdvertisement.CityId = model.CityId;
            //jobAdvertisement.UserId = userId;
            jobAdvertisement.CreateDate = DateTime.Now;
            jobAdvertisement.AvailableJobCount = model.AvailableJobCount;
            jobAdvertisement.JobTitle = model.JobTitle;
            jobAdvertisement.EducationLevelId = model.EducationLevelId;
            jobAdvertisement.DepartmantId = model.DepartmantId;
            jobAdvertisement.WorkTypeId = model.WorkTypeId;
            jobAdvertisement.PositionId = model.PositionId;
            jobAdvertisement.JobDefinition = model.JobDefinition;
            jobAdvertisement.RequiredExperience = model.RequiredExperience;
            jobAdvertisement.AvailableJobCount = model.AvailableJobCount;
            jobAdvertisement.ExpireDate = model.ExpireDate;

            if(model.Publish==true)
            {
                jobAdvertisement.PublishDate = DateTime.Now;
                jobAdvertisement.UpdateDate = DateTime.Now;
            }

            _jobAdvertisementRepository.Add(jobAdvertisement);

            try
            {
                _jobAdvertisementRepository.SaveChanges();
                return jobAdvertisement.Id;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }


        public void PublishJobAdvertisement(int jobAdvertisementId)
        {
            JobAdvertisement jobAdvertisement = _jobAdvertisementRepository.Get(x => x.Id == jobAdvertisementId);
            if (jobAdvertisement != null)
            {

                //jobAdvertisement.CompanyUserId = user.UserId;
                //jobAdvertisement.CityId = model.GetJobAdvertisementViewModel.CityId;
                //jobAdvertisement.CreateDate = DateTime.Now;
                //jobAdvertisement.AvailableJobCount = model.GetJobAdvertisementViewModel.AvailableJobCount;
                //jobAdvertisement.JobTitle = model.GetJobAdvertisementViewModel.JobTitle;
                //jobAdvertisement.EducationLevelId = model.GetJobAdvertisementViewModel.EducationLevelId;
                //jobAdvertisement.DepartmantId = model.GetJobAdvertisementViewModel.DepartmantId;
                //jobAdvertisement.WorkTypeId = model.GetJobAdvertisementViewModel.WorkTypeId;
                //jobAdvertisement.PositionId = model.GetJobAdvertisementViewModel.PositionId;
                //jobAdvertisement.JobDefinition = model.GetJobAdvertisementViewModel.JobDefinition;
                //jobAdvertisement.RequiredExperience = model.GetJobAdvertisementViewModel.RequiredExperience;
                //jobAdvertisement.AvailableJobCount = model.GetJobAdvertisementViewModel.AvailableJobCount;
                //jobAdvertisement.ExpireDate = model.GetJobAdvertisementViewModel.ExpireDate;
                jobAdvertisement.PublishDate = DateTime.Now;
                jobAdvertisement.UpdateDate = DateTime.Now;
                try
                {
                    _jobAdvertisementRepository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }
        }

        public void EditJobAdvertisement(EditJobAdvertisementViewModel model)
        {
            var user = _userService.GetUser();
            JobAdvertisement jobAdvertisement = _jobAdvertisementRepository.Get(x => x.Id == model.JobAdvertisementId);
            if (jobAdvertisement != null)
            {
                //jobAdvertisement.Id = model.JobAdvertisementId;
                jobAdvertisement.CompanyUserId = user.UserId;
                jobAdvertisement.CityId = model.GetJobAdvertisementViewModel.CityId;
                jobAdvertisement.CreateDate = DateTime.Now;
                jobAdvertisement.AvailableJobCount = model.GetJobAdvertisementViewModel.AvailableJobCount;
                jobAdvertisement.JobTitle = model.GetJobAdvertisementViewModel.JobTitle;
                jobAdvertisement.EducationLevelId = model.GetJobAdvertisementViewModel.EducationLevelId;
                jobAdvertisement.DepartmantId = model.GetJobAdvertisementViewModel.DepartmantId;
                jobAdvertisement.WorkTypeId = model.GetJobAdvertisementViewModel.WorkTypeId;
                jobAdvertisement.PositionId = model.GetJobAdvertisementViewModel.PositionId;
                jobAdvertisement.JobDefinition = model.GetJobAdvertisementViewModel.JobDefinition;
                jobAdvertisement.RequiredExperience = model.GetJobAdvertisementViewModel.RequiredExperience;
                jobAdvertisement.AvailableJobCount = model.GetJobAdvertisementViewModel.AvailableJobCount;
                jobAdvertisement.ExpireDate = model.GetJobAdvertisementViewModel.ExpireDate;

                //_jobAdvertisementRepository.Add(jobAdvertisement);

                try
                {
                    _jobAdvertisementRepository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }

        }

        public CreateJobAdvertisementViewModel GetCreateJobAdvertisementFormData()
        {
            var model = new CreateJobAdvertisementViewModel();
            model.CityList = _cityService.GetCityListToForm();
            model.EducationLevelList = _educationLevelService.GetEducationLevelList();
            model.DepartmantList = _departmantService.GetDepartmantList();
            model.WorkTypeList = _workTypeService.GetWorkTypeList();
            model.PositionList = _positionService.GetPositionList();

            return model;
        }


        public GetJobAdvertisementViewModel GetJobAdvertisementDetailByJobAdvertisementId(int Id)
        {
            var model = new GetJobAdvertisementViewModel();
            JobAdvertisement jobAdvertisement = _jobAdvertisementRepository.Get(x => x.Id == Id);
            if (jobAdvertisement != null)
            {
                model.JobAdvertisementId = jobAdvertisement.Id;
                model.CityName = _cityService.GetCityNameByCityId(jobAdvertisement.CityId);
                model.DepartmantName = _departmantService.GetDepartmantNameByDepartmantId(jobAdvertisement.DepartmantId);
                model.EducationLevelName = _educationLevelService.GetEdcuationLevelNameByEducationLevelId(jobAdvertisement.EducationLevelId);
                model.PositionName = _positionService.GetPositionNameByPositionId(jobAdvertisement.PositionId);
                model.WorkTypeName = _workTypeService.GetWorkTypeNameByWorkTypeId(jobAdvertisement.WorkTypeId);
                model.CompanyName = _companyDetailService.GetCompanyDetailNameByCompanyUserId(jobAdvertisement.CompanyUserId);
                model.CityId = jobAdvertisement.CityId;
                model.DepartmantId = jobAdvertisement.DepartmantId;
                model.EducationLevelId = jobAdvertisement.EducationLevelId;
                model.PositionId = jobAdvertisement.PositionId;
                model.WorkTypeId = jobAdvertisement.WorkTypeId;
                model.CreateDate = jobAdvertisement.CreateDate;
                model.ExpireDate = jobAdvertisement.ExpireDate;
                model.JobDefinition = jobAdvertisement.JobDefinition;
                model.RequiredExperience = jobAdvertisement.RequiredExperience;
                model.CompanyUserId = jobAdvertisement.CompanyUserId;
                model.AvailableJobCount = jobAdvertisement.AvailableJobCount;
                model.ViewCount = GetAdvertisementViewCountByJobAdvertisementId(Id);
                model.JobTitle = jobAdvertisement.JobTitle;
                //model.isUserApplied = _advertisementApplyService.checkIsUserAppliedByUserId(model.JobAdvertisementId);
                model.isUserApplied = checkIsUserAppliedByUserId(model.JobAdvertisementId);
            }

            return model;
        }



        public GetJobAdvertisementToCompanyViewModel GetJobAdvertisementDetailToCompanyByJobAdvertisementId(int Id)
        {
            var model = new GetJobAdvertisementToCompanyViewModel();
            JobAdvertisement jobAdvertisement = _jobAdvertisementRepository.Get(x => x.Id == Id);
            if (jobAdvertisement != null)
            {
                model.JobAdvertisementId = jobAdvertisement.Id;
                model.CityName = _cityService.GetCityNameByCityId(jobAdvertisement.CityId);
                model.DepartmantName = _departmantService.GetDepartmantNameByDepartmantId(jobAdvertisement.DepartmantId);
                model.EducationLevelName = _educationLevelService.GetEdcuationLevelNameByEducationLevelId(jobAdvertisement.EducationLevelId);
                model.PositionName = _positionService.GetPositionNameByPositionId(jobAdvertisement.PositionId);
                model.WorkTypeName = _workTypeService.GetWorkTypeNameByWorkTypeId(jobAdvertisement.WorkTypeId);
                model.CompanyName = _companyDetailService.GetCompanyDetailNameByCompanyUserId(jobAdvertisement.CompanyUserId);
                model.CityId = jobAdvertisement.CityId;
                model.DepartmantId = jobAdvertisement.DepartmantId;
                model.EducationLevelId = jobAdvertisement.EducationLevelId;
                model.PositionId = jobAdvertisement.PositionId;
                model.WorkTypeId = jobAdvertisement.WorkTypeId;
                model.CreateDate = jobAdvertisement.CreateDate;
                model.ExpireDate = jobAdvertisement.ExpireDate;
                model.JobDefinition = jobAdvertisement.JobDefinition;
                model.RequiredExperience = jobAdvertisement.RequiredExperience;
                model.CompanyUserId = jobAdvertisement.CompanyUserId;
                model.AvailableJobCount = jobAdvertisement.AvailableJobCount;
                model.ViewCount = GetAdvertisementViewCountByJobAdvertisementId(Id);
                model.JobTitle = jobAdvertisement.JobTitle;
                //model.isUserApplied = _advertisementApplyService.checkIsUserAppliedByUserId(model.JobAdvertisementId);
                model.isUserApplied = checkIsUserAppliedByUserId(model.JobAdvertisementId);
            }

            return model;
        }





        public List<GetJobAdvertisementsToCompanyViewModel> GetJobAdvertisementToCompanies()
        {

            var jobAdvertisementList = new List<GetJobAdvertisementsToCompanyViewModel>();
            var user = _userService.GetUser();
            //JobAdvertisement jobAdvertisement = _jobAdvertisementRepository.Get(x => x.CompanyUserId == user.UserId);
            var jobAdvertisement = _jobAdvertisementRepository.GetAll(x => x.CompanyUserId == user.UserId && x.ExpireDate > DateTime.Now && x.PublishDate != null).ToList();
            if (jobAdvertisement != null)
            {
                foreach (var item in jobAdvertisement)
                {
                    var model = new GetJobAdvertisementsToCompanyViewModel();
                    model.JobAdvertisementId = item.Id;
                    model.CityName = _cityService.GetCityNameByCityId(item.CityId);
                    model.DepartmantName = _departmantService.GetDepartmantNameByDepartmantId(item.DepartmantId);
                    model.EducationLevelName = _educationLevelService.GetEdcuationLevelNameByEducationLevelId(item.EducationLevelId);
                    model.PositionName = _positionService.GetPositionNameByPositionId(item.PositionId);
                    model.WorkTypeName = _workTypeService.GetWorkTypeNameByWorkTypeId(item.WorkTypeId);
                    model.CompanyName = _companyDetailService.GetCompanyDetailNameByCompanyUserId(item.CompanyUserId);
                    model.CityId = item.CityId;
                    model.DepartmantId = item.DepartmantId;
                    model.EducationLevelId = item.EducationLevelId;
                    model.PositionId = item.PositionId;
                    model.WorkTypeId = item.WorkTypeId;
                    model.CreateDate = item.CreateDate;
                    model.ExpireDate = item.ExpireDate;
                    model.JobDefinition = item.JobDefinition;
                    model.RequiredExperience = item.RequiredExperience;
                    model.CompanyUserId = item.CompanyUserId;
                    model.AvailableJobCount = item.AvailableJobCount;
                    model.ViewCount = GetAdvertisementViewCountByJobAdvertisementId(model.JobAdvertisementId);
                    model.JobTitle = item.JobTitle;
                    model.numberOfApplies = GetJobApplyCount(model.JobAdvertisementId);

                    jobAdvertisementList.Add(model);
                }

            }

            return jobAdvertisementList;
        }

        public List<GetJobAdvertisementsToCompanyViewModel> GetJobAdvertisementToCompaniesPassive()
        {

            var jobAdvertisementList = new List<GetJobAdvertisementsToCompanyViewModel>();
            var user = _userService.GetUser();
            //JobAdvertisement jobAdvertisement = _jobAdvertisementRepository.Get(x => x.CompanyUserId == user.UserId);
            var jobAdvertisement = _jobAdvertisementRepository.GetAll(x => x.CompanyUserId == user.UserId && x.ExpireDate <= DateTime.Now && x.PublishDate != null).ToList();
            if (jobAdvertisement != null)
            {
                foreach (var item in jobAdvertisement)
                {
                    var model = new GetJobAdvertisementsToCompanyViewModel();
                    model.JobAdvertisementId = item.Id;
                    model.CityName = _cityService.GetCityNameByCityId(item.CityId);
                    model.DepartmantName = _departmantService.GetDepartmantNameByDepartmantId(item.DepartmantId);
                    model.EducationLevelName = _educationLevelService.GetEdcuationLevelNameByEducationLevelId(item.EducationLevelId);
                    model.PositionName = _positionService.GetPositionNameByPositionId(item.PositionId);
                    model.WorkTypeName = _workTypeService.GetWorkTypeNameByWorkTypeId(item.WorkTypeId);
                    model.CompanyName = _companyDetailService.GetCompanyDetailNameByCompanyUserId(item.CompanyUserId);
                    model.CityId = item.CityId;
                    model.DepartmantId = item.DepartmantId;
                    model.EducationLevelId = item.EducationLevelId;
                    model.PositionId = item.PositionId;
                    model.WorkTypeId = item.WorkTypeId;
                    model.CreateDate = item.CreateDate;
                    model.ExpireDate = item.ExpireDate;
                    model.JobDefinition = item.JobDefinition;
                    model.RequiredExperience = item.RequiredExperience;
                    model.CompanyUserId = item.CompanyUserId;
                    model.AvailableJobCount = item.AvailableJobCount;
                    model.ViewCount = GetAdvertisementViewCountByJobAdvertisementId(model.JobAdvertisementId);
                    model.JobTitle = item.JobTitle;
                    model.numberOfApplies = GetJobApplyCount(model.JobAdvertisementId);

                    jobAdvertisementList.Add(model);
                }

            }

            return jobAdvertisementList;
        }


        public List<GetJobAdvertisementsToCompanyViewModel> GetJobAdvertisementToCompaniesDraft()
        {

            var jobAdvertisementList = new List<GetJobAdvertisementsToCompanyViewModel>();
            var user = _userService.GetUser();
            //JobAdvertisement jobAdvertisement = _jobAdvertisementRepository.Get(x => x.CompanyUserId == user.UserId);
            var jobAdvertisement = _jobAdvertisementRepository.GetAll(x => x.CompanyUserId == user.UserId && x.PublishDate == null).ToList();
            if (jobAdvertisement != null)
            {
                foreach (var item in jobAdvertisement)
                {
                    var model = new GetJobAdvertisementsToCompanyViewModel();
                    model.JobAdvertisementId = item.Id;
                    model.CityName = _cityService.GetCityNameByCityId(item.CityId);
                    model.DepartmantName = _departmantService.GetDepartmantNameByDepartmantId(item.DepartmantId);
                    model.EducationLevelName = _educationLevelService.GetEdcuationLevelNameByEducationLevelId(item.EducationLevelId);
                    model.PositionName = _positionService.GetPositionNameByPositionId(item.PositionId);
                    model.WorkTypeName = _workTypeService.GetWorkTypeNameByWorkTypeId(item.WorkTypeId);
                    model.CompanyName = _companyDetailService.GetCompanyDetailNameByCompanyUserId(item.CompanyUserId);
                    model.CityId = item.CityId;
                    model.DepartmantId = item.DepartmantId;
                    model.EducationLevelId = item.EducationLevelId;
                    model.PositionId = item.PositionId;
                    model.WorkTypeId = item.WorkTypeId;
                    model.CreateDate = item.CreateDate;
                    model.ExpireDate = item.ExpireDate;
                    model.JobDefinition = item.JobDefinition;
                    model.RequiredExperience = item.RequiredExperience;
                    model.CompanyUserId = item.CompanyUserId;
                    model.AvailableJobCount = item.AvailableJobCount;
                    model.ViewCount = GetAdvertisementViewCountByJobAdvertisementId(model.JobAdvertisementId);
                    model.JobTitle = item.JobTitle;
                    model.numberOfApplies = GetJobApplyCount(model.JobAdvertisementId);

                    jobAdvertisementList.Add(model);
                }

            }

            return jobAdvertisementList;
        }




        public GetJobAdvertisementViewModel GetJobAdvertisementDetailByJobAdvertisementIdWithoutUserLogin(int Id)
        {
            var model = new GetJobAdvertisementViewModel();
            JobAdvertisement jobAdvertisement = _jobAdvertisementRepository.Get(x => x.Id == Id);
            if (jobAdvertisement != null)
            {
                model.JobAdvertisementId = jobAdvertisement.Id;
                model.CityName = _cityService.GetCityNameByCityId(jobAdvertisement.CityId);
                model.DepartmantName = _departmantService.GetDepartmantNameByDepartmantId(jobAdvertisement.DepartmantId);
                model.EducationLevelName = _educationLevelService.GetEdcuationLevelNameByEducationLevelId(jobAdvertisement.EducationLevelId);
                model.PositionName = _positionService.GetPositionNameByPositionId(jobAdvertisement.PositionId);
                model.WorkTypeName = _workTypeService.GetWorkTypeNameByWorkTypeId(jobAdvertisement.WorkTypeId);
                model.CompanyName = _companyDetailService.GetCompanyDetailNameByCompanyUserId(jobAdvertisement.CompanyUserId);
                model.CityId = jobAdvertisement.CityId;
                model.DepartmantId = jobAdvertisement.DepartmantId;
                model.EducationLevelId = jobAdvertisement.EducationLevelId;
                model.PositionId = jobAdvertisement.PositionId;
                model.WorkTypeId = jobAdvertisement.WorkTypeId;
                model.CreateDate = jobAdvertisement.CreateDate;
                model.ExpireDate = jobAdvertisement.ExpireDate;
                model.JobDefinition = jobAdvertisement.JobDefinition;
                model.RequiredExperience = jobAdvertisement.RequiredExperience;
                model.CompanyUserId = jobAdvertisement.CompanyUserId;
                model.AvailableJobCount = jobAdvertisement.AvailableJobCount;
                model.ViewCount = GetAdvertisementViewCountByJobAdvertisementId(Id);
                model.JobTitle = jobAdvertisement.JobTitle;

            }

            return model;
        }



        public int GetJobAdvertisementIdByCompanyUserIdAndCreateDate(int companyUserId, DateTime createDate)
        {
            var jobAdvertisement = _jobAdvertisementRepository.GetAll(x => x.CompanyUserId == companyUserId)
                .ToList()
                .Where(x => x.CreateDate >= createDate)
                .ToList();
            return jobAdvertisement.FirstOrDefault().Id;
        }


        public SearchJobAdvertisementViewModel GetSearchJobAdvertisementFormData()
        {
            var model = new SearchJobAdvertisementViewModel();
            model.CityId = new List<int?>() { 0 };
            model.CityList = _cityService.GetCityListToForm();
            model.EducationLevelId = new List<int?>() { 0 };
            model.EducationLevelList = _educationLevelService.GetEducationLevelList();
            model.DepartmantId = new List<int?>() { 0 };
            model.DepartmantList = _departmantService.GetDepartmantList();
            model.WorkTypeId = new List<int?>() { 0 };
            model.WorkTypeList = _workTypeService.GetWorkTypeList();
            model.PositionId = new List<int?>() { 0 };
            model.PositionList = _positionService.GetPositionList();
            model.SectorId = new List<int?>() { 0 };
            model.SectorList = _sectorService.GetSectorList();

            return model;
        }


        public List<SearchResultJobAdvertisementViewModel> SearchJobAdvertisement(SearchJobAdvertisementViewModel model)
        {


            var query = _jobAdvertisementRepository.GetAll().Where(x => true);

            if (model.WhereToSearch == 1 && model.Text != null)
            {
                query = query.Where(x => x.JobTitle.Contains(model.Text) || x.JobDefinition.Contains(model.Text));
            }
            else if (model.WhereToSearch == 2 && model.Text != null)
            {
                query = query.Where(x => x.JobTitle.Contains(model.Text));
            }
            else if (model.WhereToSearch == 3 && model.Text != null)
            {
                var companyUserIdList = _companyDetailService.GetCompanyUserIdsByCompanyName(model.Text);
                query = query.Where(x => companyUserIdList.Any(y => y == x.CompanyUserId));
            }

            /*      <option selected value="1">Bütün İlanlar</option>
                    <option value="2">Bugünün İlanları</option>
                    <option value="3">Son 3 saat</option>
                    <option value="4">Son 8 saat</option>
                    <option value="5">Son 3 gün</option>
                    <option value="6">Son 7 gün</option>
                    <option value="7">Son 15 gün</option>
            */
            DateTime date = DateTime.MinValue;
            if (model.DateSearch == 7)
            {
                date = DateTime.Now.Date.AddDays(-15);
            }
            else if (model.DateSearch == 6)
            {
                date = DateTime.Now.Date.AddDays(-7);
            }
            else if (model.DateSearch == 5)
            {
                date = DateTime.Now.Date.AddDays(-3);
            }
            else if (model.DateSearch == 4)
            {
                date = DateTime.Now.AddHours(-8);
            }
            else if (model.DateSearch == 3)
            {
                date = DateTime.Now.AddHours(-3);
            }
            else if (model.DateSearch == 2)
            {
                date = DateTime.Now.Date;
            }

            if (date != DateTime.MinValue)
            {
                query = query.Where(x => x.CreateDate >= date);
            }



            if (model.SectorId != null && model.SectorId.Count > 0 && !model.SectorId.Contains(0))
            {
                var companyUserIdList = _companyDetailService.GetCompanyUserIdsBySectorId(model.SectorId);
                query = query.Where(x => companyUserIdList.Any(y => y == x.CompanyUserId));

            }
            if (model.DepartmantId != null && model.DepartmantId.Count > 0 && !model.DepartmantId.Contains(0))
            {
                query = query.Where(x => model.DepartmantId.Contains(x.DepartmantId));
            }
            if (model.EducationLevelId != null && model.EducationLevelId.Count > 0 && !model.EducationLevelId.Contains(0))
            {
                query = query.Where(x => model.EducationLevelId.Contains(x.EducationLevelId));
            }

            if (model.PositionId != null && model.PositionId.Count > 0 && !model.PositionId.Contains(0))
            {
                query = query.Where(x => model.PositionId.Contains(x.PositionId));
            }

            if (model.WorkTypeId != null && model.WorkTypeId.Count > 0 && !model.WorkTypeId.Contains(0))
            {
                query = query.Where(x => model.WorkTypeId.Contains(x.WorkTypeId));
            }
            if (model.CityId != null && model.CityId.Count > 0 && !model.CityId.Contains(0))
            {
                query = query.Where(x => model.CityId.Contains(x.CityId));
            }


            if (model.RequiredExperience == 2)
            {
                query = query.Where(x => x.RequiredExperience == 0);
            }


            var foundedJobAdvertisements = new List<SearchResultJobAdvertisementViewModel>();

            foreach (var item in query.ToList())
            {
                var jobAdvertisement = new SearchResultJobAdvertisementViewModel();
                jobAdvertisement.CityName = _cityService.GetCityNameByCityId(item.CityId);
                jobAdvertisement.EducationLevelName = _educationLevelService.GetEdcuationLevelNameByEducationLevelId(item.EducationLevelId);
                jobAdvertisement.CompanyName = _companyDetailService.GetCompanyDetailNameByCompanyUserId(item.CompanyUserId);
                jobAdvertisement.CreateDate = item.CreateDate;
                jobAdvertisement.AvailableJobCount = item.AvailableJobCount;
                jobAdvertisement.DepartmantName = _departmantService.GetDepartmantNameByDepartmantId(item.DepartmantId);
                jobAdvertisement.ExpireDate = item.ExpireDate;
                jobAdvertisement.JobAdvertisementId = item.Id;
                jobAdvertisement.JobDefinition = item.JobDefinition;
                jobAdvertisement.JobTitle = item.JobTitle;
                jobAdvertisement.PositionName = _positionService.GetPositionNameByPositionId(item.PositionId);
                jobAdvertisement.RequiredExperience = item.RequiredExperience;
                jobAdvertisement.WorkTypeName = _workTypeService.GetWorkTypeNameByWorkTypeId(item.WorkTypeId);
                foundedJobAdvertisements.Add(jobAdvertisement);

            }
            return foundedJobAdvertisements;
        }


        public List<UserProfileViewModel> SearchJobApplies(SearchJobAppliesToCompanyViewModel model)
        {
            var foundedAppliedUsers = new List<UserProfileViewModel>();
            var query = _advertisementApplyRepository.GetAll().Include("JobAdvertisement").Include("User").Where(x => true);
            if (model.JobAdvertisementTitle != null)
            {
                query = query.Where(x => x.JobAdvertisement.JobTitle.Contains(model.JobAdvertisementTitle));

            }
            if(model.NameSurname!=null)
            {
                query = query.Where(x => x.User.UserName.Contains(model.NameSurname));
            }

            if(model.Gender!=0)
            {
                var userIdListGender = _userService.GetUserIdListByGender(model.Gender);
                query = query.Where(x => userIdListGender.Any(y => y == x.UserId));
            }


            if(model.DrivingLicenseId !=0)
            {
                var userIdListDrivingLicense = _userService.GetUserIdByDrivingLicenseId(model.DrivingLicenseId);
                query = query.Where(x => userIdListDrivingLicense.Any(y => y == x.UserId));
            }
            
            if(model.NationalityId !=0)
            {
                var userIdListNationality = _userService.GetUserIdByNationalityId(model.NationalityId);
                query = query.Where(x => userIdListNationality.Any(y => y == x.UserId));
            }


            foreach (var item in query.ToList())
            {
                var foundedUser = new UserProfileViewModel();
                foundedUser.UserClaimViewModel = new UserClaimViewModel();
                foundedUser.UserClaimViewModel.NameSurname = item.User.NameSurname;
                foundedUser.UserClaimViewModel.UserId = item.UserId;
                foundedUser.JobTitle = item.JobAdvertisement.JobTitle;

                foundedAppliedUsers.Add(foundedUser);
            }
            return foundedAppliedUsers;
        }

        public string GetJobAdvertisementTittleByJobAdvertisementId(int jobAdvertisementId)
        {
            return _jobAdvertisementRepository.Get(x => x.Id == jobAdvertisementId).JobTitle;
        }

        public bool checkIsUserAppliedByUserId(int jobAdvertisementId)
        {
            var userId = _userService.GetUser().UserId;
            var checkAdvertisementApply = _advertisementApplyRepository.Get(x => x.UserId == userId && x.JobAdvertisementId == jobAdvertisementId);
            if (checkAdvertisementApply != null)
            {
                if (checkAdvertisementApply.DeleteDate == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }//



        public void CreateAdvertisementApply(int jobAdvertisementId, int userId)
        {
            var isApplied = _advertisementApplyRepository.Get(x => x.UserId == userId && x.JobAdvertisementId == jobAdvertisementId);
            if (isApplied != null)
            {
                isApplied.DeleteDate = null;
                isApplied.UpdateDate = DateTime.Now;
                try
                {
                    _advertisementApplyRepository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
                return;
            }

            var advertisementApply = new AdvertisementApply();
            advertisementApply.JobAdvertisementId = jobAdvertisementId;
            advertisementApply.UserId = userId;
            advertisementApply.CreateDate = DateTime.Now;
            advertisementApply.DeleteDate = null;

            _advertisementApplyRepository.Add(advertisementApply);

            try
            {
                _advertisementApplyRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }

        public void DeleteAdvirtisementApply(int jobAdvertisementId, int userId)
        {

            var advertisementApply = _advertisementApplyRepository.Get(x => x.JobAdvertisementId == jobAdvertisementId && x.UserId == userId);
            if (advertisementApply != null)
            {
                advertisementApply.DeleteDate = DateTime.Now;
                advertisementApply.UpdateDate = DateTime.Now;
                try
                {
                    _advertisementApplyRepository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }
        }





        public List<GetAdvertisementApplyViewModel> GetAdvertisementApplies()
        {

            //var userId = _userService.GetUser().UserId;
            //var advertisementApplyCheck=_advertisementApplyRepository.GetAll(x => x.UserId == userId).Include("CompanyDetail").Include("JobAdvertisement");
            //var advertisementList = new List<GetAdvertisementApplyViewModel>();
            //if(advertisementApplyCheck !=null)
            //{
            //    foreach (var item in advertisementApplyCheck)
            //    {
            //        var advertisement = new GetAdvertisementApplyViewModel();
            //        advertisement.CompanyName=item.

            //    }
            //}

            var userId = _userService.GetUser().UserId;
            var advertisementApplyCheck = _advertisementApplyRepository.GetAll(x => x.UserId == userId).ToList();
            var advertisementList = new List<GetAdvertisementApplyViewModel>();
            if (advertisementApplyCheck != null)
            {
                foreach (var item in advertisementApplyCheck)
                {
                    var advertisement = new GetAdvertisementApplyViewModel();

                    var companyUserId = GetCompanyUserIdByJobAdvertisementId(item.JobAdvertisementId);
                    advertisement.CompanyName = _companyDetailService.GetCompanyDetailNameByCompanyUserId(companyUserId);
                    advertisement.JobAdvertisementName = GetJobAdvertisementTittleByJobAdvertisementId(item.JobAdvertisementId);
                    advertisement.CreateDate = item.CreateDate;
                    advertisement.UpdateDate = item.UpdateDate;
                    advertisement.JobAdvertisementId = item.JobAdvertisementId;
                    advertisementList.Add(advertisement);
                }
                return advertisementList;
            }
            return advertisementList;
        }
        public int JobAdvertisementCount()
        {
            return _jobAdvertisementRepository.GetAll(x => x.DeleteDate == null && x.ExpireDate >= DateTime.Now).Count();
        }


        public List<GetAdvertisementApplyToCompanyViewModel> GetAdvertisementAppliesToCompany(int JobAdvertisementId)
        {

            var userId = _userService.GetUser().UserId;
            var advertisementApplyCheck = _advertisementApplyRepository.GetAll(x => x.JobAdvertisementId == JobAdvertisementId).Include("User").ToList();
            var advertisementList = new List<GetAdvertisementApplyToCompanyViewModel>();
            if (advertisementApplyCheck != null)
            {
                foreach (var item in advertisementApplyCheck)
                {
                    var advertisement = new GetAdvertisementApplyToCompanyViewModel();

                    var companyUserId = GetCompanyUserIdByJobAdvertisementId(item.JobAdvertisementId);
                    advertisement.JobAdvertisementId = item.JobAdvertisementId;
                    advertisement.UserId = item.UserId;
                    advertisement.UserName = item.User.UserName;
                    advertisement.CreateDate = item.CreateDate;
                    advertisement.UpdateDate = item.UpdateDate;

                    advertisementList.Add(advertisement);
                }
                return advertisementList;
            }
            return advertisementList;
        }


        public int GetJobApplyCount(int JobAdvertisementId)
        {
            var count = _advertisementApplyRepository.GetAll(x => x.JobAdvertisementId == JobAdvertisementId).ToList().Count();
            return count;
        }

        //advertisement viewcount
        public void CreateAdvertisementViewCount(int jobAdvertisementId, int userId)
        {
            var isViewed = _advertisementViewCountRepository.Get(x => x.UserId == userId && x.JobAdvertisementId == jobAdvertisementId);
            if (isViewed != null)
            {
                return;
            }
            var advertisementViewCount = new AdvertisementViewCount();
            advertisementViewCount.JobAdvertisementId = jobAdvertisementId;
            advertisementViewCount.UserId = userId;
            advertisementViewCount.CreateDate = DateTime.Now;

            _advertisementViewCountRepository.Add(advertisementViewCount);

            try
            {
                _advertisementViewCountRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }


        public int GetAdvertisementViewCountByJobAdvertisementId(int jobAdvertisementId)
        {
            return _advertisementViewCountRepository.GetAll(x => x.JobAdvertisementId == jobAdvertisementId).ToList().Count;
        }



        public List<GetHomeSliderViewModel> GetMostViewedJobAdvertisement()
        {

  

            var jobAdvertisementsWithViews = new Dictionary<int, int>();
            var viewCounts = _advertisementViewCountRepository.GetAll().Include("JobAdvertisement").ToList();        

            foreach (var item in viewCounts)
            {
                if (!jobAdvertisementsWithViews.ContainsKey(item.JobAdvertisementId) && item.JobAdvertisement.ExpireDate > DateTime.Now)
                {
                    jobAdvertisementsWithViews.Add(item.JobAdvertisementId, GetAdvertisementViewCountByJobAdvertisementId(item.JobAdvertisementId));
                }

            }
            var orderedjobAdvertisementsWithViews = jobAdvertisementsWithViews.OrderByDescending(x => x.Value).Take(12).ToDictionary(x => x.Key, x => x.Value);

            var modelList = new List<GetHomeSliderViewModel>();
            foreach (var item in orderedjobAdvertisementsWithViews.Keys)
            {
                var model = new GetHomeSliderViewModel();
                model.JobAdvertisementId = item;
                var companyUserId = GetJobAdvertisementDetailByJobAdvertisementIdWithoutUserLogin(model.JobAdvertisementId).CompanyUserId;
                model.CompanyName = _companyDetailService.GetCompanyDetailNameByCompanyUserId(companyUserId);
                var cityId = GetJobAdvertisementDetailByJobAdvertisementIdWithoutUserLogin(model.JobAdvertisementId).CityId;
                model.CityName = _cityService.GetCityNameByCityId(cityId);
                model.JobTitle = GetJobAdvertisementDetailByJobAdvertisementIdWithoutUserLogin(model.JobAdvertisementId).JobTitle;
                var image = _companyDetailService.GetCompanyDetailByCompanyUserId(companyUserId).ImageUrl;
                model.ImageName = Path.GetFileName(image);

                modelList.Add(model);
            }

            return modelList;
        }


        public SearchJobAppliesToCompanyViewModel GetSearchAppliesFormData()
        {
            var editUserDetail = new SearchJobAppliesToCompanyViewModel();

            editUserDetail.DrivingLicenseList = _drivingLicenseService.GetDrivingLicenseList();
            editUserDetail.NationalityList = _nationalityService.GetNationalityList();

            return editUserDetail;
        }


        public int GetCompanyUserIdByJobAdvertisementId(int jobAdvertisementId)
        {

            return _jobAdvertisementRepository.Get(x => x.Id == jobAdvertisementId).CompanyUserId;
        }


    }

}




