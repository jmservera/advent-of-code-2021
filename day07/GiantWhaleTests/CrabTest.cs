using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Day07.GiantWhaleTests
{
    public class CrabTest
    {
        [Theory]
        [InlineData("test.txt", 37)]
        [InlineData("input.txt", 349357)]
        public void FuelTest(string file, int expected)
        {
            var data = File.ReadAllText(file).Split(',').Select(int.Parse).ToArray();
            var actual = new GiantWhale.Crab(data).Solve();
            Assert.Equal(expected, actual);
        }
    }
}
