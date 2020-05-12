using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReportFeedBack.Controllers
{
    public class FeedBackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}