using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KariyerNet.WebApp.Controllers
{
    public class WorkTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
