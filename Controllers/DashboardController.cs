using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagmentSystem.Data;
using System.Security.Claims;

namespace StudentManagmentSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context; // Example: DbContext for database operations

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action to display the user dashboard
        [Authorize]
        public IActionResult Index()
        {
            var students = _context.Student.ToList();
            var modules = _context.Module.ToList();
            var courses = _context.Course.ToList();
            var evaluations = _context.Evaluation.ToList();

            ViewBag.students = students;
            ViewBag.modules = modules;
            ViewBag.cours = courses;
            ViewBag.evaluations = evaluations;

            return View();

        }

        // Other actions related to the dashboard can be added here
    }

}
