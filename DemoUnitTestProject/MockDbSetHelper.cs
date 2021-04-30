using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace DemoUnitTestProject
{
    public class MockDbSetHelper<TEntity> where TEntity : class
    {
        public static DbSet<TEntity> GetMockDbSet(IList<TEntity> list)
        {
            // Convert the IEnumerable list to an IQueryable list
            IQueryable<TEntity> queryableList = list.AsQueryable();

            var mockSet = new Mock<DbSet<TEntity>>();
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(queryableList.Provider);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(queryableList.Expression);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(queryableList.ElementType);
            mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(queryableList.GetEnumerator());

            return mockSet.Object;
        }
    }
}
