using System;
using Xunit;
using Day11.DumboOctopus;

namespace Day11.DumboOctopusTests
{
    public class CaveTest
    {
        [Theory]
        [InlineData("test.txt", 1656)]
        [InlineData("input.txt", 1642)]
        public void FlashTest(string fileName, int expected)
        {
            var cave = new Cave(DataLoader.LoadData(fileName));
            Assert.Equal(expected, cave.CountFlashes(100));
        }

                [Theory]
        [InlineData("test.txt", 195)]
        [InlineData("input.txt", 320)]
        public void SyncTest(string fileName, int expected)
        {
            var cave = new Cave(DataLoader.LoadData(fileName));
            Assert.Equal(expected, cave.FirstSyncFlash());
        }
    }
}
