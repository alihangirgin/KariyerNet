using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface IPositionService
    {
        List<SelectListItem> GetPositionList();
        string GetPositionNameByPositionId(int positionId);
    }
}
