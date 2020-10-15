using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface IHeaderService
    {
        IQueryable<Header> GetAll();

        IQueryable<Header> GetAllHeaderByCategoryId(int id);

        Header AddHeader(HeaderVM model);


    }
}
