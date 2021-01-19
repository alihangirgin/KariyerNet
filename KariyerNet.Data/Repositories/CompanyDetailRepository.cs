using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{

    public class CompanyDetailRepository : BaseRepository<CompanyDetail>, ICompanyDetailRepository
    {
        private readonly KariyerNetDbContext _context;
        public CompanyDetailRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
