using System.Collections.Generic;
using leetcodeExplore.model;
using leetcodeExplore.Problems;
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
}
