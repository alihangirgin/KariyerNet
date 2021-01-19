using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {

        private readonly KariyerNetDbContext _context;
        public CityRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
