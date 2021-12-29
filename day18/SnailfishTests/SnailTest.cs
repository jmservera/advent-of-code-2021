using System;
using System.IO;
using Xunit;

namespace Day18.SnailfishTests;

using Day18.Snailfish;


public class SnailTest
{

    [Fact]
    public void TestParse(){
        var input="[[[[4,3],4],4],[7,[[8,4],9]]]";
        var nodes= SnailNode.Parse(input);
        Assert.Equal(0,nodes.Level);
        Assert.Equal(1,nodes.Left?.Level);
        Assert.Equal(2,nodes.Left?.Left?.Level);
        Assert.Equal(3,nodes.Left?.Left?.Left?.Level);
        Assert.Equal(4,nodes.Left?.Left?.Left?.Left?.Level);
        Assert.Equal(SnailNodeType.Number,nodes.Left?.Left?.Left?.Left?.Type);
        Assert.Equal(4,nodes.Left?.Left?.Left?.Left?.Value);
        Assert.Equal(3,nodes.Left?.Left?.Left?.Right?.Value);

        Assert.Equal(input,nodes.ToString());
    }


    [Theory]
    [InlineData("[[[[4,3],4],4],[7,[[8,4],9]]]","[1,1]","[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]")]
    [InlineData("[1,2]","[[3,4],5]","[[1,2],[[3,4],5]]")]
    public void TestSimpleSum(string input1, string input2, string expected)
    {
        SnailMath math = new SnailMath();
        string actual = math.SimpleSum(input1, input2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("[[[[[9,8],1],2],3],4]","[[[[0,9],2],3],4]")]
    [InlineData("[7,[6,[5,[4,[3,2]]]]]","[7,[6,[5,[7,0]]]]")]
    [InlineData("[[6,[5,[4,[3,2]]]],1]","[[6,[5,[7,0]]],3]")]
    [InlineData("[[[[0,7],4],[15,[0,13]]],[1,1]]","[[[[0,7],4],[15,[0,13]]],[1,1]]")]
    public void TestExplosion(string input, string expected){
        SnailMath snailMath = new SnailMath();
        Assert.Equal(expected, snailMath.Explode(input));
    }

    [Theory]
    [InlineData("[[[[0,7],4],[15,[0,13]]],[1,1]]","[[[[0,7],4],[[7,8],[0,13]]],[1,1]]")]
    [InlineData("[[[[0,7],4],[[7,8],[0,13]]],[1,1]]","[[[[0,7],4],[[7,8],[0,[6,7]]]],[1,1]]")]
    [InlineData("[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]","[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]")]
    public void TestSplit(string input, string expected){
        SnailMath snailMath = new SnailMath();
        Assert.Equal(expected, snailMath.Split(input));
    }

    [Theory]
    [InlineData("[[[[4,3],4],4],[7,[[8,4],9]]]","[1,1]","[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")]
    public void TestSum(string input1, string input2, string expected)
    {
        SnailMath snailMath = new SnailMath();
        Assert.Equal(expected, snailMath.Sum(input1, input2));
    }

    [Theory]
    [InlineData("test1.txt","[[[[6,6],[7,6]],[[7,7],[7,0]]],[[[7,7],[7,7]],[[7,8],[9,9]]]]",4140)]
    [InlineData("input.txt","[[[[7,6],[6,7]],[[7,7],[7,8]]],[[[8,0],[8,7]],[[6,8],[6,0]]]]",3981)]
    public void TestFileSum(string fileName, string expected, int magnitude)
    {
        SnailMath snailMath = new SnailMath();
        var lines=File.ReadAllLines(fileName);
        var result=lines[0];
        for(int i=1;i<lines.Length;i++){
            result=snailMath.Sum(result,lines[i]);
        }
        Assert.Equal(expected,result);
        Assert.Equal(magnitude,snailMath.Magnitude(result));
    }

    [Theory]
    [InlineData("[9,1]",29)]
    [InlineData("[1,9]",21)]
    [InlineData("[[1,2],[[3,4],5]]",143)]
[InlineData("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]",1384)]
[InlineData("[[[[1,1],[2,2]],[3,3]],[4,4]]",445)]
[InlineData("[[[[3,0],[5,3]],[4,4]],[5,5]]",791)]
[InlineData("[[[[5,0],[7,4]],[5,5]],[6,6]]",1137)]
[InlineData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]",3488)]
    public void TestMagnitude(string input, int expected){
        SnailMath snailMath = new SnailMath();
        Assert.Equal(expected,snailMath.Magnitude(input));
    }
}