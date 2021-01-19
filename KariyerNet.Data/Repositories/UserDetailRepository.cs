using KariyerNet.Data.Domain;
using KariyerNet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Repositories
{
    public class UserDetailRepository : BaseRepository<UserDetail>, IUserDetailRepository
    {
        private readonly KariyerNetDbContext _context;
        public UserDetailRepository(KariyerNetDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
