using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTest.Models
{
    public class OnInvoice
    {
        public OnInvoice(Product product)
        {
            this.Product = product;
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; private set; }
    }
}