﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [TestMethod()]
        public void GivenDistanceAndTime_CalculateFareMethodShould_ReturnTotalFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 20;
            int time = 45;

            // Calculating fare by passing the values of distance = 20km and time = 45 minutes
            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 245;

            // Checking if the test case passes
            Assert.AreEqual(expectedFare, actualFare);
        }


        [TestMethod()]
        public void GivenDistanceAndTime_CalculateFareMethodShould_ReturnMinimumFare()
        {
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator();
            double distance = 0.2;
            int time = 2;

            // Calculating fare by passing the values of distance = 0.2km (200 m) and time = 2 minutes
            double actualFare = invoiceGenerator.CalculateFare(distance, time);
            double expectedFare = 5;

            // Checking if the test case passes
            Assert.AreEqual(expectedFare, actualFare);
        }

    }
}