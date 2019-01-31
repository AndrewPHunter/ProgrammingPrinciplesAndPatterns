using System.Collections.Generic;

namespace FilterMapReduce
{
    public sealed class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }

    public sealed class Order
    {
        public string Item { get; set; }
        public int Amount { get; set; }
    }

    public sealed class CustomerCondensed
    {
        public CustomerCondensed(string name, IEnumerable<Order> orders)
        {
            Name = name;
            Orders = orders;
        }
        public string Name { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }

}
