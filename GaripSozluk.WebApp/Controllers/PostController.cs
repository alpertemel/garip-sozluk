using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GaripSozluk.WebApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IHeaderCategoryService _headerCategoryService;
        private readonly IHeaderService _headerService;
        private readonly IPostService _postService;

        public PostController(ILogger<PostController> logger, IHeaderService headerService, IHeaderCategoryService headerCategoryService, IPostService postService)
        {
            _headerCategoryService = headerCategoryService;
            _logger = logger;
            _headerService = headerService;
            _postService = postService;
        }

        [Authorize]
        public IActionResult AddPost(int CategoryID,int id)
        {
            ViewBag.HeaderByCategory = _headerService.GetAllHeaderByCategoryId(CategoryID);
            ViewBag.HeaderCategoryList = _headerCategoryService.GetHeadersSelect(id); //Kategorileri Çekiyor
            return View();
        }





    }
}
