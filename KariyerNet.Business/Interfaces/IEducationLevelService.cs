using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface IEducationLevelService
    {
        List<SelectListItem> GetEducationLevelList();
        string GetEdcuationLevelNameByEducationLevelId(int educationLevelId);
    }
}
