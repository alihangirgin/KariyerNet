using KariyerNet.Business.Interfaces;
using KariyerNet.Common.ViewModels;
using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace KariyerNet.Business.Services
{
    public class UserCurriculumVitaeService : IUserCurriculumVitaeService
    {
        private readonly IUserCurriculumVitaeRepository _userCurriculumVitaeRepository;
        private readonly IUserService _userService;
        private readonly IDrivingLicenseService _drivingLicenseService;
        private readonly INationalityService _nationalityService;
        public UserCurriculumVitaeService(IUserCurriculumVitaeRepository userCurriculumVitaeRepository, IUserService userService, IDrivingLicenseService drivingLicenseService, INationalityService nationalityService)
        {
            _userCurriculumVitaeRepository = userCurriculumVitaeRepository;
            _userService = userService;
            _nationalityService = nationalityService;
            _drivingLicenseService = drivingLicenseService;
        }
        public List<UserCurriculumVitaeViewModel> GetUserCurriculumVitaesByUserId(int userId)
        {
            var userCurriculumVitaeList = new List<UserCurriculumVitaeViewModel>();
            var curriculumVitaes = _userCurriculumVitaeRepository.GetAll(x => x.UserId == userId && x.DeleteDate == null);
            if (curriculumVitaes != null)
            {
                foreach (var item in curriculumVitaes)
                {
                    var userCurriculumVitae = new UserCurriculumVitaeViewModel();
                    userCurriculumVitae.CVName = item.CVName;
                    userCurriculumVitae.DeleteDate = item.DeleteDate;
                    userCurriculumVitae.FilePath = item.FilePath;
                    userCurriculumVitae.PublishDate = item.PublishDate;
                    userCurriculumVitae.PublishDeleteDate = item.PublishDeleteDate;
                    userCurriculumVitae.UserId = item.UserId;
                    userCurriculumVitae.CreateDate = item.CreateDate;
                    userCurriculumVitae.UpdateDate = item.UpdateDate;
                    userCurriculumVitae.Id = item.Id;
                    userCurriculumVitaeList.Add(userCurriculumVitae);
                }

            }
            return userCurriculumVitaeList;
        }

        public UserCurriculumVitaeViewModel GetPublishedUserCurriculumVitaesByUserId(int userId)
        {
            var curriculumVitaes = _userCurriculumVitaeRepository.Get(x => x.UserId == userId && x.PublishDate != null);
            var userCurriculumVitae = new UserCurriculumVitaeViewModel();
            if (curriculumVitaes != null)
            {
                userCurriculumVitae.Id = curriculumVitaes.Id;
                userCurriculumVitae.CVName = curriculumVitaes.CVName;
                userCurriculumVitae.DeleteDate = curriculumVitaes.DeleteDate;
                userCurriculumVitae.FilePath = curriculumVitaes.FilePath;
                userCurriculumVitae.PublishDate = curriculumVitaes.PublishDate;
                userCurriculumVitae.PublishDeleteDate = curriculumVitaes.PublishDeleteDate;
                userCurriculumVitae.UserId = curriculumVitaes.UserId;
                userCurriculumVitae.CreateDate = curriculumVitaes.CreateDate;
                userCurriculumVitae.UpdateDate = curriculumVitaes.UpdateDate;
            }
            return userCurriculumVitae;
        }


        public void PublishCurriculumVitae(int userId, int curriculumVitaeId)
        {
            var curriculumVitaeList = _userCurriculumVitaeRepository.GetAll(x => x.UserId == userId).ToList();
            foreach (var item in curriculumVitaeList)
            {
                if (item.Id == curriculumVitaeId)
                {
                    item.PublishDate = DateTime.Now;
                    item.PublishDeleteDate = null;
                }
                else if (item.PublishDate != null)
                {
                    item.PublishDate = null;
                    item.PublishDeleteDate = DateTime.Now;
                }
            }
            try
            {
                _userCurriculumVitaeRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }

        public void RemovePublishCurriculumVitae(int userId, int curriculumVitaeId)
        {
            var curriculumVitaeList = _userCurriculumVitaeRepository.GetAll(x => x.UserId == userId).ToList();
            foreach (var item in curriculumVitaeList)
            {
                if (item.Id == curriculumVitaeId)
                {
                    item.PublishDate = null;
                    item.PublishDeleteDate = DateTime.Now;
                }
            }
            try
            {
                _userCurriculumVitaeRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }

        public List<KeyValuePair<string, string>> AddCurriculumVitae(AddUserCurriculumVitaeViewModel model)
        {
            var errorList = new List<KeyValuePair<string, string>>();
            var userId = _userService.GetUser().UserId;
            var isCvNameCheck = _userCurriculumVitaeRepository.Get(x => x.UserId == userId && x.CVName == model.CVName && x.DeleteDate == null);
            if (isCvNameCheck == null)
            {
                var userCurriculumVitae = new UserCurriculumVitae();
                userCurriculumVitae.CVName = model.CVName;
                userCurriculumVitae.FilePath = model.FilePath;
                userCurriculumVitae.CreateDate = DateTime.Now;
                userCurriculumVitae.UserId = userId;
                _userCurriculumVitaeRepository.Add(userCurriculumVitae);

                try
                {
                    _userCurriculumVitaeRepository.SaveChanges();

                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    errorList.Add(new KeyValuePair<string, string>("CVName", "CV Oluşturulamadı"));
                }

            }
            else
            {
                errorList.Add(new KeyValuePair<string, string>("CVName", "Bu isimde Cv zaten var"));
            }
            return errorList;
        }
        public void DeleteCurriculumVitae(int curriculumVitaeId)
        {
            var userId = _userService.GetUser().UserId;
            var isCvCheck = _userCurriculumVitaeRepository.Get(x => x.UserId == userId && x.Id == curriculumVitaeId);
            if (isCvCheck != null && isCvCheck.PublishDate == null)
            {
                isCvCheck.DeleteDate = DateTime.Now;

                try
                {
                    _userCurriculumVitaeRepository.SaveChanges();
                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }
        }



        public SearchUserCurriculumVitaeToCompanyViewModel GetSearchAppliesFormData()
        {
            var editUserDetail = new SearchUserCurriculumVitaeToCompanyViewModel();

            editUserDetail.DrivingLicenseList = _drivingLicenseService.GetDrivingLicenseList();
            editUserDetail.NationalityList = _nationalityService.GetNationalityList();

            return editUserDetail;
        }

        public List<UserProfileViewModel> SearchUserCurriculumVitae(SearchUserCurriculumVitaeToCompanyViewModel model)
        {
            var foundedAppliedUsers = new List<UserProfileViewModel>();
            var query = _userCurriculumVitaeRepository.GetAll(x => x.PublishDate != null).Include("User").Where(x => true);

            if (model.NameSurname != null)
            {
                query = query.Where(x => x.User.UserName.Contains(model.NameSurname));
            }

            if (model.Gender != 0)
            {
                var userIdListGender = _userService.GetUserIdListByGender(model.Gender);
                query = query.Where(x => userIdListGender.Any(y => y == x.UserId));
            }


            if (model.DrivingLicenseId != 0)
            {
                var userIdListDrivingLicense = _userService.GetUserIdByDrivingLicenseId(model.DrivingLicenseId);
                query = query.Where(x => userIdListDrivingLicense.Any(y => y == x.UserId));
            }

            if (model.NationalityId != 0)
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

                foundedAppliedUsers.Add(foundedUser);
            }
            return foundedAppliedUsers;
        }



    }
}
