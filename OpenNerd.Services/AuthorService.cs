using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenNerd.Data;
using OpenNerd.Models;

namespace OpenNerd.Services
{
   public class AuthorService
    {
        private readonly Guid _userId;

        public AuthorService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAuthor(AuthorCreate model)
        {
            var entity =
                new Author()
                {
                    CreatorId = _userId,
                    AuthorName = model.AuthorName,
                    Age = model.Age,
                    Gender = model.Gender,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Authors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AuthorListItem> GetAuthors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Authors
                        .Where(e => e.CreatorId == _userId)
                        .Select(
                            e =>
                                new AuthorListItem
                                {
                                    AuthorId = e.AuthorId,
                                    AuthorName = e.AuthorName,
                                    Age = e.Age,
                                    Gender = e.Gender,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public AuthorDetail GetAuthorById(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == authorId && e.CreatorId == _userId);
                return
                    new AuthorDetail
                    {
                        AuthorId = entity.AuthorId,
                        AuthorName = entity.AuthorName,
                        Age = entity.Age,
                        Gender = entity.Gender,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateAuthor(AuthorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == model.AuthorId && e.CreatorId == _userId);

                entity.AuthorName = model.AuthorName;
                entity.Age = model.Age;
                entity.Gender = model.Gender;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAuthor(int authorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Authors
                        .Single(e => e.AuthorId == authorId && e.CreatorId == _userId);

                ctx.Authors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
