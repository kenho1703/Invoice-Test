using System.Collections.Generic;
using InvoiceTest.Models;

namespace InvoiceTest.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
    }
}
