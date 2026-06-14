namespace BowlingGameScoreboard.Tests;
using BowlingGameScoreboard.Services;
using Xunit;
public class BowlingTests
{
[Fact]
public void Calculate_GutterGame()
{
    var service = new BowlingService();
    var rolls = Enumerable.Repeat(0, 20).ToList();

    var result = service.Calculate(rolls);

    Assert.Equal(0, result);
}

[Fact]
public void Calculate_AllOnes()
{

    var service = new BowlingService();
    var rolls = Enumerable.Repeat(1, 20).ToList();

    var result = service.Calculate(rolls);


    Assert.Equal(20, result);
}

[Fact]
public void Calculate_Spare()
{

    var service = new BowlingService();

    var rolls = new List<int>
    {
        5,5,
        3,0,
        0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0
    };

    var result = service.Calculate(rolls);

    Assert.Equal(16, result);
}

[Fact]
public void Calculate_Strike_AddsNextTwoRolls()
{
    var service = new BowlingService();

    var rolls = new List<int>
    {
        10,
        3,4,
        0,0,0,0,0,0,0,0,
        0,0,0,0,0,0,0,0
    };

    var result = service.Calculate(rolls);

    Assert.Equal(24, result);
}

[Fact]
public void Calculate_PerfectGame()
{
    var service = new BowlingService();

    var rolls = Enumerable.Repeat(10, 12).ToList();

    var result = service.Calculate(rolls);

    Assert.Equal(300, result);
}

[Fact]
public void Calculate_ExampleGame()
{
    var service = new BowlingService();

    var rolls = new List<int>
    {
        1,4,
        4,5,
        6,4,
        5,5,
        10,
        0,1,
        7,3,
        6,4,
        10,
        2,8,6
    };

    var result = service.Calculate(rolls);

    Assert.Equal(133, result);
}
}
