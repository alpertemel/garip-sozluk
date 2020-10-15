using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GaripSozluk.WebApp.Models;
using GaripSozluk.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace GaripSozluk.WebApp.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHeaderCategoryService _headerCategoryService;
        private readonly IHeaderService _headerService;

        public HomeController(ILogger<HomeController> logger, IHeaderService headerService,IHeaderCategoryService headerCategoryService)
        {
            _headerCategoryService = headerCategoryService;
            _logger = logger;
            _headerService = headerService;
        }

        public IActionResult Index(int id)
        {
            _logger.LogDebug("Home>Index");

            ViewBag.HeaderByCategory = _headerService.GetAllHeaderByCategoryId(id);
            ViewBag.HeaderCategoryList = _headerCategoryService.GetHeadersSelect(id);
            return View();

            //var resultCount = _postService.GetAll().Count();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
