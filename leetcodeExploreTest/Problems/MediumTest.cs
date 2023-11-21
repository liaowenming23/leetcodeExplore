using System.ComponentModel.DataAnnotations.Schema;
using leetcodeExplore.Problems;
using Xunit;

namespace leetcodeExploreTest.Problems;
public class MediumTest
{
    private readonly Medium _target;

    public MediumTest()
    {
        _target = new();
    }

    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData(" ", 1)]
    [InlineData("aab", 2)]
    [InlineData("abba", 2)]
    public void LengthOfLongestSubstringTest(string input, int expected)
    {
        var actual = _target.LengthOfLongestSubstring(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("cbbd", "bb")]
    [InlineData("ccc", "ccc")]
    public void LongestPalindromeTest(string input, string expected)
    {
        var actual = _target.LongestPalindrome(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    [InlineData("A", 1, "A")]
    [InlineData("0123456789ABCDEFG", 5, "08G179F26AE35BD4C")]
    public void ConvertTest(string input, int numRows, string expected)
    {
        var actual = _target.Convert(input, numRows);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4)]
    [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
    public void MaxProfitTest(int[] input, int expected)
    {
        var actual = _target.MaxProfit(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 2, 3, 1, 1, 4 }, true)]
    [InlineData(new int[] { 3, 2, 1, 0, 4 }, false)]
    [InlineData(new int[] { 0, 1 }, false)]
    public void CanJumpTest(int[] input, bool expected)
    {
        var actual = _target.CanJump(input);
        Assert.Equal(expected, actual);
    }
}
