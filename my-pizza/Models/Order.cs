using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace my_pizza.Models
{
    public class Order
    {
        internal string _customer { get; set; }
        [NotMapped]
        public Customer Customer
        {
            get { return _customer == null ? null : JsonConvert.DeserializeObject<Customer>(_customer); }
            set { _customer = JsonConvert.SerializeObject(value); }
        }

        internal string _products { get; set; }
        [NotMapped]
        public List<Product> Products
        {
            get { return _products == null ? null : JsonConvert.DeserializeObject<List<Product>>(_products); }
            set { _products = JsonConvert.SerializeObject(value); }
        }

        public int Id { get; set; }
        public int Vat { get; set; }
        public int Fee { get; set; }
        public string Currency { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        [NotMapped]
        public string PaymentUrl { get; set; }
    }
}