﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace KariyerNet.Business.Interfaces
{
    public interface ISectorService
    {
        List<SelectListItem> GetSectorList();
        bool isSectorValid(int sectorId);
        string GetSectorNameBySectorId(int sectorId);
    }
}
