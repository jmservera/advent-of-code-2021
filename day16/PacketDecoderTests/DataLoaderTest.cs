using Xunit;

namespace Day16.PacketDecoderTests;

using Day16.PacketDecoder;

public class DataLoaderTest
{
    [Theory]
    [InlineData("test.txt","110100101111111000101000")]
    [InlineData("test1.txt","00111000000000000110111101000101001010010001001000000000")]
    [InlineData("test2.txt","11101110000000001101010000001100100000100011000001100000")]
    public void TestLoad(string fileName, string expected)
    {
        var actual = DataLoader.LoadDataFromFile(fileName);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("test.txt",6,4)]
    [InlineData("test1.txt",1,6)]
    [InlineData("test2.txt",7,3)]

    public void TestHeader(string fileName, int expectedVersion,int expectedType){
        var actual = DataLoader.LoadDataFromFile(fileName);
        var decoder = new BitsDecoder(actual);
        var actualHeader = decoder.GetHeader(actual);
        Assert.Equal((expectedVersion,expectedType), actualHeader);
    }
}