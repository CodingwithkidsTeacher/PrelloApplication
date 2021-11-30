using Microsoft.AspNetCore.Mvc;
using Prello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prello.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Projects
        public IActionResult Index()
        {

            return View(_db.Projects.ToList());
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,Status,DueDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                _db.Add(project);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Project/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _db.Projects.FirstOrDefault(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/id
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,Status, DueDate")] Project project)
        {
            if (ModelState.IsValid)
            {
                if (id != project.Id)
                {
                    return NotFound();
                }
                else
                {
                    _db.Update(project);
                    _db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/id
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = _db.Projects.FirstOrDefault(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/id
        [HttpPost]
        public IActionResult Delete(int id, bool notUsed)
        {
            var project = _db.Projects.FirstOrDefault(m => m.Id == id);
            _db.Projects.Remove(project);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Get: Search Project
        public IActionResult Search(string searchString)
        {
            if (searchString == null)
            {
                return View("NotFoundData");
            }

            var project = _db.Projects.Where(m => m.Name == searchString).ToList();

            if (project == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(project);
        }
    }
}
