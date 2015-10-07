using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTest.Models
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public Product Product { get;set; }
        public Invoice Invoice { get;set; }
    }

    public class InvoiceItemPost
    {
        public int Quantity
        {
            get;
            set;
        }
        public float Price
        {
            get;
            set;
        }
        public int ProductId
        {
            get;
            set;
        }
    }
}