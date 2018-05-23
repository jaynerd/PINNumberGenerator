using System;
using PINNumberGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PINNumberGeneratorTest
{
    [TestClass]
    public class PINGeneratorUnitTest
    {
        [TestMethod]
        public void TestPINGenerationQuantity()
        {
            // Checking total number of PINs will be created per batch.
            var numberPool = new NumberPool(0, 9999);
            var rawNumbers = numberPool.GetRawNumberPool();
            var sortedNumbers = numberPool.GetSortedNumberPool(rawNumbers);
            var pinGenerator = new PINGenerator(sortedNumbers);
            var pinBatch = pinGenerator.GetNewBatch();
            int expectedSize = 1000;
            int actualSize = pinBatch.Count;
            Assert.AreEqual(expectedSize, actualSize);
        }
    }
}
