using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class UserCurriculumVitaeViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CVName { get; set; }
        public string FilePath { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? PublishDeleteDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
