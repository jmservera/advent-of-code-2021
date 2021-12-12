using System;
using Xunit;

public class VentsTest
{
    [Fact]
    public void TestLoader()
    {
        string[] expected={
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };
        var actual = DataLoader.LoadData("test.txt");
        Assert.Equal(expected, actual);
    }


    [Theory]
    [InlineData("test.txt",5)]
    [InlineData("input.txt",5)]
    public void TestVents(string fileName, int expected){
        var data= DataLoader.LoadData(fileName);
        var actual = Vents.Solve(data);
        Assert.Equal(expected, actual);
    }

//             string[] exptected = new string
//         {".......1.."
// ,"..1....1.."
// ,"..1....1.."
// ,".......1.."
// ,".112111211"
// ,".........."
// ,".........."
// ,".........."
// ,".........."
// ,"222111...."};

}
