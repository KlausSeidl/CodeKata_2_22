using System;

namespace RestaurantService
{
    public class Reservation
    {
        public int PersonCount { get; set; }

        public DateTime ReservedFrom { get; set; }

        public DateTime ReservedTo { get; set; }

        public Reservation(int personCount, DateTime reservedFrom, DateTime reservedTo)
        {
            this.PersonCount = personCount;
            this.ReservedFrom = reservedFrom;
            this.ReservedTo = reservedTo;
        }
    }
}