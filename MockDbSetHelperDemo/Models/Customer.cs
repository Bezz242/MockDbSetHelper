using System;
using System.ComponentModel.DataAnnotations;

namespace MockDbSetHelperDemo.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CustomerSince { get; set; }
    }
}
