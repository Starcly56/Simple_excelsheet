using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDOOCP_Assignment;

namespace DDOOCP_AssignmentTests
{
    [TestClass]
    public class FormulaTest
    {
        [TestMethod]
        //testing sum
        public void SumTest()
        {
            try
            {
                Formula f = new Formula();
                List<double> arr = new List<double>() { 4, 5, 6 };
                double result = f.Sum(arr);
                Assert.AreEqual(15, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [TestMethod]
        //testing mean
        public void MeanTest()
        {
            try
            {
                Formula f = new Formula();
                List<double> arr = new List<double>() { 40, 55, 61 };
                double result = f.Mean(arr);
                Assert.AreEqual(52, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [TestMethod]
        //testing median
        public void MedianTest()
        {
            try
            {
                Formula f = new Formula();
                List<double> arr = new List<double>() { 9, 10, 12, 11, 15, 14 };
                double result = f.Median(arr);
                Assert.AreEqual(11.5, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [TestMethod]
        //testing mode
        public void ModeTest()
        {
            try
            {
                Formula f = new Formula();
                List<double> arr = new List<double>() { 40, 55, 61, 40 };
                double result = f.Mode(arr);
                Assert.AreEqual(40, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [TestMethod]
        //testing multiplication
        public void MultiplyTest()
        {
            try
            {
                Formula f = new Formula();
                List<double> arr = new List<double>() { 10, 12 };
                double result = f.Multiply(arr);
                Assert.AreEqual(120, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [TestMethod]
        //testing average
        public void AverageTest()
        {
            try
            {
                Formula f = new Formula();
                List<double> arr = new List<double>() { 40, 55, 61 };
                double result = f.Mean(arr);
                Assert.AreEqual(52, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
