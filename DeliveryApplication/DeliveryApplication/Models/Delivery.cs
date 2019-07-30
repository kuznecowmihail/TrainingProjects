using System;

namespace DeliveryApplication.Models
{
    public class Delivery
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateTime { get; set; }

        public int ProductID { get; set; }
    }
}