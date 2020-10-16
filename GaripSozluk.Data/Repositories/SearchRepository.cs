using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Data.Repositories
{
   public class SearchRepository: BaseRepository<Header>, ISearchRepository
    {
        public SearchRepository(GaripSozlukDbContext context):base(context)
        {

        }
        public IQueryable<Header> SearchHeader(string text)
        {
            return GetAll().Where(x => x.Title.Contains(text));
        }
    }
}
