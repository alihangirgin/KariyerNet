using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class CompanyFollowerRepository : BaseRepository<CompanyFollower>, ICompanyFollowerRepository
    {

        private readonly KariyerNetDbContext _context;
        public CompanyFollowerRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
