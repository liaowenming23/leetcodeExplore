using System;
using System.Collections.Generic;
using System.Reflection;
using leetcodeExplore.model;
using leetcodeExplore.Problems;
using Microsoft.VisualBasic;
using Xunit;

namespace leetcodeExploreTest.Problems;
public class EasyTest
{
    private readonly Easy _target;

    public EasyTest()
    {
        _target = new Easy();
    }

    [Theory]
    [InlineData(new int[] { 1, 3, 5, 6 }, 5, 2)]
    [InlineData(new int[] { 1, 3, 5, 6 }, 2, 1)]
    [InlineData(new int[] { 1, 3, 5, 6 }, 7, 4)]
    [InlineData(new int[] { 1, 3, 5, 6 }, 0, 0)]
    public void SearchInsertTest(int[] nums, int target, int expected)
    {
        var actual = _target.SearchInsert(nums, target);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
    [InlineData(new int[] { 1 }, 1)]
    [InlineData(new int[] { 5, 4, -1, 7, 8 }, 23)]
    [InlineData(new int[] { -1 }, -1)]
    public void MaxSubArrayTest(int[] nums, int expected)
    {
        var actual = _target.MaxSubArray(nums);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData(" ", 0)]
    [InlineData("a ", 1)]
    [InlineData("b   a    ", 1)]
    [InlineData("Today is a nice day", 3)]
    public void LengthOfLastWordTest(string s, int expected)
    {
        var actual = _target.LengthOfLastWord(s);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 5)]
    public void ClimbStairsTest(int n, int expected)
    {
        var actual = _target.ClimbStairs(n);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void DeleteDuplicatesTest_1()
    {
        var head = new ListNode(1);
        head.next = new ListNode(1);
        head.next.next = new ListNode(2);

        var expected = new ListNode(1);
        expected.next = new ListNode(2);

        var actual = _target.DeleteDuplicates(head);
        Assert.True(VerifyListNodeVal(expected, actual));
    }

    [Fact]
    public void DeleteDuplicatesTest_2()
    {
        var head = new ListNode(1);
        head.next = new ListNode(1);
        head.next.next = new ListNode(1);

        var expected = new ListNode(1);

        var actual = _target.DeleteDuplicates(head);
        Assert.True(VerifyListNodeVal(expected, actual));
    }

    private bool VerifyListNodeVal(ListNode expected, ListNode actual)
    {
        bool result = true;
        while (expected is not null && actual is not null && result)
        {
            if (!expected.val.Equals(actual.val))
                result = false;

            expected = expected.next;
            actual = actual.next;
        }
        return result;
    }

    [Theory]
    [InlineData(new int[6] { 1, 2, 3, 0, 0, 0 }, 3, new int[3] { 2, 5, 6 }, 3, new int[6] { 1, 2, 2, 3, 5, 6 })]
    [InlineData(new int[1] { 1 }, 1, new int[] { }, 0, new int[1] { 1 })]
    [InlineData(new int[1] { 0 }, 0, new int[1] { 1 }, 1, new int[1] { 1 })]
    [InlineData(new int[2] { 2, 0 }, 1, new int[1] { 1 }, 1, new int[2] { 1, 2 })]
    [InlineData(new int[63] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, 0, new int[63] { -50, -50, -48, -47, -44, -44, -37, -35, -35, -32, -32, -31, -29, -29, -28, -26, -24, -23, -23, -21, -20, -19, -17, -15, -14, -12, -12, -11, -10, -9, -8, -5, -2, -2, 1, 1, 3, 4, 4, 7, 7, 7, 9, 10, 11, 12, 14, 16, 17, 18, 21, 21, 24, 31, 33, 34, 35, 36, 41, 41, 46, 48, 48 }, 63, new int[63] { -50, -50, -48, -47, -44, -44, -37, -35, -35, -32, -32, -31, -29, -29, -28, -26, -24, -23, -23, -21, -20, -19, -17, -15, -14, -12, -12, -11, -10, -9, -8, -5, -2, -2, 1, 1, 3, 4, 4, 7, 7, 7, 9, 10, 11, 12, 14, 16, 17, 18, 21, 21, 24, 31, 33, 34, 35, 36, 41, 41, 46, 48, 48 })]
    public void MergeTest(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        _target.Merge(nums1, m, nums2, n);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(nums1[i], expected[i]);
        }
    }

