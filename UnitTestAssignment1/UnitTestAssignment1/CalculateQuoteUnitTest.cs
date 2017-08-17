using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FastwayCourier;

namespace UnitTestAssignment1 {

    [TestClass]
    public class CalculatingQuote_Should {

        
        /*
         *   Zone Price Checking, "ParcelQuoteFromNelson.CalculateQuote"
         *
        */

        [DataTestMethod]

        //Boundry Test - PINK
        [DataRow(0.0, typeof(ArgumentOutOfRangeException))]
        [DataRow(0.1, 0)]
        [DataRow(25.0, 0)]
        [DataRow(25.1, typeof(ArgumentOutOfRangeException))]

        //Partition Test - PINK
        [DataRow(-4.9, typeof(ArgumentOutOfRangeException))]
        [DataRow(8.3, 0)]
        [DataRow(27.9, typeof(ArgumentOutOfRangeException))]

        public void ReturnNumberOfTicketsForPinkZoneDelivery_WhenInWeightRange(double inWeight, object expected) {
            MatchExpectedNumberOfTicketsForZoneDelivery_WhenInWeightRange(inWeight, "pink", expected);
        }




        [DataTestMethod]

        //Boundry Test - BLUE 
        [DataRow(0.0, typeof(ArgumentOutOfRangeException))]
        [DataRow(0.1, 0)]
        [DataRow(25.0, 0)]
        [DataRow(25.1, typeof(ArgumentOutOfRangeException))]

        //Partition Test - BLUE
        [DataRow(-4.9, typeof(ArgumentOutOfRangeException))]
        [DataRow(8.3, 0)]
        [DataRow(27.9, typeof(ArgumentOutOfRangeException))]

        public void ReturnNumberOfTicketsForBlueZoneDelivery_WhenInWeightRange(double inWeight, object expected) {
            MatchExpectedNumberOfTicketsForZoneDelivery_WhenInWeightRange(inWeight, "blue", expected);
        }




        [DataTestMethod]

        //Boundry Test - LIME (Using up to 15 as inclusive)
        [DataRow(0.0, typeof(ArgumentOutOfRangeException))]
        [DataRow(0.1, 0)]
        [DataRow(15.0, 0)]

        [DataRow(15.1, 1)]
        [DataRow(25.0, 1)]
        [DataRow(25.1, typeof(ArgumentOutOfRangeException))]

        //Partition Test - LIME
        [DataRow(-4.9, typeof(ArgumentOutOfRangeException))]
        [DataRow(16.3, 1)]
        [DataRow(27.9, typeof(ArgumentOutOfRangeException))]

        public void ReturnNumberOfTicketsForLimeZoneDelivery_WhenInWeightRange(double inWeight, object expected) {
            MatchExpectedNumberOfTicketsForZoneDelivery_WhenInWeightRange(inWeight, "lime", expected);
        }




        [DataTestMethod]

        //Boundry Test - ORANGE (Using up to 15 as inclusive)
        [DataRow(0.0, typeof(ArgumentOutOfRangeException))]
        [DataRow(0.1, 0)]
        [DataRow(15.0, 0)]

        [DataRow(15.1, 1)]
        [DataRow(20.0, 1)]

        [DataRow(20.1, 2)]
        [DataRow(25.0, 2)]
        [DataRow(25.1, typeof(ArgumentOutOfRangeException))]

        //Partition Test - ORANGE
        [DataRow(-4.9, typeof(ArgumentOutOfRangeException))]
        [DataRow(16.5, 1)]
        [DataRow(27.9, typeof(ArgumentOutOfRangeException))]

        public void ReturnNumberOfTicketsForOrangeZoneDelivery_WhenInWeightRange(double inWeight, object expected) {
            MatchExpectedNumberOfTicketsForZoneDelivery_WhenInWeightRange(inWeight, "orange", expected);
        }
        
        public void MatchExpectedNumberOfTicketsForZoneDelivery_WhenInWeightRange(double inWeight, string region, object expected) {
            //Arrange
            Type expectedException = expected is Type ? (Type) expected : null;
            int expectedTickets = expected is int ? Convert.ToInt32(expected) : -1;

            ParcelQuoteFromNelson quote = new ParcelQuoteFromNelson();
            decimal weight = Convert.ToDecimal(inWeight);

            Exception exceptionThrown = null;
            ParcelQuoteResult result = null;

            //Act
            try {
                result = quote.CalculateQuote(weight, region);
            } catch (Exception e) {
                exceptionThrown = e;
            }


            //Assert
            // Negative Test
            if (exceptionThrown != null) {
                if (expectedException != null && expectedException != exceptionThrown.GetType())
                    throw exceptionThrown;

                return;
            }

            // Positive Test
            if (expectedException != null) {
                Assert.Fail("Test Expected Exception: " + expectedException);
                return;
            }

            Assert.AreEqual(expectedTickets, result.ExcessTickets);
        }






