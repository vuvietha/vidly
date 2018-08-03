using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

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
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            //var lstCustomer = _context.Customers.ToList();
            //return Mapper.Map<IEnumerable<CustomerModel>, IEnumerable<CustomerDTO>>(lstCustomer);
            return _context.Customers.ToList().Select(Mapper.Map<CustomerModel, CustomerDTO>);
        }
        //GET /api/customer/1
        public CustomerDTO GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<CustomerModel,CustomerDTO>(customer);
        }
        //POST /api/customer
        [HttpPost]
        public CustomerDTO CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customer = Mapper.Map<CustomerDTO, CustomerModel>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDTO.Id = customer.Id;
            return customerDTO;
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
