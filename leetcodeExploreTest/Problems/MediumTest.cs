using leetcodeExplore.model;
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

    [Fact]
    public void CopyRandomListTest_1()
    {
        var input = new Node(7);
        input.next = new Node(13);
        input.next.next = new Node(11);
        input.next.next.next = new Node(10);
        input.next.next.next.next = new Node(1);
        input.next.random = input;
        input.next.next.random = input.next.next.next.next;
        input.next.next.next.random = input.next.next;
        input.next.next.next.next.random = input;

        var actual = _target.CopyRandomList(input);
        var expected = input;
        while (expected != null)
        {
            Assert.Equal(expected.val, actual.val);
            if (expected.random != null)
                Assert.Equal(expected.random.val, actual.random.val);
            expected = expected.next;
            actual = actual.next;
        }
    }

    [Fact]
    public void CopyRandomListTest_2()
    {
        var input = new Node(1);
        input.next = new Node(2);
        input.next.random = input.next;

        var actual = _target.CopyRandomList(input);
        var expected = input;
        while (expected != null)
        {
            Assert.Equal(expected.val, actual.val);
            if (expected.random != null)
                Assert.Equal(expected.random.val, actual.random.val);
            expected = expected.next;
            actual = actual.next;
        }
    }

    [Fact]
    public void CopyRandomListTest_3()
    {
        var input = new Node(3);
        input.next = new Node(3);
        input.next.next = new Node(3);
        input.next.random = input;

        var actual = _target.CopyRandomList(input);
        var expected = input;
        while (expected != null)
        {
            Assert.Equal(expected.val, actual.val);
            if (expected.random != null)
                Assert.Equal(expected.random.val, actual.random.val);
            expected = expected.next;
            actual = actual.next;
        }
    }

    [Fact]
    public void NumIslandsTest_1()
    {
        var grid = new char[][]{
            new char[]{'1','1','1','1','0'},
            new char[]{'1','1','0','1','0'},
            new char[]{'1','1','0','0','0'},
            new char[]{'0','0','0','0','0'}
        };
        var actual = _target.NumIslands(grid);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NumIslandsTest_2()
    {
        var grid = new char[][]{
            new char[]{'1','1','0','0','0'},
            new char[]{'1','1','0','0','0'},
            new char[]{'0','0','1','0','0'},
            new char[]{'0','0','0','1','1'}
        };
        var actual = _target.NumIslands(grid);
        var expected = 3;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void NumIslandsTest_3()
    {
        var grid = new char[][]{
            new char[]{'1','0','1','1','1'},
            new char[]{'1','0','1','0','1'},
            new char[]{'1','1','1','0','1'}
        };
        var actual = _target.NumIslands(grid);
        var expected = 1;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void RightSideViewTest_1()
    {
        var input = SetTreeNodeHelper.Init(new int?[] { 1, 2, 3, null, 5, null, 4 });

        var actual = _target.RightSideView(input);
        var expected = new int[] { 1, 3, 4 };
        Assert.Equal(expected.Length, actual.Count);
        for (int i = 0; i < actual.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void RightSideViewTest_2()
    {
        var input = SetTreeNodeHelper.Init(new int?[] { 1, null, 3 });
        var actual = _target.RightSideView(input);
        var expected = new int[] { 1, 3 };
        Assert.Equal(expected.Length, actual.Count);
        for (int i = 0; i < actual.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void RightSideViewTest_3()
    {
        TreeNode input = null;
        var actual = _target.RightSideView(input);
        var expected = new int[] { };
        Assert.Equal(expected.Length, actual.Count);
        for (int i = 0; i < actual.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void RightSideViewTest_4()
    {
        var input = SetTreeNodeHelper.Init(new int?[] { 1, 2, 3, 4, null, null, 5, null, 6 });
        var actual = _target.RightSideView(input);
        var expected = new int[] { 1, 3, 5, 6 };
        Assert.Equal(expected.Length, actual.Count);
        for (int i = 0; i < actual.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }


    [Theory]
    [ClassData(typeof(SearchMatrixTestData))]
    public void SearchMatrixTest(int[][] matrix, int target, bool expected)
    {
        var actual = _target.SearchMatrix(matrix, target);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [ClassData(typeof(SnakesAndLaddersTestData))]
    public void SnakesAndLaddersTest(int[][] board, int expected)
    {
        var actual = _target.SnakesAndLadders(board);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 1, 2, 2, 3 }, 5, new int[] { 1, 1, 2, 2, 3 })]
    [InlineData(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }, 7, new int[] { 0, 0, 1, 1, 2, 3, 3 })]
    [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
    public void RemoveDuplicatesTest(int[] input, int expected, int[] expectedNumbers)
    {
        var actual = _target.RemoveDuplicates(input);
        Assert.Equal(expected, actual);
        for (int i = 0; i < expected; i++)
        {
            Assert.Equal(expectedNumbers[i], input[i]);
        }
    }
}
