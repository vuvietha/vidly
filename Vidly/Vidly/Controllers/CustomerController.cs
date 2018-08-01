using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        //List<CustomerModel> customers = new List<CustomerModel>()
        //    {
        //        new CustomerModel {Id =1, Name = "customer 1" },
        //        new CustomerModel {Id=2, Name = "customer 2" }
        //    };
        // GET: Customer
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(c =>c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Detail(int id) 
        {
            //var customer = GetCustomers().SingleOrDefault(x => x.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        public ActionResult New()
        {
            ViewBag.Title = "New Customer";
            var membershipTypes = _context.MembershipTypes.ToList();
            var ViewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };     
            return View("CustomerForm",ViewModel);
        }
        [HttpPost]
        public ActionResult Save( CustomerModel customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };
                return View("CustomerForm", viewModel);

            }
                
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDB.Name = customer.Name;
                customerInDB.Birthday = customer.Birthday;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Edit Customer";
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var membershipTypes = _context.MembershipTypes.ToList();
            var ViewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes

            };

            return View("CustomerForm",ViewModel);
        }
        private IEnumerable<CustomerModel> GetCustomers()
        {
            return new List<CustomerModel>
            {
                new CustomerModel {Id =1 , Name = "John Smith" },
                new CustomerModel {Id = 2, Name = "Mary Williams" }

            };
        }
    }
}