using System.Collections;
using System.Collections.Generic;
using leetcodeExplore.Problems;
using leetcodeExploreTest.TestData;
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

    // [Theory]
    // [InlineData(new char[][]{
    //         new char[]{'5','3','.','.','7','.','.','.','.'},
    //         new char[]{'6','.','.','1','9','5','.','.','.'},
    //         new char[]{'.','9','8','.','.','.','.','6','.'},
    //         new char[]{'8','.','.','.','6','.','.','.','3'},
    //         new char[]{'4','.','.','8','.','3','.','.','1'},
    //         new char[]{'7','.','.','.','2','.','.','.','6'},
    //         new char[]{'.','6','.','.','.','.','2','8','.'},
    //         new char[]{'.','.','.','4','1','9','.','.','5'},
    //         new char[]{'.','.','.','.','8','.','.','7','9'}
    //     })]
    [Fact]
    public void IsValidSudokuTest_1()
    {
        var board = new char[][]{
            new char[]{'5','3','.','.','7','.','.','.','.'},
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'}
        };
        var actual = _target.IsValidSudoku(board);
        Assert.True(actual);
    }

    [Fact]
    public void IsValidSudokuTest_2()
    {
        var board = new char[][]{
            new char[]{'8','3','.','.','7','.','.','.','.'},
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'},
        };
        var actual = _target.IsValidSudoku(board);
        Assert.False(actual);
    }

    [Fact]
    public void IsValidSudokuTest_3()
    {
        var board = new char[][]{
            new char[]{'.','.','.','.','5','.','.','1','.'},
            new char[]{'.','4','.','3','.','.','.','.','.'},
            new char[]{'.','.','.','.','.','3','.','.','1'},
            new char[]{'8','.','.','.','.','.','.','2','.'},
            new char[]{'.','.','2','.','7','.','.','.','.'},
            new char[]{'.','1','5','.','.','.','.','.','.'},
            new char[]{'.','.','.','.','.','2','.','.','.'},
            new char[]{'.','2','.','9','.','.','.','.','.'},
            new char[]{'.','.','4','.','.','.','.','.','.'}
        };
        var actual = _target.IsValidSudoku(board);
        Assert.False(actual);
    }


    [Theory]
    [ClassData(typeof(MergeTestData))]
    public void MergeTest(int[][] intervals, int[][] expected)
    {
        var actual = _target.Merge(intervals);
        Assert.Equal(expected.Length, actual.Length);
        for (int i = 0; i < actual.Length; i++)
        {
            Assert.Equal(expected[i][0], actual[i][0]);
            Assert.Equal(expected[i][1], actual[i][1]);
        }
    }

    [Theory]
    [InlineData("23", new string[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" })]
    [InlineData("2", new string[] { "a", "b", "c" })]
    [InlineData("234", new string[] {   "adg","adh","adi",
                                        "aeg","aeh","aei",
                                        "afg","afh","afi",
                                        "bdg","bdh","bdi",
                                        "beg","beh","bei",
                                        "bfg","bfh","bfi",
                                        "cdg","cdh","cdi",
                                        "ceg","ceh","cei",
                                        "cfg","cfh","cfi" })]
    public void LetterCombinationsTest(string digits, string[] expected)
    {
        var actual = _target.LetterCombinations(digits);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Theory]
    [InlineData("/home/", "/home")]
    [InlineData("/../", "/")]
    [InlineData("/home//foo/", "/home/foo")]
    [InlineData("/home///foo/", "/home/foo")]
    [InlineData("/home/a/../foo/", "/home/foo")]
    public void SimplifyPathTest(string path, string expected)
    {
        var actual = _target.SimplifyPath(path);
        Assert.Equal(expected, actual);
    }
}
