using System.Linq;
using System.Collections.Generic;
using SonarSweep;
using Xunit;

public class SonarSweepTest{

    [Theory]
    [InlineData("test.txt",7)]
    [InlineData("input.txt",1226)]
    public void SingleTest(string file, int expected){
        var data=new TestData<int>(file);
        var counter=new SonarSweepCounter();
        var original=Enumerable.ToArray(data);

        Assert.Equal(expected, counter.CountSingle(original));

        List<int> list=new List<int>(original);
        list.Add(original[original.Length-1]+1);
        Assert.Equal(expected+1, counter.CountSingle(list.ToArray()));

        list.Add(original[original.Length-1]-2);
        list.Add(original[original.Length-1]-4);

        Assert.Equal(expected+1, counter.CountSingle(list.ToArray()));

    }

    [Theory]
    [InlineData("test.txt",5)]
    [InlineData("input.txt",1252)]
    public void WindowTest(string file, int expected){
        var data=new TestData<int>(file);
        var counter=new SonarSweepCounter();
        var original=Enumerable.ToArray(data);
        Assert.Equal(expected,counter.CountWindow(original,3));
    }
}