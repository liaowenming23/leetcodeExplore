using System.Collections.Generic;
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

    [Fact]
    public void SolveNQueensTest_1()
    {
        var actual = _targe.SolveNQueens(4);
        var expected = new List<List<string>>
        {
            new() {
                ".Q..",
                "...Q",
                "Q...",
                "..Q.",
            },
            new() {
                "..Q.",
                "Q...",
                "...Q",
                ".Q..",
            }
        };
        Assert.Equal(expected.Count, actual.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            var e = expected[i];
            for (int j = 0; j < e.Count; j++)
            {
                Assert.Equal(e[j], actual[i][j]);
            }
        }
    }

    [Fact]
    public void SolveNQueensTest_2()
    {
        var actual = _targe.SolveNQueens(1);
        var expected = new List<List<string>>
        {
            new() {
                "Q"
            },
        };
        Assert.Equal(expected.Count, actual.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            var e = expected[i];
            for (int j = 0; j < e.Count; j++)
            {
                Assert.Equal(e[j], actual[i][j]);
            }
        }
    }
}
