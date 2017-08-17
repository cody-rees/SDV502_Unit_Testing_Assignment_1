using FastwayCourier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestAssignment1 {

    [TestClass]
    public class GetDestinationZone_Should {


        /*
         *   Get Destination Zone Checking, "ParcelQuoteFromNelson.GetDestinationZone"
         *
        */

        //Test - PINK
        [DataTestMethod]

        [DataRow("motueka")]
        [DataRow("Mapua")]
        [DataRow("aTawhai")]
        [DataRow("Nelson")]
        [DataRow("maitai")]
        [DataRow("hope")]
        [DataRow("Brightwater")]
        [DataRow("wakefield")]
        [DataRow("picton")]
        [DataRow("Renwick")]
        [DataRow("blenHeim")]

        public void ReturnPinkZoneColor_ForSpecifiedTownOrCity(string town) {
            MatchExpected_ForSpecifiedTownOrCity(town, "pink");
        }
    



        //Test - BLUE
        [DataTestMethod]

        [DataRow("Takaka")]
        [DataRow("riwaka")]
        [DataRow("hAvelock")]
        [DataRow("seddon")]
        [DataRow("Ward")]
        [DataRow("Waihapai Valley")]

        public void ReturnBlueZoneColor_ForSpecifiedTownOrCity(string town) {
            MatchExpected_ForSpecifiedTownOrCity(town, "blue");
        }



        //Test - LIME
        [DataTestMethod]

        [DataRow("Murchison")]
        [DataRow("nelson lakes National park")]

        public void ReturnLimeZoneColor_ForSpecifiedTownOrCity(string town) {
            MatchExpected_ForSpecifiedTownOrCity(town, "lime");
        }




        //Test - ORANGE
        [DataTestMethod]

        [DataRow("Reefton")]
        [DataRow("hanmer Springs")]
        [DataRow("kaikoura")]

        public void ReturnOrangeZoneColor_ForSpecifiedTownOrCity(string town) {
            MatchExpected_ForSpecifiedTownOrCity(town, "orange");
        }



        //Test - Invalid Cities
        [DataTestMethod]

        [DataRow("smallville")]
        [DataRow("auckland")]

        public void ThrowKeyNotFoundException_ForInvalidTownOrCity(string town) {
            MatchExpected_ForSpecifiedTownOrCity(town, typeof(KeyNotFoundException));
        }

        public void MatchExpected_ForSpecifiedTownOrCity(string town, object expected) {
            //Arrange
            Type expectedException = expected is Type ? (Type) expected : null;
            string expectedZone = expected is string ? (string) expected : null;

            ParcelQuoteFromNelson quote = new ParcelQuoteFromNelson();

            Exception exceptionThrown = null;
            string zone = null;

            //Act
            try {
                zone = quote.GetDestinationZone(town);
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

            Assert.AreEqual(expectedZone, zone.ToLower());
        }



    }
}
