using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceTest.Models;

namespace InvoiceTest.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<Product> GetAll()
        {
            return _db.Products;
        }
        public Product GetById(int id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}