using System;
using Xunit;

using Day09.SmokeBasin;

namespace Day09.SmokeBasinTests
{
    public class HeigthMapTest
    {
        [Theory]
        [InlineData("test.txt",15)]
        public void TestRisk(string fileName,int expected)
        {
            var data = DataLoader.LoadData(fileName);
            var map = new HeigthMap(data);
            var actual = map.CalcRisk();
            Assert.Equal(expected,actual);
        }
    }
}
