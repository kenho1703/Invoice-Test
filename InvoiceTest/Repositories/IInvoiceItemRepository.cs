using System.Collections.Generic;
using InvoiceTest.Models;

namespace InvoiceTest.Repositories
{
    public interface IInvoiceItemRepository
    {
        IEnumerable<InvoiceItem> GetAll();
        InvoiceItem GetById(int id);
        void Add(InvoiceItem onInvoice);
        void Update(int id, InvoiceItem onInvoice);
        void Delete(InvoiceItem onInvoice);
    }
}
