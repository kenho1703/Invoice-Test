using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}