using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradingPlatformMVC.Models;

namespace GradingPlatformMVC.Controllers
{
    public class ProfessorsCoursesController : Controller
    {
        private readonly GradeDBContext _context;

        public ProfessorsCoursesController(GradeDBContext context)
        {
            _context = context;
        }

        // GET: ProfessorsCourses
        public async Task<IActionResult> Index()
        {
            /*var course_info = from course in _context.Courses
                       join prof in _context.Professors
                       on course.ProfessorsAfm equals prof.Afm
                       select new Course {CourseTitle = course.CourseTitle,
                           CourseSemester = course.CourseSemester,
                           professor = prof.Surname };*/
            var gradeDBContext = _context.Courses.OrderBy(c => c.CourseSemester)
                .Include(c => c.ProfessorsAfmNavigation);
            return View(await gradeDBContext.ToListAsync());
        }

        // GET: ProfessorsCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.CourseHasStudents)
                .FirstOrDefaultAsync(m => m.IdCourse == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: ProfessorsCourses/Create
        public IActionResult Create(int id)
        {
            //ViewData["RegistrationNum"] = new SelectList(_context.Students, "RegistrationNum", "RegistrationNum");
            return RedirectToAction("Create", "ProfessorsGrades", new { id = id});
        }

        // POST: ProfessorsCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCourse,RegistrationNum,Grade")] CourseHasStudent courseHasStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseHasStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCourse"] = new SelectList(_context.Courses, "IdCourse", "IdCourse", courseHasStudent.IdCourse);
            ViewData["RegistrationNum"] = new SelectList(_context.Students, "RegistrationNum", "Username", courseHasStudent.RegistrationNum);
            return View(courseHasStudent);
        }

        // GET: ProfessorsCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["ProfessorsAfm"] = new SelectList(_context.Professors, "Username", "Username", course.ProfessorsAfm);
            return View(course);
        }

        // POST: ProfessorsCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCourse,CourseTitle,CourseSemester,ProfessorsAfm")] Course course)
        {
            if (id != course.IdCourse)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.IdCourse))
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
            ViewData["ProfessorsAfm"] = new SelectList(_context.Professors, "Username", "Username", course.ProfessorsAfm);
            return View(course);
        }

        // GET: ProfessorsCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.ProfessorsAfmNavigation)
                .FirstOrDefaultAsync(m => m.IdCourse == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: ProfessorsCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'GradeDBContext.Courses'  is null.");
            }
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
          return _context.Courses.Any(e => e.IdCourse == id);
        }
    }
}
