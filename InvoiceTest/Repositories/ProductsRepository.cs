using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceTest.Models;

namespace InvoiceTest.Repositories
{
    public class ProductRepository : IDisposable, IProductRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<Product> GetAll()
        {
            return _db.Products;
        }
        public Product GetById(int id)
        {
            return _db.Products.FirstOrDefault(p => p.Id == id);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}