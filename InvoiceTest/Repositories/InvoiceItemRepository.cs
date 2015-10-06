using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceTest.Models;
using System.Data.Entity;

namespace InvoiceTest.Repositories
{
    public class InvoiceItemRepository : IDisposable, IInvoiceItemRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<InvoiceItem> GetAll()
        {
            return _db.InvoiceItems;
        }
        public InvoiceItem GetById(int id)
        {
            return _db.InvoiceItems.FirstOrDefault(p => p.Id == id);
        }
        public void Add(InvoiceItem onInvoice)
        {
            _db.InvoiceItems.Add(onInvoice);
            _db.SaveChanges();
        }

        public void Update(int id, InvoiceItem onInvoice)
        {
            _db.Entry(onInvoice).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(InvoiceItem onInvoice)
        {
            _db.InvoiceItems.Remove(onInvoice);
            _db.SaveChanges();

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