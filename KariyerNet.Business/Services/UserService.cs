using KariyerNet.Business.Interfaces;
using KariyerNet.Common.Enums;
using KariyerNet.Common.ViewModels;
using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Business.Services
{
    public class UserService : IUserService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly IUserDetailRepository _userDetailRepository;
        public UserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, IUserDetailRepository userDetailRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _userDetailRepository = userDetailRepository;
        }

        public UserClaimViewModel GetUser()
        {
            var user = _httpContextAccessor.HttpContext.User;
            var dbUser = _userManager.GetUserAsync(user).Result;
            if (dbUser != null)
            {
                UserClaimViewModel userClaimViewModel = new UserClaimViewModel()
                {
                    Email = dbUser.Email,
                    UserName = dbUser.UserName,
                    UserId = dbUser.Id

                };
                return userClaimViewModel;
            }
            return null;

        }

        public List<int> GetUserIdListByGender(GenderEnum gender)
        {
            var foundedUsers= _userDetailRepository.GetAll(x => x.Gender == gender).ToList();
            var userIdList = new List<int>();
            if(foundedUsers!=null)
            {
                foreach (var item in foundedUsers)
                {
                    userIdList.Add(item.UserId);
                }
            }

            return userIdList;
        }
        public List<int> GetUserIdByDrivingLicenseId(int drivingLicenseId)
        {
            var userIdList = new List<int>();
            var foundedUsers = _userDetailRepository.GetAll(x => x.DrivingLicenseId == drivingLicenseId).ToList();
            if(foundedUsers!=null)
            {
                foreach (var item in foundedUsers)
                {
                    userIdList.Add(item.UserId);
                }
            }

            return userIdList;
        }

        public List<int> GetUserIdByNationalityId(int nationalityId)
        {
            var userIdList = new List<int>();
            var foundedUsers = _userDetailRepository.GetAll(x => x.NationalityId == nationalityId).ToList();
            if (foundedUsers != null)
            {
                foreach (var item in foundedUsers)
                {
                    userIdList.Add(item.UserId);
                }
            }

            return userIdList;
        }



        public List<UserViewModel> getAllEmployeeUsers()
        {
            var checkUsers = _userManager.GetUsersInRoleAsync("Employee").Result;
            var userList = new List<UserViewModel>();
            if(checkUsers != null)
            {
                foreach (var item in checkUsers)
                {
                    var user = new UserViewModel();
                    user.UserId = item.Id;
                    user.NameSurname = item.NameSurname;
                    userList.Add(user);
                }
            }
            return userList;
        }



        public List<SelectListItem> getAllEmployeeUsersToForm()
        {

            var model = new List<SelectListItem>();
            getAllEmployeeUsers().ForEach(x =>
            {
                model.Add(new SelectListItem()
                {
                    Text = x.NameSurname,
                    Value = x.UserId.ToString()
                });

            });

            return model;
        }


    }
}

