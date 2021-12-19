using System;
using Xunit;
using Day14.Polymerization;

namespace Day14.PolymerizationTests
{
    public class TemplateTest
    {
        [Theory]
        [InlineData("test.txt", 1588)]
        [InlineData("input.txt", 3342)]
        public void TestReaction(string fileName, int expected)
        {
            var data = DataLoader.LoadData(fileName);
            var actual = data.Reaction(10);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("test.txt", 2188189693529)]
        [InlineData("input.txt", 3776553567525)]
        public void TestLongReaction(string fileName, long expected)
        {
            var data = DataLoader.LoadData(fileName);
            var actual = data.Reaction(40);
            Assert.Equal(expected, actual);
        }
    }
}
