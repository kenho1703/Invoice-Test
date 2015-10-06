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
    [Authorize, RoutePrefix("api/onInvoices")]
    public class InvoiceItemController : ApiController
    {
       // private readonly IInvoiceItemRepository _invoiceItemRepository = new InvoiceItemRepository();
        private readonly IInvoiceItemRepository _invoiceItemRepository;

        public InvoiceItemController(IInvoiceItemRepository invoiceItemRepository)
        {
            _invoiceItemRepository = invoiceItemRepository;
        }

        [HttpGet,Route("")]
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var onInvoices = _invoiceItemRepository.GetAll().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, onInvoices);
        }

        [HttpGet, Route("{id}")]
        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var onInvoice = _invoiceItemRepository.GetById(id);
            if(onInvoice == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new
                    {
                        errorMessage = "Requested onInvoice not could not be found"
                    });
            return Request.CreateResponse(HttpStatusCode.OK, onInvoice);
        }

        [HttpPost, Route("")]
        public HttpResponseMessage Post([FromBody] InvoiceItem onInvoice)
        {
            _invoiceItemRepository.Add(onInvoice);
            return Request.CreateResponse(HttpStatusCode.Created, onInvoice);
        }

        [HttpPut, Route("{id}")]
        public HttpResponseMessage Put(int id, [FromBody] InvoiceItem onInvoice)
        {
            var data = _invoiceItemRepository.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new
                    {
                        errorMessage = "Requested onInvoice not could not be found"
                    });
            _invoiceItemRepository.Update(id, onInvoice);
            return Request.CreateResponse(HttpStatusCode.Created, onInvoice);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = _invoiceItemRepository.GetById(id);
            if (data == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new
                    {
                        errorMessage = "Requested onInvoice not could not be found"
                    });
            _invoiceItemRepository.Delete(data);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}