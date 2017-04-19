﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelBlog.Models;


namespace TravelBlog.Controllers
{
    public class Experiences : Controller
    {
        private TravelDbContext db = new TravelDbContext();
        public IActionResult Index()
        {
            return View(db.Experiences.ToList());
        }
    }
}