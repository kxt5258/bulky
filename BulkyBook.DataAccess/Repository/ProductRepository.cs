using System;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product Product)
        {
            var objFromDb = _db.Products.FirstOrDefault(u=> u.Id == Product.Id);
            if(objFromDb != null)
            {
                objFromDb.Name = Product.Name;
                objFromDb.ISBN = Product.ISBN;
                objFromDb.Price = Product.Price;
                objFromDb.Price50 = Product.Price50;
                objFromDb.Price100 = Product.Price100;
                objFromDb.ListPrice = Product.ListPrice;
                objFromDb.Description = Product.Description;
                objFromDb.CategoryId = Product.CategoryId;
                objFromDb.Author = Product.Author;
                objFromDb.CoverTypeId = Product.CoverTypeId;
                if(Product.ImageUrl != null)
                {
                    objFromDb.ImageUrl = Product.ImageUrl;
                }
                _db.Products.Update(objFromDb);
            }
            
        }
    }
}

