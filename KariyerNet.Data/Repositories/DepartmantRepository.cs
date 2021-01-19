using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class DepartmantRepository : BaseRepository<Departmant>, IDepartmantRepository
    {

        private readonly KariyerNetDbContext _context;
        public DepartmantRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
