using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
    public interface ISearchService
    {
        IQueryable<Header> SearchHeader(string text);
    }
}
