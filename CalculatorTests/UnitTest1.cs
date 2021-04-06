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
        /**
         * @brief Testing subtracting two integers
         */
        [TestMethod]
        public void BasicTest()
        {
            
        }
    }

    /**
     * Testing cases for Multiply
     */
    [TestClass]
    public class Multiply
    {
        /**
         * @brief Testing multiplying two integers
         */
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(6 , Calculator.Mupltiply(2,3));
            Assert.AreNotEqual(1, Calculator.Mupltiply(1,0));
            Assert.AreEqual(-5, Calculator.Mupltiply(-1,5));
            Assert.AreEqual(1, Calculator.Mupltiply(-1,-1));
        }

        /**
         * @brief Testing multiplying two double numbers
         */
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(6.9, Calculator.Mupltiply(2.3, 3));
            Assert.AreNotEqual(1, Calculator.Mupltiply(1.6, 0));
            Assert.AreEqual(-6.84, Calculator.Mupltiply(-1.2, 5.7));
            Assert.AreEqual(1, Calculator.Mupltiply(-1.0, -1.0));
        }
    }

    /**
     * Testing cases for Divide
     */
    [TestClass]
    public class Divide
    {
        /**
         * @brief Testing dividing two integers
         */
        [TestMethod]
        public void BasicTest()
        {

        }
    }

    /**
     * Testing cases for Power
     */
    [TestClass]
    public class Power
    {
        /**
         * @brief Testing power of integer
         */
        [TestMethod]
        public void BasicTest()
        {

        }
    }

    /**
     * Testing cases for Root
     */
    [TestClass]
    public class Root
    {
        /**
         * @brief Testing Root of integer
         */
        [TestMethod]
        public void BasicTest()
        {

        }
    }

    /**
     * Testing cases for Factorial
     */
    [TestClass]
    public class Factorial
    {
        /**
         * @brief Testing factorial
         */
        [TestMethod]
        public void BasicTest()
        {

        }
    }
}
