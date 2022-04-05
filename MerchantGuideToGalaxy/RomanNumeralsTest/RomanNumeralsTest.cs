using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumerals;

namespace RomanNumeralsTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRomanNumberals_GetValue()
        {
            int expectedResult = 1666;
            string romanNumberString = "MDCLXVI";
            var romanNumbers = new RomanNumbers(romanNumberString);
            var result = romanNumbers.GetValue();


            Assert.AreEqual<int>(result, expectedResult);
            // 
        }

        [TestMethod]
        public void TestRomanNumberals_GetValue1()
        {
            int expectedResult = 1944;
            string romanNumberString = "MCMXLIV";
            var romanNumbers = new RomanNumbers(romanNumberString);
            var result = romanNumbers.GetValue();


            Assert.AreEqual<int>(result, expectedResult);
            // 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                           "Invalid symbol (M), the symbols should be placed in order, except of substracter.")]
        public void TestRomandNumbers_GetValue_Failed()
        {

                string romanNumberString = "IM";
                var romanNumbers = new RomanNumbers(romanNumberString);
                var result = romanNumbers.GetValue();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                           "Invalid substracter symbol(C)")]
        public void TestRomandNumbers_GetValue_InvalidSymbolOrder1_Failed()
        {

            string romanNumberString = "MCMCMXLIV";
            var romanNumbers = new RomanNumbers(romanNumberString);
            var result = romanNumbers.GetValue();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                           "Invalid symbol (M), the symbols should be placed in order, except of substracter."
                   )]
        public void TestRomandNumbers_GetValue_InvalidSymbolOrder2_Failed()
        {

            string romanNumberString = "MXLCMIV";
            var romanNumbers = new RomanNumbers(romanNumberString);
            var result = romanNumbers.GetValue();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                           "Invalid substracter symbol(C)"
                   )]
        public void TestRomandNumbers_GetValue_InvalidSymbolOrder3_Failed()
        {

            string romanNumberString = "MCMCM";
            var romanNumbers = new RomanNumbers(romanNumberString);
            var result = romanNumbers.GetValue();

        }
    }
}
