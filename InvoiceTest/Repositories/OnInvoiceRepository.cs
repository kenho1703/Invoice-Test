using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceTest.Models;

namespace InvoiceTest.Repositories
{
    public class OnInvoiceRepository : IDisposable, IOnInvoiceRepository
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public IEnumerable<OnInvoice> GetAll()
        {
            return _db.OnInvoices;
        }
        public OnInvoice GetById(int id)
        {
            return _db.OnInvoices.FirstOrDefault(p => p.Id == id);
        }
        public void Add(OnInvoice onInvoice)
        {
            _db.OnInvoices.Add(onInvoice);
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