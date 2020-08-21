using HelpingHand.Data;
using HelpingHand.Models.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHand.Services
{
    public class CustomerService
    {
        private readonly Guid _customerID;
        public CustomerService(Guid Id)
        {
            _customerID = Id;
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var customer = new Customer()
            {
                ID = _customerID,
                Name = model.Name,
                Email = model.Email,
                City = model.City,
                State = model.State
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(customer);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customerQuery = ctx.Customers.Where(e => e.ID == _customerID).Select(e => new CustomerListItem
                    {
                        CustomerID = e.CustomerID,
                        Name = e.Name,
                        Email = e.Email,
                        City = e.City,
                        State = e.State
                    }
                );
                return customerQuery.ToArray();
            }
        }
        public CustomerDetail GetCustomerById(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx.Customers.Single(e => e.CustomerID == customerId);
                return new CustomerDetail
                {
                    CustomerID = customer.CustomerID,
                    ID = customer.ID,
                    Name = customer.Name,
                    Email = customer.Email,
                    City = customer.City,
                    State = customer.State
                };
            }
        }
        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx.Customers.Single(e => e.CustomerID == model.CustomerID && e.ID == _customerID);
                customer.Name = model.Name;
                customer.Email = model.Email;
                customer.City = model.City;
                customer.State = model.State;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CustomerDelete(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var customer = ctx.Customers.Single(e => e.CustomerID == customerId && e.ID == _customerID);
                ctx.Customers.Remove(customer);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
