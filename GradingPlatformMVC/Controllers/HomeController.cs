﻿using GradingPlatformMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using GradingPlatformMVC.Models;

namespace GradingPlatformMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GradeDBContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Student model)
        {
            var student = from m in _context.Students select m;
            student = student.Where(s => s.Username == model.Username);
            var professor = from m in _context.Professors select m;
            professor = professor.Where(s => s.Username == model.Username);
            var secretary = from m in _context.Secretaries select m;
            secretary = secretary.Where(s => s.Username == model.Username);
            if (student.Count() != 0 || professor.Count() != 0 || secretary.Count() != 0)
            {
                if (student.First().Password == model.Password || professor.First().Password == model.Password || secretary.First().Password == model.Password)
                {

                    return View();
                }
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}