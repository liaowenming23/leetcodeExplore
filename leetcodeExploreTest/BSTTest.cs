using leetcodeExplore;
using leetcodeExplore.model;
using Xunit;

namespace leetcodeExploreTest
{
    public class BSTTest
    {
        private readonly BST _target;

        public BSTTest ()
        {
            _target = new BST ();
        }

        // private TreeNode Init_TradeNode (int[] input)
        // {
        //     if (input == null)
        //         return null;

        //     var result = new TreeNode (input[0]);

        //     var curr = result;

        //     for (int i = 1; i < input.Length; i++)
        //     {
        //         if (i / 2 == 1)
        //         {
        //             curr.left = new TreeNode (input[i]);
        //         }
        //         else
        //         {
        //             curr.
        //         }
        //     }
        // }

        [Fact]
        public void IsValidBST_Test1 ()
        {
            var input = new TreeNode (2);
            input.left = new TreeNode (1);
            input.right = new TreeNode (3);

            var expected = true;

            var actual = _target.IsValidBST (input);

            Assert.Equal (expected, actual);
        }

        [Fact]
        public void IsValidBST_Test2 ()
        {
            var input = new TreeNode (5);
            input.left = new TreeNode (1);
            input.right = new TreeNode (4);
            input.right.left = new TreeNode (3);
            input.right.right = new TreeNode (6);

            var expected = false;

            var actual = _target.IsValidBST (input);

            Assert.Equal (expected, actual);
        }

        [Fact]
        public void IsValidBST_Test3 ()
        {
            var input = new TreeNode (1);
            input.left = new TreeNode (1);

            var expected = false;

            var actual = _target.IsValidBST (input);

            Assert.Equal (expected, actual);
        }

        [Fact]
        public void IsValidBST_Test4 ()
        {
            var input = new TreeNode (10);
            input.left = new TreeNode (5);
            input.right = new TreeNode (11);
            input.right.left = new TreeNode (6);
            input.right.right = new TreeNode (12);

            var expected = false;

            var actual = _target.IsValidBST (input);

            Assert.Equal (expected, actual);
        }
    }
}