using System;
using GCDAlgorithm;
using NUnit.Framework;

namespace GCDAlgorithm.Tests
{
    public class GCDSeekerTests
    {
        [TestCase(12, 24, 4, ExpectedResult = 4)]
        [TestCase(12, 24, 4, ExpectedResult = 4)]
        [TestCase(10, 20, ExpectedResult = 10)]
        [TestCase(96, 288, ExpectedResult = 96)]
        [TestCase(0, 42, ExpectedResult = 42)]
        [TestCase(42, 0, ExpectedResult = 42)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-1, 20, ExpectedResult = 1)]
        [TestCase(-42, -84, ExpectedResult = 42)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(2, int.MaxValue, ExpectedResult = 1)]
        [TestCase(int.MaxValue, 20, ExpectedResult = 1)]

        public int EuclideanAlgorithmTests(params int[] numbers)
        {
            return GCDSeeker.EuclideanAlgorithm(numbers);
        }

        [TestCase(12, 24, 4, ExpectedResult = 4)]
        [TestCase(12, 24, 4, ExpectedResult = 4)]
        [TestCase(10, 20, ExpectedResult = 10)]
        [TestCase(96, 288, ExpectedResult = 96)]
        [TestCase(0, 42, ExpectedResult = 42)]
        [TestCase(42, 0, ExpectedResult = 42)]
        [TestCase(0, 0, ExpectedResult = 0)]
        [TestCase(-1, 20, ExpectedResult = 1)]
        [TestCase(-42, -84, ExpectedResult = 42)]
        [TestCase(int.MaxValue, int.MaxValue, ExpectedResult = int.MaxValue)]
        [TestCase(2, int.MaxValue, ExpectedResult = 1)]
        [TestCase(int.MaxValue, 20, ExpectedResult = 1)]

        public int SteinAlgorithmTests(params int[] numbers)
        {
            return GCDSeeker.SteinAlgorithm(numbers);
        }

        [TestCase]
        public void EuclideanAlgorithm_ThrowsArgumentNullException()
        {
            int[] numbers = null;
            Assert.Throws<ArgumentNullException>(() => GCDSeeker.EuclideanAlgorithm(numbers));
        }

        [TestCase]
        public void EuclideanAlgorithm_ThrowsArgumentException()
        {
            int[] numbers = new int[] { };
            Assert.Throws<ArgumentException>(() => GCDSeeker.EuclideanAlgorithm(numbers));
        }

        [TestCase]
        public void SteinAlgorithm_ThrowsArgumentNullException()
        {
            int[] numbers = null;
            Assert.Throws<ArgumentNullException>(() => GCDSeeker.SteinAlgorithm(numbers));
        }

        [TestCase]
        public void SteinAlgorithm_ThrowsArgumentException()
        {
            int[] numbers = new int[] { };
            Assert.Throws<ArgumentException>(() => GCDSeeker.SteinAlgorithm(numbers));
        }
    }
}
