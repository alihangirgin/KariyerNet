using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
   public class UserCurriculumVitaeRepository:BaseRepository<UserCurriculumVitae>,IUserCurriculumVitaeRepository
    {
        private readonly KariyerNetDbContext _context;
        public UserCurriculumVitaeRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
