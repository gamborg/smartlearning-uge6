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
        public int Discount { get; set; }
        public int Vat { get; set; }
        public int Fee { get; set; }
        public int Tips { get; set; }
        public string Currency { get; set; }
        public double Total { get; set; }
        public Status Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        [NotMapped]
        public string PaymentUrl { get; set; }
    }

    public enum Status 
    {
        PENDING = 0,
        AWAITING_PAYMENT = 1,
        AWAITING_FULFILLMENT = 2,
        AWAITING_DELIVERY = 3,
        AWAITING_PICKUP = 4,
        PARTIALLY_DELIVERY = 5,
        COMPLETED = 6,
        DELIVERED = 7,
        CANCELLED = 8,
        DECLINED = 9,
        REFUNDED = 10,
        DISPUTED = 11,
        VERIFICATION_REQUIRED = 12
    }
}