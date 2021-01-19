using KariyerNet.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface IJobAdvertisementService
    {
        int CreateJobAdvertisement(CreateJobAdvertisementViewModel model, int userId);
        CreateJobAdvertisementViewModel GetCreateJobAdvertisementFormData();
        GetJobAdvertisementViewModel GetJobAdvertisementDetailByJobAdvertisementId(int Id);
        int GetJobAdvertisementIdByCompanyUserIdAndCreateDate(int companyUserId, DateTime createDate);
        List<SearchResultJobAdvertisementViewModel> SearchJobAdvertisement(SearchJobAdvertisementViewModel model);
        SearchJobAdvertisementViewModel GetSearchJobAdvertisementFormData();
        string GetJobAdvertisementTittleByJobAdvertisementId(int jobAdvertisementId);
        void CreateAdvertisementApply(int jobAdvertisementId, int userId);
        void DeleteAdvirtisementApply(int jobAdvertisementId, int userId);
        List<GetAdvertisementApplyViewModel> GetAdvertisementApplies();
        bool checkIsUserAppliedByUserId(int jobAdvertisementId);
        int JobAdvertisementCount();
        GetJobAdvertisementViewModel GetJobAdvertisementDetailByJobAdvertisementIdWithoutUserLogin(int Id);
        List<GetAdvertisementApplyToCompanyViewModel> GetAdvertisementAppliesToCompany(int JobAdvertisementId);
        List<GetJobAdvertisementsToCompanyViewModel> GetJobAdvertisementToCompanies();
        //view count
        void CreateAdvertisementViewCount(int jobAdvertisementId, int userId);
        int GetAdvertisementViewCountByJobAdvertisementId(int jobAdvertisementId);
        List<GetHomeSliderViewModel> GetMostViewedJobAdvertisement();
        void EditJobAdvertisement(EditJobAdvertisementViewModel model);
        GetJobAdvertisementToCompanyViewModel GetJobAdvertisementDetailToCompanyByJobAdvertisementId(int Id);
        SearchJobAppliesToCompanyViewModel GetSearchAppliesFormData();
        List<GetJobAdvertisementsToCompanyViewModel> GetJobAdvertisementToCompaniesPassive();
        int GetJobApplyCount(int JobAdvertisementId);
        void PublishJobAdvertisement(int jobAdvertisementId);
        List<GetJobAdvertisementsToCompanyViewModel> GetJobAdvertisementToCompaniesDraft();
        List<UserProfileViewModel> SearchJobApplies(SearchJobAppliesToCompanyViewModel model);
        int GetCompanyUserIdByJobAdvertisementId(int jobAdvertisementId);
    }
}
