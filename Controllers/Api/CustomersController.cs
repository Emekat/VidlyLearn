using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using VidlyLearn.Dtos;
using VidlyLearn.Models;
using VidlyLearn.ViewModels;

namespace VidlyLearn.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _context.Customers.Include(customer => customer.MembershipType)
                .ToList().Select(Mapper.Map<Customer,CustomerDto>);
            return customers;
        }

        //GET /api/customers/1
        public  CustomerDto GetCustomer(int id)
        {
             var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(customers => customers.Id == id);

             if (customer == null)
                 throw new HttpResponseException(HttpStatusCode.NotFound);

             return Mapper.Map<Customer, CustomerDto>(customer);
        }


        //GET /api/customers/1
        [System.Web.Http.HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(customers => customers.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }

        //GET /api/customers/1
        [System.Web.Http.HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return customerDto;
        }

        [System.Web.Http.HttpPut]
        public CustomerDto UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(customerDto, customerInDB);
            
            _context.SaveChanges();
            return customerDto;
        }
    }
}
