using leetcodeExplore.Problems;
using Xunit;

namespace leetcodeExploreTest.Problems;

public class HardTest
{
    private readonly Hard _targe;
    public HardTest()
    {
        _targe = new Hard();
    }

    [Theory]
    [InlineData(new int[] { 1, 0, 2 }, 5)]
    [InlineData(new int[] { 1, 2, 2 }, 3)]
    [InlineData(new int[] { 1, 2, 3, 4, 3, 2, 1, 0 }, 21)]
    public void CandyTest(int[] ratings, int expected)
    {
        var actual = _targe.Candy(ratings);
        Assert.Equal(expected, actual);
    }
}
