using FastwayCourier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing {
    
    public class UnitTest1 {
        

        public void TestPrice(double inWeight, string zone, Nullable<double> expectedPrice) {
            //Arrange
            ParcelQuoteFromNelson quote = new ParcelQuoteFromNelson();
            decimal weight = Convert.ToDecimal(inWeight);
            
            //If Negative Test
            if (expectedPrice == null) { 

                //Act
                Action action = () => {
                    quote.CalculateQuote(weight, zone);
                };
                
                //Assert
                Assert.ThrowsException<ArgumentOutOfRangeException>(action);
                return;
            }


            //Act
            ParcelQuoteResult result = quote.CalculateQuote(weight, zone);

            //Assert
            //..Assert.Equals(...);
        }

    }
}
