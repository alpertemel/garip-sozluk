using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GaripSozluk.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public IActionResult SearchHeader(SearchVM model,string text)
        {
            model.SearchText = text;
            ViewBag.SearchResult = _searchService.SearchHeader(model.SearchText);
            return View();
        }

    }
}
