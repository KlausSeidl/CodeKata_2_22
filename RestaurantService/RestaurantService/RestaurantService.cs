using System.Collections.Generic;

namespace RestaurantService
{
    public class RestaurantService
    {
        private readonly IList<Table> _tables;

        public RestaurantService()
        {
            _tables = new List<Table>();
        }

        public void AddTable(int tableNumber, int numberOfSeats)
        {
            var table = new Table(tableNumber, numberOfSeats);
            _tables.Add(table);
        }

        public IList<Table> GetAllTables()
        {
            return _tables;
        }
    }

    public class Table
    {
        public int TableNumber { get; set; }
        public int NumberOfSeats { get; set; }

        public Table(int tableNumber, int numberOfSeats)
        {
            TableNumber = tableNumber;
            NumberOfSeats = numberOfSeats;
        }
    }
}