using System;
using Xunit;
using Day15.Chiton;

namespace Day15.ChitonTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("test.txt",40)]
        [InlineData("input.txt",447)]
        public void LowestRisk(string fileName, int expected)
        {
            var path = DataLoader.LoadData(fileName);
            var actual = path.LowestRisk();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("test.txt",315)]
        [InlineData("input.txt",2835)]
        public void LowestRiskFull(string fileName, int expected)
        {
            var path = DataLoader.LoadData(fileName);
            path.ExpandMap();
            var actual = path.LowestRisk();
            Assert.Equal(expected, actual);
        }
    }
}
