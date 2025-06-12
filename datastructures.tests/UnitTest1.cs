using Xunit;
using Microsoft.EntityFrameworkCore;
using PageForMe.Services;
using PageForMe.Data;
using System.Threading.Tasks;
using System.Linq;

namespace PageForMe.Tests
{
    public class DataGeneratorServiceTests
    {
        private ApplicationDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb_" + Guid.NewGuid()) // Unique DB per test
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public async Task GenerateEmployeesAsync_Adds_ExpectedNumberOfEmployees()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new DataGeneratorService(context);

            int expectedCount = 50;

            // Act
            await service.GenerateEmployeesAsync(expectedCount);

            // Assert
            var actualCount = await context.Employees.CountAsync();
            Assert.Equal(expectedCount, actualCount);
        }
    }
}