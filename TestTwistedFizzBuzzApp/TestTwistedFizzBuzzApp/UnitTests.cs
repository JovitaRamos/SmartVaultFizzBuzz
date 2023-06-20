using FizzBuzzLib;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace TestTwistedFizzBuzzApp
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void GetFizzBuzzSequential_ReturnsCorrectValues()
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();
            var expectedValues = new List<string>
            {
                "1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", "Fizz", "Buzz", "11",
                "Fizz", "13", "14", "FizzBuzz", "16", "17", "Fizz", "19", "Buzz", "Fizz", "22",
                "23", "Fizz", "Buzz", "26", "Fizz", "28", "29", "FizzBuzz", "31", "32", "Fizz",
                "34", "Buzz", "Fizz", "37", "38", "Fizz", "Buzz", "41", "Fizz", "43", "44",
                "FizzBuzz", "46", "47", "Fizz", "49", "Buzz", "Fizz", "52", "53", "Fizz", "Buzz",
                "56", "Fizz", "58", "59", "FizzBuzz", "61", "62", "Fizz", "64", "Buzz", "Fizz",
                "67", "68", "Fizz", "Buzz", "71", "Fizz", "73", "74", "FizzBuzz", "76", "77",
                "Fizz", "79", "Buzz", "Fizz", "82", "83", "Fizz", "Buzz", "86", "Fizz", "88",
                "89", "FizzBuzz", "91", "92", "Fizz", "94", "Buzz", "Fizz", "97", "98", "Fizz",
                "Buzz"
            };

            // Act
            var result = fizzBuzz.GetFizzBuzzSequential(1, 100).ToList();

            // Assert
            Assert.AreEqual(expectedValues, result);
        }

        [TestMethod]
        public void GetFizzBuzzNonSequential_ReturnsCorrectValues()
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();
            var numbers = new[] { 15, 3, 5, 7, 9, 10 };
            var expectedValues = new[] { "FizzBuzz", "Fizz", "Buzz", "7", "Fizz", "Buzz" };

            // Act
            var result = fizzBuzz.GetFizzBuzzNonSequential(numbers).ToList();

            // Assert
            Assert.AreEqual(expectedValues, result);
        }

        [TestMethod]
        public void SetInputsFromEndpoint_SetsValuesFromEndpoint()
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();

            // Act
            fizzBuzz.SetInputsFromEndpoint().Wait();

            // Assert
            var result = fizzBuzz.GetFizzBuzzSequential(1, 100).ToList();

            Assert.That(result.Count, Is.GreaterThan(0));
        }

        [TestMethod]
        public void GetFizzBuzzSequential_StartGreaterThanEnd_ThrowsArgumentException()
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => fizzBuzz.GetFizzBuzzSequential(100, 1).ToList());
        }

        [TestMethod]
        public void GetFizzBuzzSequential_EndEqualToStart_ReturnsSingleValue()
        {
            // Arrange
            var fizzBuzz = new FizzBuzz();

            // Act
            var result = fizzBuzz.GetFizzBuzzSequential(1, 1).ToList();

            // Assert
            Assert.IsTrue(result.Count == 1);
        }
    }
}