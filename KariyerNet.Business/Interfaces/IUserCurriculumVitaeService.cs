using KariyerNet.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface IUserCurriculumVitaeService
    {
        List<UserCurriculumVitaeViewModel> GetUserCurriculumVitaesByUserId(int userId);
        UserCurriculumVitaeViewModel GetPublishedUserCurriculumVitaesByUserId(int userId);
        void PublishCurriculumVitae(int userId, int curriculumVitaeId);
        void RemovePublishCurriculumVitae(int userId, int curriculumVitaeId);
        List<KeyValuePair<string, string>> AddCurriculumVitae(AddUserCurriculumVitaeViewModel model);
        void DeleteCurriculumVitae(int curriculumVitaeId);
        List<UserProfileViewModel> SearchUserCurriculumVitae(SearchUserCurriculumVitaeToCompanyViewModel model);
        SearchUserCurriculumVitaeToCompanyViewModel GetSearchAppliesFormData();
    }
}
