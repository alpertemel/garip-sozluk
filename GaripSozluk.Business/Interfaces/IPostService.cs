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
        Post AddPost(PostVM model);
    }
}
