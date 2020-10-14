using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GaripSozluk.WebApp.Controllers
{
    public class HeaderController : Controller
    {
        private readonly IHeaderCategoryService _headerCategoryService;
        private readonly IHeaderService _headerService;

        public HeaderController(IHeaderCategoryService headerCategoryService, IHeaderService headerService)
        {
            _headerCategoryService = headerCategoryService;
            _headerService = headerService;
        }

        [Authorize]
        public IActionResult CreateHeader(int id)
        {
            ViewBag.HeaderCategoryList = _headerCategoryService.GetHeadersSelect(id);
            ViewBag.Headers = _headerService.GetAll();
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateHeader(HeaderVM model)
        {
            if (ModelState.IsValid)
            {
                var user = HttpContext.User;
                var userId = int.Parse( user.Claims.ToList().Where(x=>x.Type==ClaimTypes.NameIdentifier).FirstOrDefault().Value);
                model.UserId = userId;
                _headerService.AddHeader(model);
            }
            ViewBag.HeaderCategoryList = _headerCategoryService.HeaderCategoryList();
            ViewBag.Headers = _headerService.GetAll();
            return View();
        }

        public IActionResult GetCategoryHeader(int CategoryID,int id)
        {
            //ViewBag.Headers = _headerService.GetAllHeaderByCategoryId(id);
            //ViewBag.HeaderCategoryList = _headerCategoryService.HeaderCategoryList();
            ViewBag.Headers = _headerService.GetAll();
            ViewBag.HeaderByCategory = _headerService.GetAllHeaderByCategoryId(CategoryID);
            ViewBag.HeaderCategoryList = _headerCategoryService.GetHeadersSelect(id);
            return View();
        }


    }
}
