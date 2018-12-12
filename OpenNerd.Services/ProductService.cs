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
                    CreatorId = _userId,
                   
                     AuthorId= model.AuthorId,
                     Title =model.Title,
                     Genre = model.Genre,
                     Volume = model.Volume,
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
                        .Where(e => e.CreatorId == _userId)
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    ProductId = e.ProductId,
                                    Title = e.Title,
                                    AuthorName = e.Author.AuthorName,
                                    AuthorId = e.AuthorId,
                                   Volume = e.Volume,
                                    Genre = e.Genre,
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
                        .Single(e => e.ProductId == productId && e.CreatorId == _userId);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        Title = entity.Title,
                        AuthorName = entity.Author.AuthorName,
                        AuthorId = entity.AuthorId,
                        Genre = entity.Genre,
                        Volume = entity.Volume,
                        CreatedUtc = entity.CreatedUtc,
                      
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
                        .Single(e => e.ProductId == model.ProductId && e.CreatorId == _userId);

                entity.Title = model.Title;
                entity.AuthorId = model.AuthorId;
                entity.Volume = model.Volume;
                entity.Genre = model.Genre;
               

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
                        .Single(e => e.ProductId == productId && e.CreatorId == _userId);

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}