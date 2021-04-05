using Microsoft.VisualStudio.TestTools.UnitTesting;

using turbocalc;

namespace CalculatorTests
{
    /**
     * Testing cases for Add
     */
    [TestClass]
    public class Add
    {
        /**
         * @brief Testing adding two integers
         */
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(3, Calculator.Add(1,2));
            Assert.AreNotEqual(0, Calculator.Add(1,2));
            Assert.AreEqual(-5, Calculator.Add(1,-6));
            Assert.AreEqual(-3, Calculator.Add(-1,-2));
        }

        /**
         * @brief Testing adding two double numbers
         */
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(3.5, Calculator.Add(1.2, 2.3));
            Assert.AreNotEqual(0, Calculator.Add(1.7, 2.8));
            Assert.AreEqual(-5, Calculator.Add(1.4, -6.4));
            Assert.AreEqual(-3, Calculator.Add(-1.2, -1.8));
        }

    }

    /**
     * Testing cases for Subtract
     */
    [TestClass]
    public class Subtract
    {
        [TestMethod]
        public void BasicTest()
        {
            
        }
    }

    [TestClass]
    public class Multiply
    {
        [TestMethod]
        public void BasicTest()
        {

        }
    }

    [TestClass]
    public class Divide
    {
        [TestMethod]
        public void BasicTest()
        {

        }
    }

    [TestClass]
    public class Power
    {
        [TestMethod]
        public void BasicTest()
        {

        }
    }

    [TestClass]
    public class Root
    {
        [TestMethod]
        public void BasicTest()
        {

        }
    }

    [TestClass]
    public class Factorial
    {
        [TestMethod]
        public void BasicTest()
        {

        }
    }
}
