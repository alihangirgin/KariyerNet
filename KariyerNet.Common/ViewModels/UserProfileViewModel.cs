using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class UserProfileViewModel
    {
        //public UserDetailViewModel userDetailViewModel { get; set; }

        public EditUserDetailViewModel userDetail { get; set; }

        public UserClaimViewModel UserClaimViewModel { get; set; }
        public List<UserCurriculumVitaeViewModel> UserCurriculumVitaeViewModels { get; set; }
        public UserCurriculumVitaeViewModel UserPublishedCurriculumVitaeViewModel { get; set; }

        public string JobTitle { get; set; }

    }
}
