using KariyerNet.Business.Interfaces;
using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Services
{
    public class CompanyFollowerService:ICompanyFollowerService
    {

        private readonly ICompanyFollowerRepository _companyFollowerRepository;
        public CompanyFollowerService(ICompanyFollowerRepository companyFollowerRepository)
        {
            _companyFollowerRepository = companyFollowerRepository;
        }


        public void CreateCompanyFollower(int companyId, int userId)
        {
            if (companyId != userId)
            {

                var isFollowed = _companyFollowerRepository.Get(x => x.UserId == userId && x.CompanyUserId == companyId);
                if (isFollowed != null)
                {
                    return;
                }
                var companyFollower = new CompanyFollower();
                companyFollower.UserId = userId;
                companyFollower.CompanyUserId = companyId;
                companyFollower.CreateDate = DateTime.Now;

                _companyFollowerRepository.Add(companyFollower);

                try
                {
                    _companyFollowerRepository.SaveChanges();

                }
                catch (Exception ex)
                {
                    var errorMessage = ex.Message;
                    throw;
                }
            }

        }


        public void RemoveCompanyFollower(int companyId, int userId)
        {
            var companyFollower = _companyFollowerRepository.Get(x => x.CompanyUserId == companyId && x.UserId == userId);
            if(companyFollower!=null)
            {
                _companyFollowerRepository.Remove(companyFollower);
            }

        }



        //var blockedUser = _blockedUserRepository.Get(x => x.BannedUserId == bannedId && x.UserId == userId);
        //    if (blockedUser != null)
        //    {
        //        _blockedUserRepository.Remove(blockedUser);
        //    }
}
}
