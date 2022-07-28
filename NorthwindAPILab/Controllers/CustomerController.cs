using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPILab.Models;

namespace NorthwindAPILab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public NorthwindContext northwindcontext = new NorthwindContext(); 
        
        [HttpGet("GetByCustomerId")]
        public Customer  GetById(string id)
        {
            return northwindcontext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        [HttpGet("GetByCompanyName")]
        public Customer GetByCompanyName(string name)
        {
            return northwindcontext.Customers.FirstOrDefault(c => c.CompanyName == name);
        }

        [HttpGet("GetByContactName")]
        public Customer GetByContactName(string contact)
        {
            return northwindcontext.Customers.FirstOrDefault(c => c.ContactName == contact);
        }

        [HttpPost("AddCustomer")]
        public Customer AddCustomer(string customerId, string companyName, string contactName, string contactTitle,
            string address, string city, string region, string postalCode, string country, string phone, string fax)
        {
            Customer newCustomer = new Customer()
            {
                CustomerId = customerId,
                CompanyName = companyName, 
                ContactName = contactName,
                ContactTitle = contactTitle,
                Address = address,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax
            };
            northwindcontext.Customers.Add(newCustomer);
            northwindcontext.SaveChanges();
            return newCustomer;
        }

        [HttpPatch("UpdateContactName")]
        public Customer UpdateContactName(string id, string contactName)
        {
            Customer customer = northwindcontext.Customers.FirstOrDefault(c => c.CustomerId == id);
            customer.ContactName = contactName;
            northwindcontext.Customers.Update(customer);
            northwindcontext.SaveChanges();
            return customer;
        }

        [HttpPatch("UpdateContactTitle")]
        public Customer UpdateContactTitle(string id, string contactTitle)
        {
            Customer customer = northwindcontext.Customers.FirstOrDefault(c => c.CustomerId == id);
            customer.ContactTitle = contactTitle;
            northwindcontext.Customers.Update(customer);
            northwindcontext.SaveChanges();
            return customer;
        }

    }
}
