using Xunit;
using System.Linq;
using Dive;

public class DiveTest{

    [Theory]
    [InlineData("test.txt",150)]
    [InlineData("input.txt",1990000)]
    public void DiverTest(string fileName, int expected){

        using(var data=new DataReader(fileName)){
            var array=Enumerable.ToArray(data);
            var actual=Diver.CalcPosition(array);
            Assert.Equal(expected,actual);
        }
    }

        [Theory]
    [InlineData("test.txt",900)]
    [InlineData("input.txt",1975421260)]
    public void GoodDiverTest(string fileName, int expected){

        using(var data=new DataReader(fileName)){
            var good=new GoodDiver();
            var array=Enumerable.ToArray(data);
            var actual=good.CalcPosition(array);
            Assert.Equal(expected,actual);
        }
    }
}