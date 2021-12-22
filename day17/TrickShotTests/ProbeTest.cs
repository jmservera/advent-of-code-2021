using Xunit;

namespace Day17.TrickShotTests;

using Day17.TrickShot;

public class ProbeTest
{
    [Theory]
    [InlineData(20,30,-10,-5,6,9,112)]
    [InlineData(155,215,-132,-72,18,131,5945)]
    public void TestBestShot(int x1,int x2,int y1,int y2,int expectedX, int expectedY,int expectedCount)
    {
        var probe = new ProbeLauncher(x1,x2,y1,y2);
        var ((x,y),c) = probe.FindBestShot();
        Assert.Equal(expectedX,x);
        Assert.Equal(expectedY,y);
        Assert.Equal(expectedCount,c);

    }

    [Theory]
    [InlineData(7,2,7,new int[]{28,-7},3,true)]
    [InlineData(9,0,4,new int[]{30,-6},6,true)]
    [InlineData(6,3,9,new int[]{21,-9},0,true)]
    [InlineData(17,-4,3,new int[]{48,-15},0,false)]
    [InlineData(6,9,20,new int[]{21,-10},45,true)]
    [InlineData(6,19,40,new int[]{21,-20},45,false)]
    public void TestLaunch(int x, int y, int nsteps, int[] expected, int maxY, bool shot){
        var probe = new ProbeLauncher(20,30,-10,-5);
        var steps = probe.Launch(x,y);
        Assert.Equal(shot,probe.TrenchShot);
        Assert.Equal(nsteps,steps.Length);
        Assert.Equal(expected,steps[nsteps-1]);        
    }
}
