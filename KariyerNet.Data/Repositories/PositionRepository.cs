using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class PositionRepository : BaseRepository<Position>, IPositionRepository
    {

        private readonly KariyerNetDbContext _context;
        public PositionRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
