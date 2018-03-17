using System;
using GCDAlgorithm;
using NUnit.Framework;


namespace GDCSeeker.Tests
{
    public class GCDSeekerTests
    {
        [TestCase(12, 24, 4, ExpectedResult = 4)]
        [TestCase(12, 24, 4, ExpectedResult = 4)]
        [TestCase(10, 20, ExpectedResult = 10)]
        [TestCase(96, 288, ExpectedResult = 12)]
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
    }
}
