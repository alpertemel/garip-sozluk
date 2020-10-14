using GaripSozluk.Data.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface IHeaderCategoryService
    {
        List<SelectListItem> GetHeadersSelect(int id);
        IQueryable<HeaderCategory> HeaderCategoryList();
    }
}
