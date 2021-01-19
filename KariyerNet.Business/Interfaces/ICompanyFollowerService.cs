using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface ICompanyFollowerService
    {
        void CreateCompanyFollower(int companyId, int UserId);
        void RemoveCompanyFollower(int companyId, int userId);
    }
}
