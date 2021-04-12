using Microsoft.VisualStudio.TestTools.UnitTesting;

using turbocalc;

namespace CalculatorTests
{
    /// <summary>
    /// Testing cases for Add
    /// </summary>
    [TestClass]
    public class Add
    {
       /// <summary>
       /// Testing adding two integers
       /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(3, Calculator.Add(1,2));
            Assert.AreNotEqual(0, Calculator.Add(1,2));
            Assert.AreEqual(-5, Calculator.Add(1,-6));
            Assert.AreEqual(-3, Calculator.Add(-1,-2));
        }

        /// <summary>
        /// Testing adding two doubles
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(3.5, Calculator.Add(1.2, 2.3));
            Assert.AreNotEqual(0, Calculator.Add(1.7, 2.8));
            Assert.AreEqual(-5, Calculator.Add(1.4, -6.4));
            Assert.AreEqual(-3, Calculator.Add(-1.2, -1.8));
        }

    }

    /// <summary>
    /// Testing cases for subtract
    /// </summary>
    [TestClass]
    public class Subtract
    {
        /// <summary>
        /// Testing subtracting two integers
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(3, Calculator.Subtract(5,2));
            Assert.AreNotEqual(0, Calculator.Subtract(1,2));
            Assert.AreEqual(13, Calculator.Subtract(5,-8));
            Assert.AreEqual(1, Calculator.Subtract(-1,-2));
            Assert.AreEqual(-13, Calculator.Subtract(-5,8));
            Assert.AreNotEqual(0, Calculator.Subtract(-1,-2));
        }

        /// <summary>
        /// Testing subtracting two doubles
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(2.9, Calculator.Subtract(5.2,2.3));
            Assert.AreNotEqual(0, Calculator.Subtract(1.1,2.1));
            Assert.AreEqual(13.5, Calculator.Subtract(5.5,-8));
            Assert.AreEqual(1, Calculator.Subtract(-1.9,-2.9));
            Assert.AreEqual(-11.1, Calculator.Subtract(-6.9,4.2));
            Assert.AreNotEqual(0, Calculator.Subtract(-1.8,-2.01));
        }
    }

    /// <summary>
    /// Testing cases for Multiply
    /// </summary>
    [TestClass]
    public class Multiply
    {
        /// <summary>
        /// Testing multiplying two integers
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(6 , Calculator.Mupltiply(2,3));
            Assert.AreNotEqual(1, Calculator.Mupltiply(1,0));
            Assert.AreEqual(-5, Calculator.Mupltiply(-1,5));
            Assert.AreEqual(1, Calculator.Mupltiply(-1,-1));
        }

        /// <summary>
        /// Testing multiplying two doubles
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(6.9, Calculator.Mupltiply(2.3, 3));
            Assert.AreNotEqual(1, Calculator.Mupltiply(1.6, 0));
            Assert.AreEqual(-6.84, Calculator.Mupltiply(-1.2, 5.7));
            Assert.AreEqual(1, Calculator.Mupltiply(-1.0, -1.0));
        }
    }

    /// <summary>
    /// Testing cases for Divide
    /// </summary>
    [TestClass]
    public class Divide
    {
        /// <summary>
        /// Testing dividing two integers
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(2, Calculator.Divide(6,3));
            Assert.AreNotEqual(10, Calculator.Divide(5, 2));
            Assert.AreEqual(-5, Calculator.Divide(-5,1));
            Assert.AreEqual(1, Calculator.Divide(-1, -1));
        }

        /// <summary>
        /// Testing dividing two doubles
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(2.3, Calculator.Divide(6.9, 3));
            Assert.AreNotEqual(1, Calculator.Divide(1.6, 2.3));
            Assert.AreEqual(-4.75, Calculator.Divide(-5.7, 1.2));
            Assert.AreEqual(1, Calculator.Divide(-1.0, -1.0));
            //Assert.ThrowsException<ArgumentException>(Calculator.Divide(1.0,0.0));
        }
    }

    /// <summary>
    /// Testing cases for Power
    /// </summary>
    [TestClass]
    public class Power
    {
        /// <summary>
        /// Testing power of integer
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(4, Calculator.Power(2,2));
            Assert.AreEqual(4, Calculator.Power(-2, 2));
            Assert.AreEqual(1, Calculator.Power(7, 0));
            Assert.AreEqual(1, Calculator.Power(-7, 0));
            Assert.AreEqual(0.25, Calculator.Power(2, -2));
        }

        /// <summary>
        /// Testing power of double
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(1.21, Calculator.Power(1.1,2));
            Assert.AreEqual(1, Calculator.Power(5.6, 0));
        }
    }

    /// <summary>
    /// Testing cases for Root
    /// </summary>
    [TestClass]
    public class Root
    {
        /// <summary>
        /// Testing root of integer
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(2, Calculator.Root(4,2));
            Assert.AreEqual(2, Calculator.Root(8,3));
            Assert.AreEqual(0, Calculator.Root(0,2));
            //Assert.ThrowsException <ArgumentException> (Calculator.Root(-1,2));
            //Assert.ThrowsException<ArgumentException>(Calculator.Root(2,0));
            Assert.AreEqual(0.5,Calculator.Root(4,-2));
            Assert.AreEqual(-1,Calculator.Root(-1,3));  
        }

        /// <summary>
        /// Testing root of double
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        { 
            Assert.AreEqual(0.25, Calculator.Root(0.0625, 2));
        }
    }

    /// <summary>
    /// Testing cases for Factorial
    /// </summary>
    [TestClass]
    public class Factorial
    {
        /// <summary>
        /// Testing factorial of integer
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(6, Calculator.Factorial(3));
            Assert.AreEqual(120, Calculator.Factorial(5));
            Assert.AreEqual(1, Calculator.Factorial(1));
            
        }

        /// <summary>
        /// Testing factorial of zero
        /// </summary>
        [TestMethod]
        public void ZeroTest()
        {
            Assert.AreEqual(1, Calculator.Factorial(0));
        }

        /// <summary>
        /// Testing factorial of negative number
        /// </summary>
        [TestMethod]
        public void NegativeTest()
        {
            Assert.AreEqual(-1,Calculator.Factorial(-5));
        }
    }
}
