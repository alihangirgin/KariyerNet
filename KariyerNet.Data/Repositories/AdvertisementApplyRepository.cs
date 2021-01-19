using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class AdvertisementApplyRepository: BaseRepository<AdvertisementApply>, IAdvertisementApplyRepository
    {

        private readonly KariyerNetDbContext _context;
        public AdvertisementApplyRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
