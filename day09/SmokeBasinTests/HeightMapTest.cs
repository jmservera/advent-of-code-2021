using System;
using Xunit;

using Day09.SmokeBasin;

namespace Day09.SmokeBasinTests
{
    public class HeigthMapTest
    {
        [Theory]
        [InlineData("test.txt",15)]
        [InlineData("input.txt",548)]
        public void TestRisk(string fileName,int expected)
        {
            var data = DataLoader.LoadData(fileName);
            var map = new HeigthMap(data);
            var actual = map.CalcRisk();
            Assert.Equal(expected,actual);
        }

        [Theory]
        [InlineData("test.txt",1134)]
        [InlineData("input.txt",786048)]
        public void TestBasins(string fileName,int expected)
        {
            var data = DataLoader.LoadData(fileName);
            var map = new HeigthMap(data);
            var actual = map.CalcBasins();
            Assert.Equal(expected,actual);
        }
    }
}
