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
        private readonly IHeaderCategoryService _headerCategoryService;
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService, IHeaderCategoryService headerCategoryService)
        {
            _headerCategoryService = headerCategoryService;
            _searchService = searchService;
        }

        public IActionResult SearchHeader(SearchVM model,string text)
        {
            model.SearchText = text;
            ViewBag.SearchResult = _searchService.SearchHeader(model.SearchText);
            return View();
        }

        public IActionResult DetailSearchHeader(int id)
        {
            ViewBag.HeaderCategoryList = _headerCategoryService.GetHeadersSelect(id);
            return View();
        }

        [HttpPost]
        public IActionResult DetailSearchHeader(string text,DateTime create, int categoryid)
        {
            ViewBag.DetailSearchResult = _searchService.DetailSearchHeader(text, create,categoryid);
            return View();
        }

    }
}
