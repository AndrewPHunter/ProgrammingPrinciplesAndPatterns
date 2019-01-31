using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FilterMapReduce
{
    public sealed class CustomerRepository
    {
        private IEnumerable<Customer> _customers = new List<Customer>();
        private readonly string _fileName = "db.json";

        public CustomerRepository()
        {
            LoadJson();
        }

        public IList<Customer> GetCustomersOver21()
        {
            var customersOver21 = new List<Customer>();

            foreach (var customer in _customers)
            {
                if (customer.Age >= 21)
                {
                    customersOver21.Add(customer);
                }
            }

            return customersOver21;
        }

        public IList<CustomerCondensed> GetCustomerCondensedInformation()
        {
            var condensed = new List<CustomerCondensed>();
            foreach (var customer in _customers)
            {
                var summary = new CustomerCondensed($"{customer.FirstName} {customer.LastName}", customer.Orders);
                condensed.Add(summary);
            }

            return condensed;
        }

        public int GetTotalSales()
        {
            int total = 0;
            foreach (var customer in _customers)
            {
                foreach (var order in customer.Orders)
                {
                    total += order.Amount;
                }
            }

            return total;
        }

        private void LoadJson()
        {
            using (var reader = new StreamReader(_fileName))
            {
                var file = reader.ReadToEnd();
                this._customers = JsonConvert.DeserializeObject<List<Customer>>(file);
            }
        }

        public IList<Customer> GetCustomersOver21Declarative()
        {
            return
                this
                    ._customers
                    .Where(customer => customer.Age >= 21)
                    .ToList();
        }

        public IList<CustomerCondensed> GetCustomerCondensedDeclarative()
        {
            return
                this
                    ._customers
                    .Select(customer =>
                        new CustomerCondensed($"{customer.FirstName} {customer.LastName}", customer.Orders))
                    .ToList();
        }

        public int GetTotalSalesDeclarative()
        {
           
            return
                this
                    ._customers
                    .SelectMany(customer => customer.Orders)
                    .Aggregate(0, (acc, order) => acc + order.Amount);
        }
    }
}
