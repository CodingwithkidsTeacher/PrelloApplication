using Microsoft.AspNetCore.Mvc;
using Prello.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prello.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClientsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Clients
        public IActionResult Index()
        {
            return View(_db.Clients.ToList());
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                _db.Add(client);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Client/Edit/id
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _db.Clients.FirstOrDefault(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Client/Edit/id
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,Email")] Client client)
        {
            if (ModelState.IsValid)
            {
                if (id != client.Id)
                {
                    return NotFound();
                }
                else
                {
                    _db.Update(client);
                    _db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/id
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _db.Clients.FirstOrDefault(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/id
        [HttpPost]
        public IActionResult Delete(int id, bool notUsed)
        {
            var client = _db.Clients.FirstOrDefault(m => m.Id == id);
            _db.Clients.Remove(client);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // Get: Search Client
        public IActionResult Search(string searchString)
        {
            if (searchString == null)
            {
                return View("NotFoundData");
            }

            var client = _db.Clients.Where(m => m.Name == searchString).ToList();

            if (client == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }
    }
}
