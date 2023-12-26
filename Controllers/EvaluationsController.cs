using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagmentSystem.Data;
using StudentManagmentSystem.Models;

namespace StudentManagmentSystem.Controllers
{
    [Authorize]
    public class EvaluationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EvaluationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Evaluations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Evaluation.Include(e => e.Course).Include(e => e.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Evaluations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EvaluationId == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // GET: Evaluations/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId");
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId");

            ViewData["CourseName"] = new SelectList(_context.Course, "CourseName", "CourseName");
            ViewData["StudentFirstName"] = new SelectList(_context.Student, "StudentFirstName", "StudentFirstName");
            ViewData["StudentLastName"] = new SelectList(_context.Student, "StudentLastName", "StudentLastName");
            ViewData["StudentName"] = new SelectList(_context.Student, "StudentFirstName", "StudentLastName");




            return View();
        }

        // POST: Evaluations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EvaluationId,CourseId,StudentId,EvaluationType,Score")] Evaluation evaluation)
        {
            if (ModelState.IsValid)
            {
                var course = await _context.Course
                    .Include(c => c.Module) // Include the Module information
                    .FirstOrDefaultAsync(c => c.CourseId == evaluation.CourseId);

                var student = await _context.Student.FindAsync(evaluation.StudentId);

                if (course != null && student != null && course.Module != null && course.Module.ModuleLevel == student.YearLevel)
                {
                    _context.Add(evaluation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Student level does not match the module level.");
                }
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", evaluation.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", evaluation.StudentId);

            ViewData["CourseName"] = new SelectList(_context.Course, "CourseId", "CourseName");
            ViewData["StudentFirstName"] = new SelectList(_context.Student, "StudentId", "StudentFirstName");
            ViewData["StudentLastName"] = new SelectList(_context.Student, "StudentId", "StudentLastName");
            ViewData["StudentName"] = new SelectList(_context.Student, "StudentId", "StudentFirstName", "StudentLastName");


            return View(evaluation);
        }

        // GET: Evaluations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation.FindAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", evaluation.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", evaluation.StudentId);

            ViewData["CourseName"] = new SelectList(_context.Course, "CourseName", "CourseName");
            ViewData["StudentFirstName"] = new SelectList(_context.Student, "StudentFirstName", "StudentFirstName");
            ViewData["StudentLastName"] = new SelectList(_context.Student, "StudentLastName", "StudentLastName");
            ViewData["StudentName"] = new SelectList(_context.Student, "StudentFirstName", "StudentLastName");


            return View(evaluation);
        }

        // POST: Evaluations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EvaluationId,CourseId,StudentId,EvaluationType,Score")] Evaluation evaluation)
        {
            if (id != evaluation.EvaluationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var course = await _context.Course
                    .Include(c => c.Module) // Include the Module information
                    .FirstOrDefaultAsync(c => c.CourseId == evaluation.CourseId);

                var student = await _context.Student.FindAsync(evaluation.StudentId);

                if (course != null && student != null && course.Module != null && course.Module.ModuleLevel == student.YearLevel)
                {
                    try
                    {
                        _context.Update(evaluation);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!EvaluationExists(evaluation.EvaluationId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Student level does not match the module level.");
                }
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "CourseId", "CourseId", evaluation.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "StudentId", "StudentId", evaluation.StudentId);

            ViewData["CourseName"] = new SelectList(_context.Course, "CourseId", "CourseName");
            ViewData["StudentFirstName"] = new SelectList(_context.Student, "StudentId", "StudentFirstName");
            ViewData["StudentLastName"] = new SelectList(_context.Student, "StudentId", "StudentLastName");
            ViewData["StudentName"] = new SelectList(_context.Student, "StudentId", "StudentFirstName", "StudentLastName");


            return View(evaluation);
        }

        // GET: Evaluations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evaluation = await _context.Evaluation
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.EvaluationId == id);
            if (evaluation == null)
            {
                return NotFound();
            }

            return View(evaluation);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var evaluation = await _context.Evaluation.FindAsync(id);
            if (evaluation != null)
            {
                _context.Evaluation.Remove(evaluation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EvaluationExists(int id)
        {
            return _context.Evaluation.Any(e => e.EvaluationId == id);
        }
    }
}
