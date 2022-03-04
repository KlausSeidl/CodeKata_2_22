using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace RestaurantServiceTests
{
    [TestFixture]
    class RestaurantServiceTests
    {
        [Test]
        public void AddTable_Verify()
        {
            // Arrange
            var testClass = new RestaurantService.RestaurantService();
            int tableNumber = 1;
            int numberOfSeats = 4;

            // Precondition
            testClass.GetAllTables().Should().BeEmpty();

            // Act
            testClass.AddTable(tableNumber, numberOfSeats);

            // Assert
            var tables = testClass.GetAllTables();
            tables.Should().HaveCount(1);
            var table = tables.First();
            table.TableNumber.Should().Be(tableNumber);
            table.NumberOfSeats.Should().Be(numberOfSeats);
        }
    }
}
