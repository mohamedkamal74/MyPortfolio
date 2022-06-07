using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace web.Controllers
{
    public class PrtoflioItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrtoflioItemsController(ApplicationDbContext context)
        {
         _context = context;
        }
        // GET: PrtoflioItemsController
        public ActionResult Index()
        {
            return View(_context.PrtofolioItems.ToList());
        }

        // GET: PrtoflioItemsController/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var prttoflio=_context.PrtofolioItems.Find(id);
            if (prttoflio == null)
            {
                return NotFound();
            }
            return View(prttoflio);
        }

        // GET: PrtoflioItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrtoflioItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrtofolioItem model)
        {
            if (ModelState.IsValid)
            {
                _context.PrtofolioItems.Add(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PrtoflioItemsController/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var prttoflio = _context.PrtofolioItems.Find(id);
            if (prttoflio == null)
            {
                return NotFound();
            }
            return View(prttoflio);
        }

        // POST: PrtoflioItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PrtoflioItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PrtoflioItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
