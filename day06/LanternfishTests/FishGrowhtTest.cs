using System;
using System.IO;
using Xunit;
using System.Linq;
using Lanternfish;

public class FishGrowhtTest
{
    [Fact]

    public void TestPartialGrowth()
    {
        var lanternGrowth=File.ReadAllLines("test.txt").Select(line => line.Split(',').Select(int.Parse).ToArray()).ToArray();
        for(int i=1;i<lanternGrowth.Length;i++)
        {
            var g=new FishGrowth().Growth(lanternGrowth[i-1], 1);
            Assert.Equal(lanternGrowth[i].Length, g);
        }
    }

    [Fact]
    public void TestCompleteGrowth()
    {
        var lanternGrowth=File.ReadAllLines("test.txt").Select(line => line.Split(',').Select(int.Parse).ToArray()).ToArray();
        var g=new FishGrowth().Growth(lanternGrowth[0], lanternGrowth.Length-1);
        Assert.Equal(lanternGrowth[lanternGrowth.Length-1].Length, g);
    }

    [Fact]
    public void TestCompleteGrowthStatic()
    {
        var lanternGrowth=File.ReadAllLines("test.txt").Select(line => line.Split(',').Select(int.Parse).ToArray()).ToArray();
        var g=new FishGrowth().Growth(lanternGrowth[0], 18);
        Assert.Equal(26, g);

        g=new FishGrowth().Growth(lanternGrowth[0], 80);
        Assert.Equal(5934, g);

    }


    [Fact]
    public void TestInput80(){
        var lanternGrowth=File.ReadAllLines("input.txt").Select(line => line.Split(',').Select(int.Parse).ToArray()).ToArray();
        var g=new FishGrowth().Growth(lanternGrowth[0], 80);
        Assert.Equal(352872, g);
    }

    [Fact]
    public void Test256(){
        var lanternGrowth=File.ReadAllLines("test.txt").Select(line => line.Split(',').Select(int.Parse).ToArray()).ToArray();
        var g=new FishGrowth().Growth(lanternGrowth[0], 256);
        Assert.Equal(26984457539, g);
    }

    [Fact]
    public void TestInput256(){
        var lanternGrowth=File.ReadAllLines("input.txt").Select(line => line.Split(',').Select(int.Parse).ToArray()).ToArray();
        var g=new FishGrowth().Growth(lanternGrowth[0], 256);
        Assert.Equal(1604361182149, g);
    }
}
