using System.Collections.Generic;
using InvoiceTest.Models;

namespace InvoiceTest.Repositories
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetAll();
        Invoice GetById(int id);
        void Add(Invoice invoice);
        void Update(int id, Invoice invoice);
        void Delete(Invoice invoice);
    }
}
