using System;
using Xunit;
using BinaryDiagnostic;

public class BinaryDiagTest
{
    [Theory]
    [InlineData("test.txt", 198)]
    [InlineData("input.txt", 4174964)]
    public void TestData(string fileName, int expected)
    {
        var data=DataLoader.LoadData(fileName);
        var actual=Diagnostic.Run(data);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("test.txt", 230)]
    [InlineData("input.txt", 4474944)]
    public void TestRatings(string fileName, int expected){
        var data=DataLoader.LoadData(fileName);
        var actual=Diagnostic.Rating(data);
        Assert.Equal(expected, actual);
    }
}
