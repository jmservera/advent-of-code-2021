using Xunit;

namespace Day16.PacketDecoderTests;

using Day16.PacketDecoder;

public class PacketTest
{
    [Theory]
    [InlineData("C200B40A82",3)]
    [InlineData("04005AC33890",54)]
    [InlineData("880086C3E88112",7)]
    [InlineData("CE00C43D881120",9)]
    [InlineData("D8005AC2A8F0",1)]
    [InlineData("F600BC2D8F",0)]
    [InlineData("9C005AC2F8F0",0)]
    [InlineData("9C0141080250320F1802104A08",1)]
    public void TestCalculations(string data, int expected)
    {
        var input = DataLoader.LoadData(data);
        var decoder = new BitsDecoder(input);
        var actual = decoder.Decode();
        Assert.Equal(expected, actual.Calculate());
    }

    [Fact]
    public void TestCalcInput()
    {
        var input = DataLoader.LoadDataFromFile("input.txt");
        var decoder = new BitsDecoder(input);
        var actual = decoder.Decode();
        Assert.Equal(912901337844, actual.Calculate());
    }

}