using KariyerNet.Business.Interfaces;
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
    public class UserDetailService : IUserDetailService
    {
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IUserService _userService;
        private readonly INationalityService _nationalityService;
        private readonly IDrivingLicenseService _drivingLicenseService;
        private readonly IMessageService _messageService;
        private readonly IUserCurriculumVitaeService _userCurriculumVitaeService;

        public UserDetailService(IUserDetailRepository userDetailRepository, IUserService userService, INationalityService nationalityService, IDrivingLicenseService drivingLicenseService, IMessageService messageService, IUserCurriculumVitaeService userCurriculumVitaeService)
        {
            _userDetailRepository = userDetailRepository;
            _userService = userService;
            _nationalityService = nationalityService;
            _drivingLicenseService = drivingLicenseService;
            _messageService = messageService;
            _userCurriculumVitaeService = userCurriculumVitaeService;
        }

        public EditUserDetailViewModel GetEditUserDetail()
        {
            var editUserDetail = new EditUserDetailViewModel();
            var user = _userService.GetUser();
            var userDetail = _userDetailRepository.GetAll(x => x.UserId == user.UserId).Include("Nationality").Include("DrivingLicense").FirstOrDefault();
            if (userDetail != null)
            {
                editUserDetail.ProfileImage = userDetail.ProfileImage;
                editUserDetail.UserName = user.UserName;
                editUserDetail.NameSurname = userDetail.NameSurname;
                editUserDetail.BirthDate = userDetail.BirthDate;
                editUserDetail.Gender = userDetail.Gender;
                editUserDetail.DrivingLicenseName = userDetail.DrivingLicense.DrivingLicenseType;
                editUserDetail.NationalityName = userDetail.Nationality.NationalityName;
                editUserDetail.NationalityId = userDetail.NationalityId;
                editUserDetail.DrivingLicenseId = userDetail.DrivingLicenseId;
                editUserDetail.numberOfUnreadMessages = _messageService.GetUnreadMessageCount();
                editUserDetail.ProfileImageFileName = Path.GetFileName(userDetail.ProfileImage);
            }
            editUserDetail.DrivingLicenseList = _drivingLicenseService.GetDrivingLicenseList();
            editUserDetail.NationalityList = _nationalityService.GetNationalityList();

            return editUserDetail;
        }

        public void EditUserDetail(EditUserDetailViewModel model)
        {
            var user = _userService.GetUser();
            UserDetail userDetail = _userDetailRepository.Get(x => x.UserId == user.UserId);

            if (userDetail == null)
            {
                userDetail = new UserDetail();
                _userDetailRepository.Add(userDetail);
                userDetail.CreateDate = DateTime.Now;
            }
            else
            {
                userDetail.UpdateDate = DateTime.Now;
            }
            userDetail.UserId = user.UserId;
            if (model.ProfileImage != null)
            {
                userDetail.ProfileImage = model.ProfileImage;
            }
            userDetail.NameSurname = model.NameSurname;
            userDetail.BirthDate = model.BirthDate;
            userDetail.Gender = model.Gender;
            userDetail.DrivingLicenseId = model.DrivingLicenseId;
            userDetail.NationalityId = model.NationalityId;
            try
            {
                _userDetailRepository.SaveChanges();
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                throw;
            }
        }


        public UserDetailViewModel GetUserDetailAndCvByUserId(int userId)
        {
            var userResult = _userDetailRepository.GetAll(x => x.UserId == userId).Include("Nationality").Include("DrivingLicense").FirstOrDefault();
            var userDetail = new UserDetailViewModel();
            if (userResult !=null)
            {
                userDetail.UserId = userResult.UserId;
                userDetail.BirthDate = userResult.BirthDate;
                userDetail.NameSurname = userResult.NameSurname;
                var userCv = _userCurriculumVitaeService.GetPublishedUserCurriculumVitaesByUserId(userId);
                userDetail.CVFileName= Path.GetFileName(userCv.FilePath);
                userDetail.FileName = Path.GetFileName(userResult.ProfileImage);
                userDetail.DrivingLicenseName = userResult.DrivingLicense.DrivingLicenseType;
                userDetail.NationalityName = userResult.Nationality.NationalityName;
                
            }
            return userDetail;
        }
    }
}
