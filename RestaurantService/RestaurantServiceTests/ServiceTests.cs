using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using RestaurantService;

namespace RestaurantServiceTests
{
    [TestFixture]
    public class ServiceTests
    {
        private Mock<IDatabase> _dataBaseMock;
        private Mock<IEmailService> _emailServiceMock;
        private ReservationService _reservationService;
        private List<Reservation> _currentReservations = new List<Reservation>();

        private DateTime TenOClock = new DateTime(2022, 03, 04, 10, 0, 0);
        private DateTime TwelveOClock = new DateTime(2022, 03, 04, 12, 0, 0);
        private DateTime FourteenOClock = new DateTime(2022, 03, 04, 14, 0, 0);

        [SetUp]
        public void Setup()
        {
            _dataBaseMock = new Mock<IDatabase>();
            _emailServiceMock = new Mock<IEmailService>();

            _dataBaseMock.Setup(db => db.GetAllReservations())
                        .Returns(_currentReservations);
            _dataBaseMock.Setup(db => db.SaveReservation(It.IsAny<Reservation>()))
                         .Callback((Reservation r) => _currentReservations.Add(r));

            _reservationService = new ReservationService(_dataBaseMock.Object, _emailServiceMock.Object);

            _reservationService.TableCount = 3;
        }

        // Der Service muss dem Anwender das Reservieren eines Tisches erlauben.
        // Der Service muss dem Anwender das Reservieren eines Tisches zu einer bestimmten Uhrzeit erlauben
        // Der Service muss dem Anwender das Reservieren eines Tisches mit einer bestimmten Zeitdauer erlauben.
        // Der Service muss dem Anwender das Reservieren eines Tisches für eine Anzahl x von Personen erlauben.
        
        [Test]
        public void ReserveTable()
        {
             
            //Arrange
            var reservationTime = DateTime.Now;
            var countOfPerson = 4;
            var timeSpan = TimeSpan.FromHours(2);

            //Act
            var result = _reservationService.ReserveTable(reservationTime, countOfPerson, timeSpan);

            //Assert
            Assert.IsTrue(result);
        }


        // Der Service muss die Fähigkeit besitzen, den Reservierungsplan nach freien Tischen zu durchsuchen.
        // Der Service muss die Verfügbarkeit eines freien Tisches prüfen können.

        [Test]
        public void ReserveTable_ReserveFails_WithoutFreeTable()
        {
            //Arrange
            var reservationTime = TenOClock;
            var countOfPerson = 4;
            var timeSpan = TimeSpan.FromHours(2);

            _currentReservations.AddRange(new[]
            {
                new Reservation(countOfPerson, TenOClock, TwelveOClock),
                new Reservation(countOfPerson, TenOClock, TwelveOClock),
                new Reservation(countOfPerson, TenOClock, TwelveOClock),
            });

            //Act
            var result = _reservationService.ReserveTable(reservationTime, countOfPerson, timeSpan);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ReserveTable_ReserveSucceeds_WithFreeTableAfterOtherReservations()
        {
            //Arrange
            _reservationService.TableCount = 3;

            var reservationTime = TenOClock;
            var countOfPerson = 4;
            var timeSpan = TimeSpan.FromHours(2);

            _currentReservations.AddRange(new[]
            {
                new Reservation(countOfPerson, TenOClock, TwelveOClock),
                new Reservation(countOfPerson, TenOClock, TwelveOClock),
                new Reservation(countOfPerson, TenOClock, TwelveOClock),
            });

            //Act
            var result = _reservationService.ReserveTable(reservationTime + timeSpan, countOfPerson, timeSpan);

            //Assert
            Assert.IsTrue(result);
        }

        // Der Service muss bei der Verfügbarkeit des freien Tisches die Anzahl der Personen berücksichtigen
        // Der Service muss bei der Verfügbarkeit des freien Tisches die Uhrzeit berücksichtigen
        // Der Service muss bei der Verfügbarkeit des freien Tisches die Zeitspanne berücksichtigen 
        // Der Service muss dem Anwender eine Antwort über den Erfolg der Reservierung liefern.
        // Der Service muss dem Anwender eine Antwort über den Misserfolg der Reservierung liefern.

        // Der Service muss erfolgreiche Reservierungen in einer Datenbank speichern.
        // Der Service muss dem Anwender eine Mail für erfolgreiche Reservierungen senden.
        // Der Service muss dem Anwender eine Antwort über Erfolg der Reservierung geben.
        // Der Service muss dem Anwender eine Antwort über Misserfolg der Reservierung geben.
        // Bei Misserfolg sollte der Service dem Anwender einen Hinweis über das Reservierungsproblem liefern.
        // Bei Misserfolg sollte der Service dem Anwender einen Alternativvorschlag zu seinem Reservierungswunsch anbieten.
    }

    
}