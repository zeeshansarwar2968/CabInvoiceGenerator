using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator.Tests
{
    [TestClass()]
    public class InvoiceGeneratorTests
    {
        //Test
        [TestMethod()]
        public void GivenDistanceAndTime_CalculateFareMethodShould_ReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 20;  //20x10 =200
            int time = 45; //45x1=45

            // Calculating fare by passing the values of distance = 20km and time = 45 minutes
            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 245;

            // Checking if the test case passes
            Assert.AreEqual(expectedFare, actualFare);
        }


        [TestMethod()]
        public void GivenDistanceAndTime_CalculateFareMethodShould_ReturnMinimumFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 0.2; //0.2x10=2
            int time = 2; //2x1=2

            // Calculating fare by passing the values of distance = 0.2km (200 m) and time = 2 minutes
            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 5;

            // Checking if the test case passes
            Assert.AreEqual(expectedFare, actualFare);
        }


        //Test case developed for testing the multiple rides implementation
        [TestMethod()]
        public void Given5Rides_CalculateFareMethodShould_ReturnTotalFare()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(3.0, 2),
                new Ride(4.0, 4),
                new Ride(5.0, 3),
                new Ride(6.0, 3)
            };
            double expected = 225;
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            double actual = summary.totalFare;
            Assert.AreEqual(expected, actual);
        }

        //Test case developed for testing the multiple rides implementation
        [TestMethod()]
        public void Given5Rides_InvoiceSummaryShould_ReturnEnhancedInvoiceSummary()
        {
            Ride[] rides =
            {
                new Ride(1.0, 1),
                new Ride(2.0, 2),
                new Ride(3.0, 2),
                new Ride(4.0, 4),
                new Ride(5.0, 3),
                new Ride(6.0, 3)
            };
            InvoiceSummary expected = new InvoiceSummary(6, 225);
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(summary, expected);
        }

        //Test case developed for testing the multiple rides implementation
        //[TestMethod()]
        //public void GivenUserId_InvoiceServiceShould_ReturnListOfRides()
        //{
        //    Ride[] rides =
        //    {
        //        new Ride(1.0, 1),
        //        new Ride(2.0, 2),
        //        new Ride(3.0, 2),
        //        new Ride(4.0, 4),
        //        new Ride(5.0, 3)
        //    };
        //    string userId = "12345";
        //    InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
        //    RideRepository rideRepository = new RideRepository();
        //    rideRepository.AddRide(userId, rides);
        //    Ride[] actual = rideRepository.GetRides(userId);
        //    Assert.AreEqual(rides, actual);
        //}

        [TestMethod()]
        public void GivenInvalidRideType_Should_Return_CabInvoiceException()
        {
            try
            {
                double distance = -5; //in km
                int time = 20;   //in minute
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE);
            }
        }

        [TestMethod()]
        public void GivenInvalidDistance_Should_Return_CabInvoiceException()
        {
            try
            {
                double distance = -5; //in km
                int time = 20;   //in minute
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.INVALID_DISTANCE);
            }
        }

        [TestMethod()]
        public void GivenInvalidTime_Should_Return_CabInvoiceException()
        {
            try
            {
                double distance = 5; //in km
                int time = -20;   //in minutes
                InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.INVALID_TIME);
            }
        }

        [TestMethod()]
        public void GivenInvalidUserId_InvoiceServiceShould_ReturnCabInvoiceException()
        {
            try
            {
                RideRepository rideRepository = new RideRepository();
                Ride[] actual = rideRepository.GetRides("InvalidUserID");
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.INVALID_USER_ID);
            }
        }

        [TestMethod()]
        public void GivenNullRides_InvoiceServiceShould_ReturnCabInvoiceException()
        {
            try
            {
                Ride[] rides =
                {
                    new Ride(5, 20),
                    null,
                    new Ride(2, 10)
                };
                RideRepository rideRepository = new RideRepository();
                rideRepository.AddRide("111", rides);
            }
            catch (CabInvoiceException ex)
            {
                Assert.AreEqual(ex.type, CabInvoiceException.ExceptionType.NULL_RIDES);
            }
        }


    }
}