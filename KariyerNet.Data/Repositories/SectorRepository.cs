using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class SectorRepository : BaseRepository<Sector>, ISectorRepository
    {
        private readonly KariyerNetDbContext _context;
        public SectorRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
