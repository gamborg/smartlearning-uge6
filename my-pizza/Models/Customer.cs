using System;

namespace my_pizza.Models
{
    public class Customer
    {
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Zip { get; set; }
    }
}