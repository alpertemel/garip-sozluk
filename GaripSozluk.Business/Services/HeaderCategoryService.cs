using GaripSozluk.Business.Interfaces;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Services
{
    public class HeaderCategoryService:IHeaderCategoryService
    {
        private readonly IHeaderCategoryRepository _headerCategoryRepository;

        public HeaderCategoryService(IHeaderCategoryRepository headerCategoryRepository)
        {

            _headerCategoryRepository = headerCategoryRepository;
        }


        public IQueryable<HeaderCategory> HeaderCategoryList()
        {
            return _headerCategoryRepository.GetAll();
        }

        public List<SelectListItem> GetHeadersSelect(int id)
        {
            var list = new List<SelectListItem>();

            var categories = HeaderCategoryList();

            foreach (var item in categories)
            {
                if (item.Id != id)
                {
                    list.Add(new SelectListItem(item.Title, item.Id.ToString()));
                }
                else
                {
                    list.Add(new SelectListItem(item.Title, item.Id.ToString(), true));
                }

            }
            return list;
        }

    }
}
