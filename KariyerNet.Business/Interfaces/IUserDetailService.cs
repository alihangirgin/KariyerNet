using KariyerNet.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface IUserDetailService
    {
        EditUserDetailViewModel GetEditUserDetail();
        void EditUserDetail(EditUserDetailViewModel model);
        UserDetailViewModel GetUserDetailAndCvByUserId(int userId);
    }
}
