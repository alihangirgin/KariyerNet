using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{

    public class JobAdvertisementRepository : BaseRepository<JobAdvertisement>, IJobAdvertisementRepository
    {

        private readonly KariyerNetDbContext _context;
        public JobAdvertisementRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }



    }

}
