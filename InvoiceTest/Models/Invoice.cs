using InvoiceTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTest.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public float VAT { get; set; }
        public float SubTotal { get; set; }
        public float Total { get; set; }
        public float Shipping { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems
        {
            get;
            set;
        }
    }   
    public class InvoicePost
    {
        public float VAT { get; set; }
        public float SubTotal { get; set; }
        public float Total { get; set; }
        public float Shipping { get; set; }

        public List<InvoiceItemPost> InvoiceItems
        {
            get;
            set;
        }
    }
}