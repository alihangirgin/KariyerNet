using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{

    public class AdvertisementViewCountRepository : BaseRepository<AdvertisementViewCount>, IAdvertisementViewCountRepository
    {

        private readonly KariyerNetDbContext _context;
        public AdvertisementViewCountRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
