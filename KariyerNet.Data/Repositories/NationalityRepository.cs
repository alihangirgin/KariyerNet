using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
   public class NationalityRepository:BaseRepository<Nationality>,INationalityRepository
    {
        private readonly KariyerNetDbContext _context;
        public NationalityRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
