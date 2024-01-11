using System.Collections.Generic;
using System.Text;
using leetcodeExplore;
using Xunit;

namespace leetcodeExploreTest;

public class CodilityTest
{
    public Codility _target;
    public CodilityTest()
    {
        _target = new();
    }

    [Theory]
    [InlineData(new int[] { 1, 3, 6, 4, 1, 2 }, 5)]
    [InlineData(new int[] { 1, 2, 3 }, 4)]
    [InlineData(new int[] { -1, -3 }, 1)]
    public void solutionTest(int[] input, int expected)
    {
        var actual = _target.solution(input);
        Assert.Equal(expected, actual);
    }


    [Fact]
    public void solution1Test()
    {
        var tree = new Tree(5);
        tree.l = new Tree(3);
        tree.r = new Tree(10);
        tree.l.l = new Tree(20);
        tree.l.l.l = new Tree(33);
        tree.l.r = new Tree(21);
        tree.r.l = new Tree(1);
        var actual = _target.solution1(tree);
        var expected = 3;
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("abc", "ab")]
    [InlineData("hot", "ho")]
    [InlineData("codility", "cdility")]
    [InlineData("aaaa", "aaa")]
    public void solution2Test(string input, string expected)
    {
        var sb = new StringBuilder();
        var actual = _target.solution2(input);
        Assert.Equal(expected, actual);
        var a = new Dictionary<int, List<int>>();
        foreach (var (k, v) in a)
        {

        }
    }

    [Fact]
    public void solution3Test_1()
    {
        var input = new int[][]{
            new int[]{1,1,2},
            new int[]{2,0,0}
        };
        var actual = _target.solution3(input);
        var expected = 3;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void solution3Test_2()
    {
        var input = new int[][]{
            new int[]{5,-1},
            new int[]{-3,2},
            new int[]{0,4}
        };
        var actual = _target.solution3(input);
        var expected = 0;
        Assert.Equal(expected, actual);
    }
}
