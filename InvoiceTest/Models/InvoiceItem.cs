using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTest.Models
{
    public class InvoiceItem
    {
        public InvoiceItem(Product product, Invoice invoice)
        {
            this.Product = product;
            this.Invoice = invoice;
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public Product Product { get; private set; }
        public Invoice Invoice { get; private set; }
    }
}