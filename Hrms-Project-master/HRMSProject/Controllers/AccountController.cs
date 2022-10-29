using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult login()
        {
            return View();
        }

        public IActionResult signup()
        {
            return View();
        }
    }
}
