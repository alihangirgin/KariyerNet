using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class WorkTypeRepository : BaseRepository<WorkType>, IWorkTypeRepository
    {

        private readonly KariyerNetDbContext _context;
        public WorkTypeRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
