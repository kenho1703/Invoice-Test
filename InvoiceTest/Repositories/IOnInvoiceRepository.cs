using System.Collections.Generic;
using InvoiceTest.Models;

namespace InvoiceTest.Repositories
{
    public interface IOnInvoiceRepository
    {
        IEnumerable<OnInvoice> GetAll();
        OnInvoice GetById(int id);
        void Add(OnInvoice onInvoice);
    }
}
