using System.Collections.Generic;

namespace RestaurantService
{
    public interface IDatabase
    {
        void SaveReservation(Reservation reservation);

        List<Reservation> GetAllReservations();


    }
}

