using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantService
{
    public class ReservationService
    {
        private readonly IDatabase _dataBase;
        private readonly IEmailService _emailService;

        public int TableCount { get; set; }

        public ReservationService(IDatabase dataBase, IEmailService emailService)
        {
            _dataBase = dataBase;
            _emailService = emailService;
        }

        public bool ReserveTable(DateTime reservationFrom, int countOfPerson, TimeSpan timeSpan)
        {
            var currentReservations = _dataBase.GetAllReservations().ToList();

            if (TableCount <= 0)
            {
                return false;
            }

            var reservationTo = reservationFrom + timeSpan;

            return currentReservations.Count(x => reservationFrom < x.ReservedTo && x.ReservedFrom < reservationTo) < TableCount;
        }
    }
}