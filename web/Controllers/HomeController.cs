using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web.ViewModels;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PrtofolioItem> _prtoflio;

        public HomeController(IUnitOfWork<Owner>Owner,IUnitOfWork<PrtofolioItem>prtoflio)
        {
            _owner = Owner;
          _prtoflio = prtoflio;
        }
        public IActionResult Index()
        {
            var homeviewmodel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                PrtofolioItems=_prtoflio.Entity.GetAll().ToList()
            };
            return View(homeviewmodel);
        }
    }
}
