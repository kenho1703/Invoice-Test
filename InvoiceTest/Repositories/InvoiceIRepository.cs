using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceTest.Models;
using System.Data.Entity;

namespace InvoiceTest.Repositories
{
    public class InvoiceRepository : IDisposable, IInvoiceRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<Invoice> GetAll()
        {
            return _db.Invoices;
        }
        public Invoice GetById(int id)
        {
            return _db.Invoices.FirstOrDefault(p => p.Id == id);
        }
        public void Add(Invoice invoice)
        {
            _db.Invoices.Add(invoice);
            _db.SaveChanges();
        }

        public void Update(int id, Invoice invoice)
        {
            _db.Entry(invoice).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(Invoice invoice)
        {
            _db.Invoices.Remove(invoice);
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