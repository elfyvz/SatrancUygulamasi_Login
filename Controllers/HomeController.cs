using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatrancUygulamasi.Data;
using SatrancUygulamasi.Data.Entities;
using SatrancUygulamasi.Models;
using System.Diagnostics;

namespace SatrancUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Main()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var parents = await _context.Parents.Include(p => p.Students).ToListAsync();
            if (parents == null || !parents.Any())
            {
                Console.WriteLine("No parents found.");
            }
            else
            {
                Console.WriteLine($"Found {parents.Count} parents.");
                foreach (var parent in parents)
                {
                    Console.WriteLine($"Parent: {parent.Name}, Email: {parent.Email}, Students: {parent.Students.Count}");
                }
            }
            return View(parents);
        }

        public IActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentLogin(string email, string password)
        {
            var student = _context.Students.FirstOrDefault(s => s.Email == email && s.Password == password);
            if (student != null)
            {
                // Login successful
                return RedirectToAction("Index"); // Or wherever you want to redirect
            }
            else
            {
                // Login failed
                ViewBag.ErrorMessage = "Invalid login attempt";
                return View();
            }
        }

        public IActionResult ParentLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ParentLogin(string email, string password)
        {
            var parent = _context.Parents.FirstOrDefault(p => p.Email == email && p.Password == password);
            if (parent != null)
            {
                // Login successful
                return RedirectToAction("Index"); // Or wherever you want to redirect
            }
            else
            {
                // Login failed
                ViewBag.ErrorMessage = "Invalid login attempt";
                return View();
            }
        }

        public IActionResult StudentRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentRegister(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("StudentLogin"); // Or to a login page
            }
            return View(student);
        }

        public IActionResult ParentRegister()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ParentRegister(Parent parent)
        {
            if (ModelState.IsValid)
            {
                _context.Parents.Add(parent);
                _context.SaveChanges();
                return RedirectToAction("ParentLogin"); // Or to a login page
            }
            return View(parent);
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