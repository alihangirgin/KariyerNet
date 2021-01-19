using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Common.ViewModels
{
    public class GetWorkTypeViewModel
    {
        public string WorkTypeName { get; set; }
        public int UserId { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
