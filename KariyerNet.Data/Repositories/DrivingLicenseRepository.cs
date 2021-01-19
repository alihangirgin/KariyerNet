using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
   public class DrivingLicenseRepository : BaseRepository<DrivingLicense>, IDrivingLicenseRepository
    {
        private readonly KariyerNetDbContext _context;
        public DrivingLicenseRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
