using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost]
        public IActionResult AddPost(int CategoryID, int id, int HeaderId, PostVM model)
        {
            var headerId = HttpContext.Request.Query["HeaderId"].Count  > 0 ? int.Parse(HttpContext.Request.Query["HeaderId"]) : 0;
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                var userId = int.Parse(user.Claims.ToList().Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
                model.UserId = userId;
                model.HeaderId = headerId;
                _postService.AddPost(model);
            }

            return View();
        }

        [Authorize]
        public IActionResult AddPost(int CategoryID, int id, int headerId)
        {
            //ViewBag.HeaderByCategory = _headerService.GetAllHeaderByCategoryId(CategoryID);
            //ViewBag.HeaderCategoryList = _headerCategoryService.GetHeadersSelect(id); //Kategorileri Çekiyor
            //ViewBag.HeaderId = headerId;

            return View(new PostVM() { HeaderId = headerId });
        }

        public IActionResult GetPost(int CategoryId, int id, int HeaderId)
        {
            var query = _postService.GetAllPostByHeaderId(HeaderId);
            ViewBag.GetPostsByHeaderId = query;
            ViewBag.HeaderByCategory = _headerService.GetAllHeaderByCategoryId(CategoryId);
            ViewBag.HeaderCategoryList = _headerCategoryService.GetHeadersSelect(id); //Kategorileri Çekiyor
            return View();
        }




    }
}
