using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface IDepartmantService
    {
        List<SelectListItem> GetDepartmantList();
        string GetDepartmantNameByDepartmantId(int departmantId);
    }
}
