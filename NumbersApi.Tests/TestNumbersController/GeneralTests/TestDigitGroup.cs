using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersApi.Models;

namespace NumbersApi.Tests.TestNumbersController.GeneralTests
{
    [TestClass]
    public class TestDigitGroup
    {
        [TestMethod]
        public void intvalue_is_the_intparsed_version_of_unprocessedvalue()
        {
            //Arrange
            DigitGroup dg = new DigitGroup()
            {
                UnprocessedValue = "02321039"               
            };
            //Act
            int intParsedUnprocessedValue = Int32.Parse(dg.UnprocessedValue);

            //Assert
            Assert.IsTrue(dg.IntValue == intParsedUnprocessedValue);
        }
    }
}
