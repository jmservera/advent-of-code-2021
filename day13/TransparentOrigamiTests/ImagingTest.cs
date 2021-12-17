using System;
using Xunit;
using Day13.TransparentOrigami;

namespace Day13.TransparentOrigamiTests
{
    public class ImagingTest
    {
        [Theory]
        [InlineData("test.txt", 17)]
        [InlineData("input.txt", 708)]
        public void FoldTest(string fileName, int expected)
        {
            var thermalImaging = DataLoader.LoadData(fileName);
            var actual = thermalImaging.Fold(1);
            Assert.Equal(expected, actual);
        }        

        [Theory]
        [InlineData("test.txt", 16)]
        [InlineData("input.txt", 138)]
        public void CompleteFoldTest(string fileName, int expected)
        {
            var thermalImaging = DataLoader.LoadData(fileName);
            var actual = thermalImaging.Fold();
            Assert.Equal(expected, actual);
        } 
    }
}
