using System;
using PINNumberGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PINNumberGeneratorTest
{
    [TestClass]
    public class NumberPoolUnitTest
    {
        [TestMethod]
        public void TestRawNumberGenerationQuantity()
        {
            // Checking the size of the whole number list from the
            // range of min to max.
            var numberPool = new NumberPool(0, 9999);
            var rawNumbers = numberPool.GetRawNumberPool();
            int expectedSize = 10000;
            int actualSize = rawNumbers.Count;
            Assert.AreEqual(expectedSize, actualSize);
        }

        [TestMethod]
        public void TestSortedNumberGenerationQuantity()
        {
            // Checking the size of sorted list which consists of
            // numbers following given conditions strictly.
            var numberPool = new NumberPool(0, 9999);
            var rawNumbers = numberPool.GetRawNumberPool();
            var sortedNumbers = numberPool.GetSortedNumberPool(rawNumbers);
            int expectedSize = 7153;
            int actualSize = sortedNumbers.Count;
            Assert.AreEqual(expectedSize, actualSize);
        }
    }
}
