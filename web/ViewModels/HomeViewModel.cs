using Core.Entities;
using System.Collections.Generic;

namespace web.ViewModels
{
    public class HomeViewModel
    {
        public Owner Owner { get; set; }
        public List<PrtofolioItem> PrtofolioItems { get; set; }
    }
}
