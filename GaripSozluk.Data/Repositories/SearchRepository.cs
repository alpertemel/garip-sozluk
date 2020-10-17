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
        public IQueryable<Header> DetailSearchHeader(string text, DateTime create, int categoryid)
        {
            return GetAll().Where(x => x.Title==text).Where(x => x.CreateDate==create).Where(x=>x.CategoryId==categoryid);
        }
    }
}
