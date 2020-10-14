using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GaripSozluk.Business.Services
{
    public class HeaderService : IHeaderService
    {
        private readonly IHeaderRepository _headerRepository;
        private readonly IHeaderCategoryRepository _headerCategoryRepository;
        public HeaderService(IHeaderRepository headerRepository, IHeaderCategoryRepository headerCategoryRepository)
        {
            _headerRepository = headerRepository;
            _headerCategoryRepository = headerCategoryRepository;
        }

        public IQueryable<Header> GetAll()
        {
            return _headerRepository.GetAll();
        }

        public Header AddHeader(HeaderVM model)
        {
            var Header = new Header()
            {
                Title = model.Title,
                CategoryId = model.CategoryId,
                ClickCount = 0,
                UserId = model.UserId,
                CreateDate = DateTime.Now
             };

            var entity = _headerRepository.Add(Header);

            try
            {
                _headerRepository.SaveChanges();
                return Header;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                return null;
            }
        }
         public  IQueryable<Header> GetAllHeaderByCategoryId(int id)
        {
            return _headerRepository.GetAllHeaderByCategoryId(id);
        }

    }
}