    [Fact]
    public void InorderTraversalTest_1()
    {
        var input = new TreeNode(1);
        input.right = new TreeNode(2);
        input.right.left = new TreeNode(3);

        var expected = new List<int> { 1, 3, 2 };
        var actual = _target.InorderTraversal(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InorderTraversalTest_2()
    {
        var input = new TreeNode(1);

        var expected = new List<int> { 1 };
        var actual = _target.InorderTraversal(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InorderTraversalTest_3()
    {
        var input = new TreeNode(1);
        input.left = new TreeNode(2);

        var expected = new List<int> { 2, 1 };
        var actual = _target.InorderTraversal(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void InorderTraversalTest_4()
    {
        var input = new TreeNode(1);
        input.right = new TreeNode(2);

        var expected = new List<int> { 1, 2 };
        var actual = _target.InorderTraversal(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsSameTreeTest_1()
    {
        var p = new TreeNode(1);
        p.left = new TreeNode(2);
        p.right = new TreeNode(3);

        var q = new TreeNode(1);
        q.left = new TreeNode(2);
        q.right = new TreeNode(3);
        var expected = true;
        var actual = _target.IsSameTree(p, q);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsSameTreeTest_2()
    {
        var p = new TreeNode(1);
        p.left = new TreeNode(2);

        var q = new TreeNode(1);
        q.right = new TreeNode(2);
        var expected = false;
        var actual = _target.IsSameTree(p, q);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsSameTreeTest_3()
    {
        var p = new TreeNode(1);
        p.left = new TreeNode(2);
        p.right = new TreeNode(1);

        var q = new TreeNode(1);
        q.left = new TreeNode(1);
        q.right = new TreeNode(2);
        var expected = false;
        var actual = _target.IsSameTree(p, q);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsSymmetric_1()
    {
        var root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.left.left = new TreeNode(3);
        root.left.right = new TreeNode(4);
        root.right = new TreeNode(2);
        root.right.left = new TreeNode(4);
        root.right.right = new TreeNode(3);
        var expected = true;
        var actual = _target.IsSymmetric(root);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsSymmetric_2()
    {
        var root = new TreeNode(1);
        root.left = new TreeNode(2);
        root.left.right = new TreeNode(3);
        root.right = new TreeNode(2);
        root.right.right = new TreeNode(3);
        var expected = false;
        var actual = _target.IsSymmetric(root);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MaxDepth_1()
    {
        var root = new TreeNode(3);
        root.left = new TreeNode(9);
        root.right = new TreeNode(20);
        root.right.left = new TreeNode(15);
        root.right.right = new TreeNode(7);
        var expected = 3;
        var actual = _target.MaxDepth(root);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MaxDepth_2()
    {
        TreeNode root = null;
        var expected = 0;
        var actual = _target.MaxDepth(root);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void MaxDepth_3()
    {
        var root = new TreeNode(0);
        var expected = 1;
        var actual = _target.MaxDepth(root);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SortedArrayToBSTTest_1()
    {
        var input = new int[] { -10, -3, 0, 5, 9 };
        var expected = new TreeNode(0);
        expected.left = new TreeNode(-10);
        expected.left.right = new TreeNode(-3);
        expected.right = new TreeNode(5);
        expected.right.right = new TreeNode(9);

        var actual = _target.SortedArrayToBST(input);
        Assert.True(VerifyTreeNode(expected, actual));
    }

    [Fact]
    public void SortedArrayToBSTTest_2()
    {
        var input = new int[] { 1, 3 };
        var expected = new TreeNode(1);
        expected.right = new TreeNode(3);

        var actual = _target.SortedArrayToBST(input);
        Assert.True(VerifyTreeNode(expected, actual));
    }

    private bool VerifyTreeNode(TreeNode expected, TreeNode actual)
    {
        if (expected is null && actual is null)
            return true;
        if (expected is null || actual is null)
            return false;
        if (!expected.val.Equals(actual.val))
            return false;
        return VerifyTreeNode(expected.left, actual.left) && VerifyTreeNode(expected.right, actual.right);
    }

    [Theory]
    [InlineData(new int[] { 2, 2, 1 }, 1)]
    [InlineData(new int[] { 4, 1, 2, 1, 2 }, 4)]
    [InlineData(new int[] { 1 }, 1)]
    public void SingleNumberTest(int[] nums, int expected)
    {
        var actual = _target.SingleNumber(nums);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    [InlineData(" ", true)]
    [InlineData("0P", false)]
    public void IsPalindromeTest(string input, bool expected)
    {
        var actual = _target.IsPalindrome(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsBalancedTest_1()
    {
        var input = new TreeNode(3);
        input.left = new TreeNode(9);
        input.right = new TreeNode(20);
        input.right.left = new TreeNode(15);
        input.right.right = new TreeNode(7);
        var actual = _target.IsBalanced(input);
        Assert.True(actual);
    }

    [Fact]
    public void IsBalancedTest_2()
    {
        var input = new TreeNode(1);
        input.left = new TreeNode(2);
        input.left.left = new TreeNode(3);
        input.left.right = new TreeNode(3);
        input.left.left.left = new TreeNode(4);
        input.left.left.right = new TreeNode(4);
        input.right = new TreeNode(2);
        var actual = _target.IsBalanced(input);
        Assert.False(actual);
    }

    [Fact]
    public void IsBalancedTest_3()
    {
        var input = new TreeNode(1);
        input.right = new TreeNode(2);
        input.right.right = new TreeNode(3);
        var actual = _target.IsBalanced(input);
        Assert.False(actual);
    }

    [Fact]
    public void IsBalancedTest_4()
    {
        var input = new TreeNode(1);
        input.left = new TreeNode(2);
        input.left.left = new TreeNode(4);
        input.left.right = new TreeNode(5);
        input.left.left.left = new TreeNode(8);
        input.right = new TreeNode(3);
        input.right.left = new TreeNode(6);
        var actual = _target.IsBalanced(input);
        Assert.True(actual);
    }

    [Fact]
    public void IsBalancedTest_5()
    {
        var input = new TreeNode(1);
        input.left = new TreeNode(2);
        input.left.left = new TreeNode(3);
        input.left.right = new TreeNode(3);
        input.left.left.left = new TreeNode(4);
        input.left.left.right = new TreeNode(4);
        input.left.right.left = new TreeNode(4);
        input.left.right.right = new TreeNode(4);
        input.left.left.left.left = new TreeNode(5);
        input.left.left.left.right = new TreeNode(5);
        input.right = new TreeNode(2);
        input.right.left = new TreeNode(3);
        input.right.right = new TreeNode(3);
        input.right.left.left = new TreeNode(4);
        input.right.left.right = new TreeNode(4);
        var actual = _target.IsBalanced(input);
        Assert.True(actual);
    }

    [Fact]
    public void HasPathSumTest()
    {
        var root = new TreeNode(5);
        root.left = new TreeNode(4);
        root.left.left = new TreeNode(11);
        root.left.left.left = new TreeNode(7);
        root.left.left.right = new TreeNode(2);
        root.right = new TreeNode(8);
        root.right.left = new TreeNode(13);
        root.right.right = new TreeNode(4);
        root.right.right.right = new TreeNode(1);

        var expected = true;
        var actual = _target.HasPathSum(root, 22);
        Assert.Equal(expected, actual);
    }


    [Theory]
    [InlineData(1, "A")]
    [InlineData(28, "AB")]
    [InlineData(701, "ZY")]
    public void ConvertToTitleTest(int input, string expected)
    {
        var actual = _target.ConvertToTitle(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 3, 2, 3 }, 3)]
    [InlineData(new int[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
    [InlineData(new int[] { 8, 8, 7, 7, 7 }, 7)]
    public void MajorityElementTest(int[] input, int expected)
    {
        var actual = _target.MajorityElement(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("A", 1)]
    [InlineData("AB", 28)]
    [InlineData("ZY", 701)]
    public void TitleToNumberTest(string input, int expected)
    {
        var actual = _target.TitleToNumber(input);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void HammingWeightTest()
    {
        _target.HammingWeight(13);
    }

    [Theory]
    [InlineData("00000010100101000001111010011100", "00111001011110000010100101000000")]
    [InlineData("11111111111111111111111111111101", "10111111111111111111111111111111")]
    public void StringConvertUintTest(string inputS, string expectedS)
    {
        var input = _target.StringConvertUint(inputS);
        var expected = _target.StringConvertUint(expectedS);
        var actual = _target.ReverseBits(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("abc", "pqr", "apbqcr")]
    [InlineData("ab", "pqrs", "apbqrs")]
    [InlineData("abcd", "pq", "apbqcd")]
    public void MergeAlternately(string input1, string input2, string expected)
    {
        var actual = _target.MergeAlternately(input1, input2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 3, 2, 2, 3 }, 3, 2)]
    [InlineData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
    public void RemoveElementTest(int[] input, int val, int expected)
    {
        var actual = _target.RemoveElement(input, val);
        Assert.Equal(expected, actual);
    }



    [Theory]
    [InlineData("ABCABC", "ABC", "ABC")]
    [InlineData("ABABAB", "AB", "AB")]
    [InlineData("LEET", "CODE", "")]
    public void GcdOfStringsTest(string str1, string str2, string expected)
    {
        var actual = _target.GcdOfStrings(str1, str2);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 5)]
    [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
    public void MaxProfitTest(int[] input, int expected)
    {
        var actual = _target.MaxProfit(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("abc", "ahbgdc", true)]
    [InlineData("axc", "ahbgdc", false)]
    [InlineData("", "ahbgdc", true)]
    [InlineData("ab", "", false)]
    [InlineData("ace", "abcde", true)]
    [InlineData("aec", "abcde", false)]
    [InlineData("b", "c", false)]
    public void IsSubsequenceTest(string s, string t, bool expected)
    {
        var actual = _target.IsSubsequence(s, t);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("a", "b", false)]
    [InlineData("aa", "ab", false)]
    [InlineData("aa", "aab", true)]
    public void CanConstructTest(string ransomNote, string magazine, bool expected)
    {
        var actual = _target.CanConstruct(ransomNote, magazine);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("egg", "add", true)]
    [InlineData("foo", "bar", false)]
    [InlineData("paper", "title", true)]
    [InlineData("badc", "baba", false)]
    public void IsIsomorphicTest(string s, string t, bool expected)
    {
        var actual = _target.IsIsomorphic(s, t);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 0, 1, 2, 4, 5, 7 }, new string[] { "0->2", "4->5", "7" })]
    [InlineData(new int[] { 0, 2, 3, 4, 6, 8, 9 }, new string[] { "0", "2->4", "6", "8->9" })]
    [InlineData(new int[] { -2147483648, -2147483647, 2147483647 }, new string[] { "-2147483648->-2147483647", "2147483647" })]
    public void SummaryRangesTest(int[] nums, string[] expected)
    {
        var actual = _target.SummaryRanges(nums);
        Assert.Equal(expected.Length, actual.Count);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void InvertTreeTest_1()
    {
        var input = new TreeNode(4);
        input.left = new TreeNode(2);
        input.right = new TreeNode(7);
        input.left.left = new TreeNode(1);
        input.left.right = new TreeNode(3);
        input.right.left = new TreeNode(6);
        input.right.right = new TreeNode(9);

        var expected = new TreeNode(4);
        expected.left = new TreeNode(7);
        expected.right = new TreeNode(2);
        expected.left.left = new TreeNode(9);
        expected.left.right = new TreeNode(6);
        expected.right.left = new TreeNode(3);
        expected.right.right = new TreeNode(1);
        var actual = _target.InvertTree(input);
        CheckTreeNode(expected, actual);
    }

    [Fact]
    public void InvertTreeTest_2()
    {
        var input = new TreeNode(2);
        input.left = new TreeNode(1);
        input.right = new TreeNode(3);

        var expected = new TreeNode(2);
        expected.left = new TreeNode(3);
        expected.right = new TreeNode(1);
        var actual = _target.InvertTree(input);
        CheckTreeNode(expected, actual);
    }

    [Fact]
    public void InvertTreeTest_3()
    {
        TreeNode input = null;
        TreeNode expected = null;
        var actual = _target.InvertTree(input);
        CheckTreeNode(expected, actual);
    }

    private void CheckTreeNode(TreeNode expected, TreeNode actual)
    {
        if (expected is null && actual is null)
            return;
        Assert.NotNull(expected);
        Assert.NotNull(actual);
        Assert.Equal(expected.val, actual.val);
        CheckTreeNode(expected.left, actual.left);
        CheckTreeNode(expected.right, actual.right);
    }

    [Fact]
    public void AverageOfLevelsTest_1()
    {
        var input = new TreeNode(3);
        input.left = new TreeNode(9);
        input.right = new TreeNode(20);
        input.right.left = new TreeNode(15);
        input.right.right = new TreeNode(7);
        var expected = new List<double>() { 3, 14.5, 11 };
        var actual = _target.AverageOfLevels(input);
        Assert.Equal(expected.Count, actual.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Fact]
    public void AverageOfLevelsTest_2()
    {
        var input = new TreeNode(3);
        input.left = new TreeNode(9);
        input.right = new TreeNode(20);
        input.left.left = new TreeNode(15);
        input.left.right = new TreeNode(7);
        var expected = new List<double>() { 3, 14.5, 11 };
        var actual = _target.AverageOfLevels(input);
        Assert.Equal(expected.Count, actual.Count);
        for (int i = 0; i < expected.Count; i++)
        {
            Assert.Equal(expected[i], actual[i]);
        }
    }

    [Theory]
    [InlineData(4, 2)]
    [InlineData(8, 2)]
    [InlineData(200, 14)]
    public void MySqrtTest(int input, int expected)
    {
        var actual = _target.MySqrt(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new int[] { 1, 1, 2 }, new int[] { 1, 2 }, 2)]
    [InlineData(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new int[] { 0, 1, 2, 3, 4 }, 5)]
    public void RemoveDuplicatesTest(int[] nums, int[] expectedNums, int expectedLen)
    {
        var actual = _target.RemoveDuplicates(nums);
        Assert.Equal(expectedLen, actual);
        for (int i = 0; i < actual; i++)
        {
            Assert.Equal(expectedNums[i], nums[i]); ;
        }
    }

    [Theory]
    [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
    public void TwoSum(int[] nums, int target, int[] expected)
    {
        var actual = _target.TwoSum(nums, target);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(5, true)]
    [InlineData(4, false)]
    [InlineData(3, true)]
    public void CanWinNimTest(int n, bool expected)
    {
        var actual = _target.CanWinNim(n);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("11", "1", "100")]
    [InlineData("1010", "1011", "10101")]
    public void AddBinaryTest(string a, string b, string expected)
    {
        var actual = _target.AddBinary(a, b);
        Assert.Equal(expected, actual);
    }
}
