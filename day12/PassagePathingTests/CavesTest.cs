using System;
using Xunit;
using Day12.PassagePathing;

namespace Day12.PassagePathingTests
{
    public class CavesTest
    {
        [Theory]
        [InlineData("test1.txt", 10)]
        [InlineData("test2.txt", 19)]
        [InlineData("test3.txt", 226)]
        [InlineData("input.txt", 3510)]
        public void TestPath(string fileName, int expected)
        {
            var cave = new Cave(DataLoader.LoadData(fileName));
            Assert.Equal(expected, cave.CountPaths());
        }

        [Theory]
        [InlineData("test1.txt", 36)]
        [InlineData("test2.txt", 103)]
        [InlineData("test3.txt", 3509)]
        [InlineData("input.txt", 122880)]
        public void TestPath2(string fileName, int expected)
        {
            var cave = new Cave(DataLoader.LoadData(fileName));
            Assert.Equal(expected, cave.CountPaths2());
        }
    }
}
