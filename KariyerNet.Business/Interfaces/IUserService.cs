using KariyerNet.Common.Enums;
using KariyerNet.Common.ViewModels;
using KariyerNet.Data.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KariyerNet.Business.Interfaces
{
   public interface IUserService
    {
        //User GetUserByUserId();
        UserClaimViewModel GetUser();
        List<int> GetUserIdListByGender(GenderEnum gender);
        List<int> GetUserIdByDrivingLicenseId(int drivingLicenseId);
        List<int> GetUserIdByNationalityId(int nationalityId);
        List<UserViewModel> getAllEmployeeUsers();
        List<SelectListItem> getAllEmployeeUsersToForm();
    }
}