        /*
         *   Zone Price Checking, "ParcelQuoteFromNelson.CalculateQuote"
         *
        */


        [DataTestMethod]

        //Boundry Test - PINK (Using up to 25 as inclusive)
        [DataRow(0.0, typeof(ArgumentOutOfRangeException))]
        [DataRow(0.1, 4.15d)]
        [DataRow(25.0, 4.15d)]
        [DataRow(25.1, typeof(ArgumentOutOfRangeException))]

        //Partition Test - PINK
        [DataRow(-4.9, typeof(ArgumentOutOfRangeException))]
        [DataRow(8.3, 4.15d)]
        [DataRow(27.9, typeof(ArgumentOutOfRangeException))]
        
        public void ReturnPriceForPinkZoneDelivery_WhenInWeightRange(double inWeight, object expected) {
            MatchExpectedPriceForZoneDelivery_WhenInWeightRange(inWeight, "pink", expected);
        }




        [DataTestMethod]

        //Boundry Test - BLUE (Using up to 25 as inclusive)
        [DataRow(0.0, typeof(ArgumentOutOfRangeException))]
        [DataRow(0.1, 6.95d)]
        [DataRow(25.0, 6.95d)]
        [DataRow(25.1, typeof(ArgumentOutOfRangeException))]

        //Partition Test - BLUE
        [DataRow(-4.9, typeof(ArgumentOutOfRangeException))]
        [DataRow(8.3, 6.95d)]
        [DataRow(27.9, typeof(ArgumentOutOfRangeException))]
        
        public void ReturnPriceForBlueZoneDelivery_WhenInWeightRange(double inWeight, object expected) {
            MatchExpectedPriceForZoneDelivery_WhenInWeightRange(inWeight, "blue", expected);
        }




        [DataTestMethod]

        //Boundry Test - LIME (Using up to 15 as inclusive)
        [DataRow(0.0, typeof(ArgumentOutOfRangeException))]
        [DataRow(0.1, 8.7d)]
        [DataRow(15.0, 8.7d)]

        [DataRow(15.1, 14.9d)]
        [DataRow(25.0, 14.9d)]
        [DataRow(25.1, typeof(ArgumentOutOfRangeException))]

        //Partition Test - LIME
        [DataRow(-4.9, typeof(ArgumentOutOfRangeException))]
        [DataRow(16.3, 14.9d)]
        [DataRow(27.9, typeof(ArgumentOutOfRangeException))]

        public void ReturnPriceForLimeZoneDelivery_WhenInWeightRange(double inWeight, object expected) {
            MatchExpectedPriceForZoneDelivery_WhenInWeightRange(inWeight, "lime", expected);
        }




        [DataTestMethod]

        //Boundry Test - ORANGE (Using up to 15 as inclusive)
        [DataRow(0.0, typeof(ArgumentOutOfRangeException))]
        [DataRow(0.1, 12.95d)]
        [DataRow(15.0, 12.95d)]

        [DataRow(15.1, 19.15d)]
        [DataRow(20.0, 19.15d)]

        [DataRow(20.1, 25.35d)]
        [DataRow(25.0, 25.35d)]
        [DataRow(25.1, typeof(ArgumentOutOfRangeException))]

        //Partition Test - ORANGE
        [DataRow(-4.9, typeof(ArgumentOutOfRangeException))]
        [DataRow(16.5, 19.15d)]
        [DataRow(27.9, typeof(ArgumentOutOfRangeException))]

        public void ReturnPriceForOrangeZoneDelivery_WhenInWeightRange(double inWeight, object expected) {
            MatchExpectedPriceForZoneDelivery_WhenInWeightRange(inWeight, "orange", expected);
        }
        
        public void MatchExpectedPriceForZoneDelivery_WhenInWeightRange(double inWeight, string region, object expected) {
            //Arrange
            Type expectedException = expected is Type ? (Type) expected : null;
            decimal expectedPrice = expected is double ? Convert.ToDecimal(expected) : -1.0m;
            
            ParcelQuoteFromNelson quote = new ParcelQuoteFromNelson();
            decimal weight = Convert.ToDecimal(inWeight);

            Exception exceptionThrown = null;
            ParcelQuoteResult result = null;
            
            //Act
            try {
                result = quote.CalculateQuote(weight, region);
            } catch (Exception e) {
                exceptionThrown = e;
            }


            //Assert
            // Negative Test
            if (exceptionThrown != null) {
                if (expectedException != null && expectedException != exceptionThrown.GetType())
                    throw exceptionThrown;

                return;
            }

            // Positive Test
            if (expectedException != null) {
                Assert.Fail("Test Expected Exception: " + expectedException);
                return;
            }

            Assert.AreEqual(expectedPrice, result.Price);
        }
        

    }

}
