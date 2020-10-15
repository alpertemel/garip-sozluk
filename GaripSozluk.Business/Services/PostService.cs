using GaripSozluk.Business.Interfaces;
using GaripSozluk.Common.ViewModels;
using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GaripSozluk.Business.Services
{
    public class PostService:IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IQueryable<Post> GetAllPostByHeaderId(int id)
        {
            return _postRepository.GetAllPostByHeaderId(id);
        }
        public Post AddPost(PostVM model)
        {
            var Post = new Post()
            {
                Content = model.Content,
                CreateDate = DateTime.Now,
                HeaderId = model.HeaderId,
                UserId = model.UserId
            };

            var entity = _postRepository.Add(Post);

            try
            {
                _postRepository.SaveChanges();
                return Post;
            }
            catch (Exception ex)
            {
                var errorMessage = ex.Message;
                return null;
            }
        }
    }
}
