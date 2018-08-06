using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/customer
        public IHttpActionResult GetCustomers()
        {
            //var lstCustomer = _context.Customers.ToList();
            //return Mapper.Map<IEnumerable<CustomerModel>, IEnumerable<CustomerDTO>>(lstCustomer);
            var customerDTOs = _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<CustomerModel, CustomerDTO>);
            return Ok(customerDTOs);
        }
        //GET /api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<CustomerModel,CustomerDTO>(customer));
        }
        //POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var customer = Mapper.Map<CustomerDTO, CustomerModel>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDTO.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDTO);
        }
        //PUT /api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customerDTO.Id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Mapper.Map<CustomerDTO, CustomerModel>(customerDTO, customerInDb);
            Mapper.Map(customerDTO, customerInDb);
            _context.SaveChanges();

        }
        //DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customer);
            _context.SaveChanges();

        }
    }
}
