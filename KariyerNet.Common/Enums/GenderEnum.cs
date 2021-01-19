using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KariyerNet.Common.Enums
{
    public enum GenderEnum
    {
        [Display(Name = "Kadın")]
        Female,
        [Display(Name = "Erkek")]
        Male,
        [Display(Name = "Kararsız")]
        Other
    }
}
