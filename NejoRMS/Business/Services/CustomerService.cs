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
    public class CustomerService : ICustomerModel
    {
        private readonly Db _db;
        public CustomerService(Db db)
        {
            _db = db;
        }
        public Result Add(CustomerModel model)
        {
            var entity = new Customer()
            {
                Date = DateTime.Now,
                Name = model.Name,
                Description = model.Description,
                CustomerProducts = model.ProductIdsInput.Select(productId => new CustomerProduct()
                {
                    ProductId = productId
                }).ToList()
            };

            _db.Customers.Add(entity);
            _db.SaveChanges();
            return new SuccessResult("Added Successfully");
        }

        public Result Delete(int id)
        {
            var entity = _db.Customers.Include(c => c.CustomerProducts).SingleOrDefault(c => c.Id == id);
            
            if(entity is null)
            {
                return new SuccessResult("Customer not found");
                
            }
            _db.CustomerProducts.RemoveRange(entity.CustomerProducts);
            _db.Customers.Remove(entity);

            _db.SaveChanges();
            return new SuccessResult("Customer Deleted Successfully");

        }

        public IQueryable<CustomerModel> Query()
        {
            return _db.Customers.Include(c => c.CustomerProducts).Select(c => new CustomerModel()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Date = c.Date,
                DateOutput = c.Date.HasValue ? c.Date.Value.ToString("dd/MM/yyyy") : "tarih yok",


                PriceOutput = c.CustomerProducts.Select(cp => cp.Product.Price).ToString(),
                ProductsCountOutput = c.CustomerProducts.Select(cp => cp.ProductId).Sum(),
                ProductIdsInput = c.CustomerProducts.Select(cp => cp.ProductId).ToList(),
                ProductNamesOutput = string.Join("<br/>", c.CustomerProducts.Select(cp => cp.Product.Name)),
            });
        }

        public Result Update(CustomerModel model)
        {
            var existingEntity = _db.Customers.Include(c => c.CustomerProducts).SingleOrDefault(c => c.Id == model.Id);
            if(existingEntity != null && existingEntity.CustomerProducts is not null)
            {
                _db.CustomerProducts.RemoveRange(existingEntity.CustomerProducts);
            }
            existingEntity.Date = model.Date;
            existingEntity.Name = model.Name;
            existingEntity.Description = model.Description;
            existingEntity.CustomerProducts = model.ProductIdsInput.Select(productId => new CustomerProduct()
            {
                ProductId = productId,
            }).ToList();

            _db.Customers.Update(existingEntity);
            _db.SaveChanges();

            return new SuccessResult("Updated Successfully");

        }
    }
}
