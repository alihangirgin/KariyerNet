using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KariyerNet.Common.Enums
{
    public enum NumberEmployeeEnum
    {
        [Display(Name = "1-50")]
        OneToFifty,
        [Display(Name = "51-100")]
        FiftyToOneHundred,
        [Display(Name = "101-150")]
        OneHundredOneToOneHundredFiftyOne,
        [Display(Name = "151-200")]
        OneHundredFiftyOneToTwoHundred,
        [Display(Name = ">201")]
        GreaterThanTwoHundredOne

    }
}
