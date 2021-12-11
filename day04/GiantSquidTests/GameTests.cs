using System;

using Xunit;


public class GameTests
{
    [Theory]
    [InlineData("test.txt", 4512)]
    [InlineData("input.txt", 22680)]
    public void FirstWin(string fileName, int expected)
    {     
        Bingo bingo= DataLoader.LoadData(fileName);
        Assert.True(bingo.Numbers?.Length>0);
        Assert.True(bingo.Cards?.Count>0);
        Assert.Equal(expected,Game.Play(bingo));
    }

        [Theory]
    [InlineData("test.txt", 1924)]
    [InlineData("input.txt", 16168)]
    public void LastWin(string fileName, int expected)
    {     
        Bingo bingo= DataLoader.LoadData(fileName);
        Assert.True(bingo.Numbers?.Length>0);
        Assert.True(bingo.Cards?.Count>0);
        Assert.Equal(expected,Game.Last(bingo));
        
    }
}
