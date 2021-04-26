///
/// @file UnitTest1.cs
/// <summary>
/// Tests for math class
/// </summary>
///

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Turbocalc;


/// <summary>
/// CalculatorTests namespace
/// </summary>
namespace CalculatorTests
{
    /// <summary>
    /// Testing cases for Add
    /// </summary>
    [TestClass]
    public class Add
    {
        private const double Accuracy = 1e-7;// allowed deviation for double numbers
        /// <summary>
        /// Testing adding two integers
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(3, Calculator.Add(1, 2));
            Assert.AreNotEqual(0, Calculator.Add(1, 2));
            Assert.AreEqual(-5, Calculator.Add(1, -6));
            Assert.AreEqual(-3, Calculator.Add(-1, -2));
        } // BasicTest()

        /// <summary>
        /// Testing adding two doubles
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(3.5, Calculator.Add(1.2, 2.3), Accuracy);
            Assert.AreNotEqual(0, Calculator.Add(1.7, 2.8), Accuracy);
            Assert.AreEqual(-5, Calculator.Add(1.4, -6.4), Accuracy);
            Assert.AreEqual(-3, Calculator.Add(-1.2, -1.8), Accuracy);
        } // DoubleTest()

    } //class Add

    /// <summary>
    /// Testing cases for subtract
    /// </summary>
    [TestClass]
    public class Subtract
    {
        private const double Accuracy = 1e-7;
        /// <summary>
        /// Testing subtracting two integers
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(3, Calculator.Subtract(5, 2));
            Assert.AreNotEqual(0, Calculator.Subtract(1, 2));
            Assert.AreEqual(13, Calculator.Subtract(5, -8));
            Assert.AreEqual(1, Calculator.Subtract(-1, -2));
            Assert.AreEqual(-13, Calculator.Subtract(-5, 8));
            Assert.AreNotEqual(0, Calculator.Subtract(-1, -2));
        } // BasicTest()

        /// <summary>
        /// Testing subtracting two doubles
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(2.9, Calculator.Subtract(5.2, 2.3), Accuracy);
            Assert.AreNotEqual(0, Calculator.Subtract(1.1, 2.1));
            Assert.AreEqual(13.5, Calculator.Subtract(5.5, -8), Accuracy);
            Assert.AreEqual(1, Calculator.Subtract(-1.9, -2.9), Accuracy);
            Assert.AreEqual(-11.1, Calculator.Subtract(-6.9, 4.2), Accuracy);
            Assert.AreNotEqual(0, Calculator.Subtract(-1.8, -2.01), Accuracy);
        } // DoubleTest()
    } //class Subtract

    /// <summary>
    /// Testing cases for Multiply
    /// </summary>
    [TestClass]
    public class Multiply
    {
        private const double Accuracy = 1e-7;
        /// <summary>
        /// Testing multiplying two integers
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(6, Calculator.Multiply(2, 3));
            Assert.AreNotEqual(1, Calculator.Multiply(1, 0));
            Assert.AreEqual(-5, Calculator.Multiply(-1, 5));
            Assert.AreEqual(1, Calculator.Multiply(-1, -1));
        } // BasicTest()

        /// <summary>
        /// Testing multiplying two doubles
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(6.9, Calculator.Multiply(2.3, 3), Accuracy);
            Assert.AreNotEqual(1, Calculator.Multiply(1.6, 0), Accuracy);
            Assert.AreEqual(-6.84, Calculator.Multiply(-1.2, 5.7), Accuracy);
            Assert.AreEqual(1, Calculator.Multiply(-1.0, -1.0), Accuracy);
        } // DoubleTest()
    } //class Multiply

    /// <summary>
    /// Testing cases for Divide
    /// </summary>
    [TestClass]
    public class Divide
    {
        private const double Accuracy = 1e-7;
        /// <summary>
        /// Testing dividing two integers
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(2, Calculator.Divide(6, 3));
            Assert.AreNotEqual(10, Calculator.Divide(5, 2));
            Assert.AreEqual(-5, Calculator.Divide(-5, 1));
            Assert.AreEqual(1, Calculator.Divide(-1, -1));
        } // BasicTest()

        /// <summary>
        /// Testing dividing two doubles
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(2.3, Calculator.Divide(6.9, 3), Accuracy);
            Assert.AreNotEqual(1, Calculator.Divide(1.6, 2.3),Accuracy);
            Assert.AreEqual(-4.75, Calculator.Divide(-5.7, 1.2), Accuracy);
            Assert.AreEqual(1, Calculator.Divide(-1.0, -1.0), Accuracy);
            Assert.ThrowsException<ArgumentException>(() => Calculator.Divide(1.0, 0.0));
        } // DoubleTest()
    } //class Divide

    /// <summary>
    /// Testing cases for Power
    /// </summary>
    [TestClass]
    public class Power
    {
        private const double Accuracy = 1e-7;
        /// <summary>
        /// Testing power of integer
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(4, Calculator.Power(2, 2));
            Assert.AreEqual(4, Calculator.Power(-2, 2));
            Assert.AreEqual(1, Calculator.Power(7, 0));
            Assert.AreEqual(1, Calculator.Power(-7, 0));
            Assert.AreEqual(0.25, Calculator.Power(2, -2), Accuracy);
            Assert.AreEqual(1, Calculator.Power(0, 0));
            Assert.ThrowsException<ArgumentException>(() => Calculator.Power(0, -1));
        } // BasicTest()

        /// <summary>
        /// Testing power of double
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(1.21, Calculator.Power(1.1, 2), Accuracy);
            Assert.AreEqual(1, Calculator.Power(5.6, 0), Accuracy);
        } // DoubleTest()
    } //class Power

    /// <summary>
    /// Testing cases for Root
    /// </summary>
    [TestClass]
    public class Root
    {
        private const double Accuracy = 1e-7;
        /// <summary>
        /// Testing root of integer
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreEqual(2, Calculator.Root(4, 2));
            Assert.AreEqual(2, Calculator.Root(8, 3));
            Assert.AreEqual(0, Calculator.Root(0, 2));
            Assert.ThrowsException<ArgumentException>(() => Calculator.Root(-1, 2));
            Assert.ThrowsException<ArgumentException>(() => Calculator.Root(2, 0));
            Assert.AreEqual(0.5, Calculator.Root(4, -2), Accuracy);
            Assert.AreEqual(-1, Calculator.Root(-1, 3));
            Assert.ThrowsException<ArgumentException>(() => Calculator.Root(0, -1));
        } // BasicTest()

        /// <summary>
        /// Testing root of double
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreEqual(0.25, Calculator.Root(0.0625, 2), Accuracy);
        } // DoubleTest()
    } //class Root

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

        } // BasicTest()

        /// <summary>
        /// Testing factorial of zero
        /// </summary>
        [TestMethod]
        public void ZeroTest()
        {
            Assert.AreEqual(1, Calculator.Factorial(0));
        } // DoubleTest()

        /// <summary>
        /// Testing factorial of negative number
        /// </summary>
        [TestMethod]
        public void NegativeTest()
        {
            Assert.AreEqual(-1, Calculator.Factorial(-5));
        } // NegativeTest()
    } //class Factorial

    /// <summary>
    /// Testing cases for Mod
    /// </summary>
    [TestClass]
    public class Mod
    {
        /// <summary>
        /// Testing modulo function of two positive integers
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreNotEqual(1, Calculator.Mod(2, 2));
            Assert.AreEqual(2, Calculator.Mod(2, 3));
            Assert.AreEqual(0, Calculator.Mod(3, 3));
            Assert.AreEqual(1, Calculator.Mod(10, 3));
            Assert.AreEqual(4, Calculator.Mod(54, 5));
        } // BasicTest()

        /// <summary>
        /// Testing modulo function of two negative integers
        /// </summary>
        [TestMethod]
        public void TestingNegative()
        {
            Assert.AreEqual(1, Calculator.Mod(10, -3));
            Assert.AreEqual(2, Calculator.Mod(-10, -3));
            Assert.AreEqual(2, Calculator.Mod(-10, 3));

            Assert.AreEqual(4, Calculator.Mod(54, -5));
            Assert.AreEqual(1, Calculator.Mod(-54, -5));
            Assert.AreEqual(1, Calculator.Mod(-54, 5));
        } // TestingNegative()

        /// <summary>
        /// Testing modulo function for Throw when a mod 0
        /// </summary>
        [TestMethod]
        public void TestingModByZeroThrow()
        {
            Assert.ThrowsException<ArgumentException>(() => Calculator.Mod(1, 0));
        } // TestingModByZeroThrow()

        /// <summary>
        /// Testing modulo function of two integers resulting zero
        /// </summary>
        [TestMethod]
        public void TestingResultZero()
        {
            Assert.AreEqual(0, Calculator.Mod(-9, 3));
            Assert.AreEqual(0, Calculator.Mod(-9, -3));
            Assert.AreEqual(0, Calculator.Mod(-9, -3));
            Assert.AreEqual(0, Calculator.Mod(9, -3));
        } // TestingResultZero()
    } //class Mod

    /// <summary>
    /// Testing cases for Abs
    /// </summary>
    [TestClass]
    public class Abs
    {
        /// <summary>
        /// Testing absolute value of an integer
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            Assert.AreNotEqual(-100, Calculator.Abs(100));
            Assert.AreEqual(100, Calculator.Abs(100));
            Assert.AreEqual(100, Calculator.Abs(-100));
        } // BasicTest()

        /// <summary>
        /// Testing absolute value of a double
        /// </summary>
        [TestMethod]
        public void DoubleTest()
        {
            Assert.AreNotEqual(-100.99, Calculator.Abs(100.99));
            Assert.AreEqual(100.98, Calculator.Abs(100.98));
            Assert.AreEqual(100.59, Calculator.Abs(-100.59));
        } // DoubleTest()
    } //class Abs

} // namespace CalculatorTests