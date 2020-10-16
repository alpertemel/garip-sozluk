using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Interfaces
{
   public interface IPostService
    {
        IQueryable<Post> GetAllPostByHeaderId(int id);

        //Todo: servislerden dönecek olan nesneler genellikle viewmodel olsun. burada önyüze bir şey dönmemişsin ama eğer dönersen postviewmodel dön.
        Post AddPost(PostVM model);
    }
}
