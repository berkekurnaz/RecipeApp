﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Recipe.MvcWebUI.Controllers
{
    public class AnasayfaController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}