using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEF
{
    static class CustomerDb
    {
        public static List<Customer> GetCustomers()
        {
            var context = new BookRegContext();

            //SELECT * FROM Customers
            List<Customer> allCustomers =
                                (from c in context.Customer
                                 select c).ToList();

            return allCustomers;
        }

        public static Customer AddCustomer(Customer c)
        {
            BookRegContext context = new BookRegContext();

            context.Customer.Add(c);

            context.SaveChanges();

            return c;
        }

        public static void DeleteCustomer(Customer c)
        {
            var context = new BookRegContext();

            //context.Customer.Attach(c);
            //context.Customer.Remove(c);

            //Alternative
            context.Entry(c).State =
                System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();
        }

        public static Customer Update(Customer c)
        {
            BookRegContext context = new BookRegContext();

            context.Entry(c).State = EntityState.Modified;

            context.SaveChanges();

            return c;

        }

    }
}
