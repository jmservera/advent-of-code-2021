using System;
using Xunit;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

public class DataTest
{
    [Theory]
    [InlineData("test.txt")]
    public void Test1(string fileName)
    {
        DataReader reader = new DataReader(fileName);

        var a=Enumerable.ToArray(reader);
        Assert.Equal("forward", a[0].Item1);
        Assert.Equal( "down", a[1].Item1);
        Assert.Equal(6, a.Length);
    }
}
