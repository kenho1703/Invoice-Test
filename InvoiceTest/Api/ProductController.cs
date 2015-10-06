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
    [Authorize, RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository = new ProductRepository();

        [HttpGet,Route("")]
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            var products = _productRepository.GetAll().ToList();

            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpGet, Route("{id}")]
        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            var product = _productRepository.GetById(id);
            if(product == null)
                return Request.CreateResponse(HttpStatusCode.NotFound,
                    new
                    {
                        errorMessage = "Requested product not could not be found"
                    });
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

    }
}