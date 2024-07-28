using Business.Models;
using Business.Results;
using Business.Results.Bases;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ProductService : IProductModel
    {
        private readonly Db _db;


        public ProductService(Db db)
        {
            _db = db;
        }

        public Result Add(ProductModel model)
        {
            var entity = new Product()
            {
                Date = model.Date,
                Name = model.Name,
                Price = model.Price,
                Quantity = model.Quantity
            };

            _db.Products.Add(entity);
            _db.SaveChanges();

            return new SuccessResult("Product Added Successfully");

        }

        public Result Delete(int id)
        {
            var entity = _db.Products.Include(p => p.CustomerProducts).SingleOrDefault(p => p.Id == id);
            if(entity is null)
            {
                return new ErrorResult("product not found");
            }
            _db.CustomerProducts.RemoveRange(entity.CustomerProducts);
            _db.Products.Remove(entity);
            _db.SaveChanges();
            return new SuccessResult("Product Deleted Successfully");
        }

        public IQueryable<ProductModel> Query()
        {
            return _db.Products.Include(p => p.CustomerProducts).Select(p => new ProductModel()
            {
                Id = p.Id,
                Date = p.Date,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                
                DateOutput = p.Date.HasValue ? p.Date.Value.ToString("dd/MM/yyyy") : "tarih yok",
                PriceOutput = p.Price.ToString("c"),
                QunatityOutput = p.Quantity.ToString("c"),
            
            });
        }

        public Result Update(ProductModel model)
        {
            var existingEntity = _db.Products.Include(p => p.CustomerProducts).SingleOrDefault(p => p.Id == model.Id);
            if(existingEntity is not null && existingEntity.CustomerProducts is not null) 
            {
                existingEntity.Date = model.Date;
                existingEntity.Name = model.Name;
                existingEntity.Price = model.Price; 
                existingEntity.Quantity = model.Quantity;   
                
            }

            _db.Products.Update(existingEntity);
            _db.SaveChanges();

            return new SuccessResult("Updated Successfully");
        }
    }
}
