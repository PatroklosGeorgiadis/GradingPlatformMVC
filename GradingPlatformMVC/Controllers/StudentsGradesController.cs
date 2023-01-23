﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradingPlatformMVC.Models;

namespace GradingPlatformMVC.Controllers
{
    public class StudentsGradesController : Controller
    {
        private readonly GradeDBContext _context;

        public StudentsGradesController(GradeDBContext context)
        {
            _context = context;
        }

        // GET: StudentsGrades
        public async Task<IActionResult> Index()
        {
            var gradeDBContext = _context.CourseHasStudents.Include(c => c.IdCourseNavigation).Include(c => c.RegistrationNumNavigation);
            return View(await gradeDBContext.ToListAsync());
        }

        // GET: StudentsGrades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CourseHasStudents == null)
            {
                return NotFound();
            }

            var courseHasStudent = await _context.CourseHasStudents
                .Include(c => c.IdCourseNavigation)
                .Include(c => c.RegistrationNumNavigation)
                .FirstOrDefaultAsync(m => m.IdCourse == id);
            if (courseHasStudent == null)
            {
                return NotFound();
            }

            return View(courseHasStudent);
        }

        // GET: StudentsGrades/Create
        public IActionResult Create()
        {
            ViewData["IdCourse"] = new SelectList(_context.Courses, "IdCourse", "IdCourse");
            ViewData["RegistrationNum"] = new SelectList(_context.Students, "RegistrationNum", "Username");
            return View();
        }

        // POST: StudentsGrades/Create
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

        // GET: StudentsGrades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CourseHasStudents == null)
            {
                return NotFound();
            }

            var courseHasStudent = await _context.CourseHasStudents.FindAsync(id);
            if (courseHasStudent == null)
            {
                return NotFound();
            }
            ViewData["IdCourse"] = new SelectList(_context.Courses, "IdCourse", "IdCourse", courseHasStudent.IdCourse);
            ViewData["RegistrationNum"] = new SelectList(_context.Students, "RegistrationNum", "Username", courseHasStudent.RegistrationNum);
            return View(courseHasStudent);
        }

        // POST: StudentsGrades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCourse,RegistrationNum,Grade")] CourseHasStudent courseHasStudent)
        {
            if (id != courseHasStudent.IdCourse)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseHasStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseHasStudentExists(courseHasStudent.IdCourse))
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
            ViewData["IdCourse"] = new SelectList(_context.Courses, "IdCourse", "IdCourse", courseHasStudent.IdCourse);
            ViewData["RegistrationNum"] = new SelectList(_context.Students, "RegistrationNum", "Username", courseHasStudent.RegistrationNum);
            return View(courseHasStudent);
        }

        // GET: StudentsGrades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CourseHasStudents == null)
            {
                return NotFound();
            }

            var courseHasStudent = await _context.CourseHasStudents
                .Include(c => c.IdCourseNavigation)
                .Include(c => c.RegistrationNumNavigation)
                .FirstOrDefaultAsync(m => m.IdCourse == id);
            if (courseHasStudent == null)
            {
                return NotFound();
            }

            return View(courseHasStudent);
        }

        // POST: StudentsGrades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CourseHasStudents == null)
            {
                return Problem("Entity set 'GradeDBContext.CourseHasStudents'  is null.");
            }
            var courseHasStudent = await _context.CourseHasStudents.FindAsync(id);
            if (courseHasStudent != null)
            {
                _context.CourseHasStudents.Remove(courseHasStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseHasStudentExists(int id)
        {
          return _context.CourseHasStudents.Any(e => e.IdCourse == id);
        }
    }
}