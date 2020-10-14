using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GaripSozluk.Data.Repositories
{
    public class BlockedUserRepository : BaseRepository<BlockedUser>, IPostRepository
    {
        private readonly GaripSozlukDbContext _context;
        public BlockedUserRepository(GaripSozlukDbContext context) : base(context)
        {
            _context = context;
        }

        public Post Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public Post Get(Expression<Func<Post, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Post Update(Post entity)
        {
            throw new NotImplementedException();
        }

        IQueryable<Post> IBaseRepository<Post>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
