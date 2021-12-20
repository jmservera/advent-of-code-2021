using Xunit;

namespace Day16.PacketDecoderTests;

using Day16.PacketDecoder;

public class DecoderTest
{
    [Theory]
    [InlineData("test.txt",2021)]
    public void TestDecode4(string fileName, int expected){
        var input= DataLoader.LoadDataFromFile(fileName);
        var decoder = new BitsDecoder(input);
        var actual = decoder.Decode();
        Assert.Equal(expected, actual.Data);
    }

    [Theory]
    [InlineData("test1.txt",new int[]{10,20})]
    [InlineData("test2.txt",new int[]{1,2,3})]
    public void TestDecode0(string fileName, int[] expected){
        var input= DataLoader.LoadDataFromFile(fileName);
        var decoder = new BitsDecoder(input);
        var actual = decoder.Decode();
        for(int i=0;i<expected.Length;i++){
            Assert.Equal(expected[i], actual.Packets?[i].Data);
        }
    }

    [Theory]
    [InlineData("8A004A801A8002F478",16)]
    [InlineData("620080001611562C8802118E34",12)]
    [InlineData("C0015000016115A2E0802F182340",23)]
    [InlineData("A0016C880162017C3686B18A3D4780",31)]
    public void TestVersionSums(string data, int expected){
        var input= DataLoader.LoadData(data);
        var decoder = new BitsDecoder(input);
        var actual = decoder.Decode();
        Assert.Equal(expected, actual.SumVersions());
    }

    [Fact]
    public void TestVersionSumsFinal(){
        var input= DataLoader.LoadDataFromFile("input.txt");
        var decoder = new BitsDecoder(input);
        var actual = decoder.Decode();
        Assert.Equal(934, actual.SumVersions());
    }
}