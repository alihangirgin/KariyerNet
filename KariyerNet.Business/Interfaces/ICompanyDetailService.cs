using KariyerNet.Common.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface ICompanyDetailService
    {

        int EditCompanyDetail(EditCompanyDetailViewModel model);
        EditCompanyDetailViewModel GetCompanyDetail();
        GetCompanyDetailViewModel GetCompanyDetailByCompanyId(int Id);
        string GetCompanyDetailNameByCompanyUserId(int companyUserId);
        int GetCompanyIdByCompanyUserId(int companyUserId);
        GetCompanyDetailViewModel GetCompanyDetailByCompanyUserId(int companyUserId);
        List<int> GetCompanyUserIdsBySectorId(List<int?> sectorId);
        List<int> GetCompanyUserIdsByCompanyName(string companyName);

    }
}
