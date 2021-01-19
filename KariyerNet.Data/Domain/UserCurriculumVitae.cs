using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Data.Domain
{
    public class UserCurriculumVitae:BaseEntity
	{
        public int UserId { get; set; }
        public string CVName { get; set; }
		public string FilePath { get; set; }
		public DateTime? PublishDate { get; set; }
        public DateTime? PublishDeleteDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public User User { get; set; }
	}
}
