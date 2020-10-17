using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GaripSozluk.WebApp.Controllers
{
    public class RandomController : Controller
    {
        private readonly IPostService _postService;

        public RandomController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult RandomHeader(int HeaderId)
        {
            ViewBag.RandomHeader = _postService.GetAllPostByHeaderId(HeaderId);
            return View();
        }
    }
}
