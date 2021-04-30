using Microsoft.VisualStudio.TestTools.UnitTesting;
using MockDbSetHelperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoUnitTestProject
{
    [TestClass]
    public class CustomerUnitTests
    {
        [TestMethod]
        public void Customers_FindByLastName_FindsCorrectCustomers()
        {
            // Arrange
            var customerList = new List<Customer>
            {
                new Customer { CustomerId = 2, FirstName = "Scott", LastName = "Hanselman", CustomerSince = new DateTime(2021, 4, 30)},
                new Customer { CustomerId = 3, FirstName = "Scott", LastName = "Guthrie", CustomerSince = new DateTime(2021, 4, 29)}
            };

            var mockSet = MockDbSetHelper<Customer>.GetMockDbSet(customerList);

            // Act
            var foundCustomers = (from customer in mockSet
                                 where customer.LastName == "Hanselman"
                                 select customer).ToList();

            // Assert
            Assert.AreEqual(1, foundCustomers.Count);
            Assert.AreEqual("Hanselman", foundCustomers[0].LastName);
        }
    }
}
