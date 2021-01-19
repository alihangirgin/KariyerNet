using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class EducationLevelRepository : BaseRepository<EducationLevel>, IEducationLevelRepository
    {

        private readonly KariyerNetDbContext _context;
        public EducationLevelRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
