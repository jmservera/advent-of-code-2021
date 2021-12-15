using System;
using Xunit;

using Day08.SevenSegments;

namespace Day08.SevenSegmentsTests
{
    public class DisplayTest
    {
        [Theory]
        [InlineData("test.txt", 26)]
        [InlineData("input.txt", 409)]
        public void Test1478(string path, int expected)
        {
            var data = DataLoader.LoadData(path);
            var display = new Display(data);
            var actual = display.Count1478Digits();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("test.txt", 61229)]
        [InlineData("input.txt", 1024649)]
        public void TestFull(string path, int expected)
        {
            var data = DataLoader.LoadData(path);
            var display = new Display(data);
            var actual = display.SumFullDigits();
            Assert.Equal(expected, actual);
        }
    }
}
