using System;
using System.Collections.Generic;
using leetcodeExplore;
using leetcodeExplore.model;
using Xunit;

namespace leetcodeExploreTest
{
    public class BSTTest
    {
        private readonly BST _target;

        public BSTTest()
        {
            _target = new BST();
        }

        [Fact]
        public void IsValidBST_Test1()
        {
            var input = new TreeNode(2);
            input.left = new TreeNode(1);
            input.right = new TreeNode(3);

            var expected = true;

            var actual = _target.IsValidBST(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidBST_Test2()
        {
            var input = new TreeNode(5);
            input.left = new TreeNode(1);
            input.right = new TreeNode(4);
            input.right.left = new TreeNode(3);
            input.right.right = new TreeNode(6);

            var expected = false;

            var actual = _target.IsValidBST(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidBST_Test3()
        {
            var input = new TreeNode(1);
            input.left = new TreeNode(1);

            var expected = false;

            var actual = _target.IsValidBST(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidBST_Test4()
        {
            var input = new TreeNode(10);
            input.left = new TreeNode(5);
            input.right = new TreeNode(11);
            input.right.left = new TreeNode(6);
            input.right.right = new TreeNode(12);

            var expected = false;

            var actual = _target.IsValidBST(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void searchBST_Test1()
        {
            var input = new TreeNode(4);
            input.left = new TreeNode(2);
            input.right = new TreeNode(7);
            input.left.left = new TreeNode(1);
            input.left.right = new TreeNode(3);

            var expected = new TreeNode(2);
            expected.left = new TreeNode(1);
            expected.right = new TreeNode(3);
            var actual = _target.SearchBST(input, 2);
            Assert.Equal(GetTreeNode(expected), GetTreeNode(actual));
        }

        private List<int> GetTreeNode(TreeNode node)
        {
            var result = new List<int>();
            SetValue(node, result);
            return result;
        }

        private void SetValue(TreeNode node, List<int> data)
        {
            if (node is null)
                return;
            data.Add(node.val);
            SetValue(node.left, data);
            SetValue(node.right, data);
        }
    }

    public class BSTIteratorTest
    {
        [Fact]
        public void Case1()
        {
            var input = new TreeNode(7);
            input.left = new TreeNode(3);
            input.right = new TreeNode(15);
            input.right.left = new TreeNode(9);
            input.right.right = new TreeNode(20);

            var target = new BSTIterator(input);

            Assert.Equal(3, target.Next());
            Assert.Equal(7, target.Next());
            Assert.True(target.HasNext());
            Assert.Equal(9, target.Next());
            Assert.True(target.HasNext());
            Assert.Equal(15, target.Next());
            Assert.True(target.HasNext());
            Assert.Equal(20, target.Next());
            Assert.False(target.HasNext());
        }
    }
}