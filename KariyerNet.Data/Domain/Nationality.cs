using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class Nationality:BaseEntity
    {
        public string NationalityName { get; set; }
        public int UserId { get; set; }
        public DateTime? DeleteDate { get; set; }
        public User User { get; set; }
        public ICollection<UserDetail> UserDetails { get; set; }
    }
}
