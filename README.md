# MockDbSetHelper

### TL;DR

MockDbSetHelper is a class with just one static method that creates a generic mock DbSet, based on a list of entities, for unit testing.

### Description
Since this is the third time I created a similar class, it figures it deserves a repo, even if it serves only me.

Creating a mock DbSet with Moq is fairly straightforward, but it requires a bit of boilerplating. I've created a class that does this for us. 
The class is generic, so you have to keep in mind to put the desired entity type between the angle brackets (the Customer class in the examples). 
The rest of the solution you find in this repo is for demontration purposes and to play around with.
You can run and debug the unit test in the solution to see how things work.

In the unit CustomerUnitTests.cs you will find a fake unit test. Actually, it doesn't even test a piece of code. The arrange section is where the 
interesting stuff happens. The act and assert section are filled with code for an easy demonstration. To make your code testable, make sure you
inject the DbSet in the code you want to test.

For now, the class itself is so small and simple that a Nuget package would be overkill. You can just copy the code from the unit in the demo solution.

### MockDbSetHelper class
This is the class that does our 'heavy lifting' or at least, makes life a bit easier. It has only one static method, so you don't have to instantiate an object. 
Just call the GetMockDbSet method and your DbSet is ready to use. The only thing you need to feed it, is a list of entities you want in your DbSet.

### Instructions
1. If not done so, create a project for unit testing in your solution
2. Add, if not already present, the Moq Nuget package
3. Open the demo solution MockDbSetHelperDemo.sln
4. Go to the project DemoUnitTestProject and find the file MockDbSetHelper.cs
5. Copy the code and paste in your own unit test project
6. Modify the namespace in the pasted code to match your own project
7. In your unit test, create a list of entities (can be plain old C# objects), e.g.

```
            var customerList = new List<Customer>
            {
                new Customer { CustomerId = 2, FirstName = "Scott", LastName = "Hanselman", CustomerSince = new DateTime(2021, 4, 30)},
                new Customer { CustomerId = 3, FirstName = "Scott", LastName = "Guthrie", CustomerSince = new DateTime(2021, 4, 29)}
            };
```
 8. Create the mock DbSet using the static method GetMockDbSet, e.g.

```
            var mockSet = MockDbSetHelper<Customer>.GetMockDbSet(customerList);
```
 9. Query the DbSet as you would, e.g.

```
            var foundCustomers = (from customer in mockSet
                                 where customer.LastName == "Hanselman"
                                 select customer).ToList();
```

### Restrictions of use
This repo is provided as is. Use, clone, copy, modify as you like, but all of it at your own responsibility. Use is intended for unit testing.

### Recognitions
Built on the work done in 

https://www.loganfranken.com/blog/517/mocking-dbset-queries-in-ef6/

https://www.codingame.com/playgrounds/2290/demystifying-c-generics/generics-constraints

for which I am grateful to the authors.
