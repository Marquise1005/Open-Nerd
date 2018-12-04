using System;
using System.Collections.Generic;
using System.Linq;
using OpenNerd.Models;
using OpenNerd.Data;

namespace OpenNerd.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    Type = model.Type,
                    AuthorName = model.AuthorName,
                    Issue = model.Issue,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    ProductId = e.ProductId,
                                    Title = e.Title,
                                   Issue = e.Issue,
                                    AuthorName = e.AuthorName,
                                    Type = e.Type,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
        public ProductDetail GetProductById(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId && e.OwnerId == _userId);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        Title = entity.Title,
                        AuthorName = entity.AuthorName,
                        Issue = entity.Issue,
                        Type = entity.Type,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == model.ProductId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.AuthorName = model.AuthorName;
                entity.Issue = model.Issue;
                entity.Type = model.Type;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId && e.OwnerId == _userId);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}