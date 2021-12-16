using System;
using Xunit;

using Day10.SyntaxScoring;

namespace Day10.SyntaxScoringTests
{
    public class NavigationTest
    {
        [Theory]
        [InlineData("test.txt", 26397)]
        [InlineData("input.txt", 271245)]
        public void TestScore(string fileName, int expected)
        {
            var lines = System.IO.File.ReadAllLines(fileName);
            var navigation = new Navigation(lines);
            Assert.Equal(expected, navigation.Score());
        }

        [Theory]
        [InlineData("test.txt", 288957)]
        [InlineData("input.txt", 1685293086)]
        public void TestCompletionScore(string fileName, long expected)
        {
            var lines = System.IO.File.ReadAllLines(fileName);
            var navigation = new Navigation(lines);
            Assert.Equal(expected, navigation.CompletionScore());
        }
    }
}
