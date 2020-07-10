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
   
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customersQuery = _context.Customers.Include(c => c.MembershipType);

            if (!string.IsNullOrEmpty(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }
            var customersDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>);
            return Ok(customersDtos);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = _context.Customers
               .Include(c => c.MembershipType)
               .SingleOrDefault(customers => customers.Id == id);
               
             if (customer == null)
                 return NotFound();

             return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //GET /api/customers/1
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteCustomers(int id)
        {
            var customer = _context.Customers.SingleOrDefault(customers => customers.Id == id);

            if (customer == null)
                return NotFound();
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }
        
        //GET /api/customers/1
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateCustomers(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" +customerDto.Id), customerDto);
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCustomers(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb);
            
            _context.SaveChanges();
            return Ok(customerDto);
        }
    }
}
