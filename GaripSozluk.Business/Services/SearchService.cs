using GaripSozluk.Business.Interfaces;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Services
{
    public class SearchService: ISearchService
    {
        private readonly ISearchRepository _searchRepository;
        public SearchService(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public IQueryable<Header> SearchHeader(string text)
        {
            return _searchRepository.SearchHeader(text);
        }

      public IQueryable<Header> DetailSearchHeader(string text, DateTime create, int categoryid)
        {
            return _searchRepository.DetailSearchHeader(text, create, categoryid);
        }




    }
}
