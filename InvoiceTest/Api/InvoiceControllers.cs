using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InvoiceTest.Models;
using InvoiceTest.Repositories;

namespace InvoiceTest.Api
{
    [Authorize,RoutePrefix("api/invoices")]
    public class InvoiceController : ApiController
    {
        //private readonly IInvoiceRepository _invoiceRepository = new InvoiceRepository();
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        // GET api/<controller>
        [Route(""),HttpGet]
        public HttpResponseMessage Get()
        {
            var invoices = _invoiceRepository.GetAll().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, invoices);
        }

        // GET api/<controller>/5
        [Route("{id}"), HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var invoice = _invoiceRepository.GetById(id);
            if (invoice == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new
                    {
                        errorMessage = "Requested Invoice not could not be found"
                    });
            return Request.CreateResponse(HttpStatusCode.OK, invoice);
        }
        [Route(""), HttpPost]
        public HttpResponseMessage Post([FromBody] Invoice invoice)
        {
            _invoiceRepository.Add(invoice);
            return Request.CreateResponse(HttpStatusCode.Created, invoice);
        }       
        [Route("invoiceItems"), HttpPost]
        public HttpResponseMessage PostInvoiceItems([FromBody] InvoicePost data)
        {
            var invoiceItems = data.InvoiceItems.Select(invoiceItemPost => new InvoiceItem()
            {
                ProductId = invoiceItemPost.ProductId, Quantity = invoiceItemPost.Quantity, Price = invoiceItemPost.Price
            }).ToList();
            var invoice = new Invoice()
            {
                VAT = data.VAT,
                Shipping = data.Shipping,
                SubTotal = data.SubTotal,
                Total = data.Total,
                InvoiceItems = invoiceItems
            };
            _invoiceRepository.Add(invoice);
            return Request.CreateResponse(HttpStatusCode.Created, invoice);
        }

        [Route("{id}"), HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] Invoice invoice)
        {
            var data = _invoiceRepository.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new
                    {
                        errorMessage = "Requested Invoice not could not be found"
                    });
            _invoiceRepository.Update(id, invoice);
            return Request.CreateResponse(HttpStatusCode.Created, invoice);
        }

        [Route("{id}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var data = _invoiceRepository.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new
                    {
                        errorMessage = "Requested Invoice not could not be found"
                    });
            _invoiceRepository.Delete(data);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}