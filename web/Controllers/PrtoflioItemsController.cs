using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using web.ViewModels;

namespace web.Controllers
{
    public class PrtoflioItemsController : Controller
    {
        private readonly IUnitOfWork<PrtofolioItem> _prtoflio;
        private readonly IHostingEnvironment _hosting;

        public PrtoflioItemsController(IUnitOfWork<PrtofolioItem> prtoflio
            ,IHostingEnvironment hosting)
        {
           _prtoflio = prtoflio;
            _hosting = hosting;
        }
        // GET: PrtoflioItemsController
        public ActionResult Index()
        {
            return View(_prtoflio.Entity.GetAll());
        }

        // GET: PrtoflioItemsController/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var prttoflio=_prtoflio.Entity.GetTById(id);
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
        public ActionResult Create(PrtoflioViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.File!= null)
                {
                    string Uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string FullPath = Path.Combine(Uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                PrtofolioItem prtofolioItem = new PrtofolioItem
                {
                        Description = model.Description,    
                        ProjectName=model.ProjectName,
                        ImageUrl=model.ImageUrl
                };
                _prtoflio.Entity.Add(prtofolioItem);
                _prtoflio.Save();
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
            var prttoflio =_prtoflio.Entity.GetTById(id);
            if (prttoflio == null)
            {
                return NotFound();
            }
            PrtoflioViewModel prtoflioViewModel = new PrtoflioViewModel
            {
                Id= prttoflio.Id,
                Description=prttoflio.Description,
                ProjectName= prttoflio.ProjectName,
                ImageUrl=prttoflio.ImageUrl
            };
            return View(prtoflioViewModel);
        }

        // POST: PrtoflioItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, PrtoflioViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string Uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                    string FullPath = Path.Combine(Uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                PrtofolioItem prtofolioItem = new PrtofolioItem
                {
                    Description = model.Description,
                    ProjectName = model.ProjectName,
                    ImageUrl = model.ImageUrl
                };
                _prtoflio.Entity.Update(prtofolioItem);
                _prtoflio.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model); 

        }

        // GET: PrtoflioItemsController/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var prttoflio = _prtoflio.Entity.GetTById(id);
            if (prttoflio == null)
            {
                return NotFound();
            }
            return View(prttoflio);
        }

        // POST: PrtoflioItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            _prtoflio.Entity.Delete(id);
            _prtoflio.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
