using System.Collections.Generic;
using leetcodeExplore;
using leetcodeExplore.model;
using Xunit;

namespace leetcodeExploreTest
{
    public class BinaryTreeTest
    {
        private readonly BinarhTree _target;
        public BinaryTreeTest ()
        {
            _target = new BinarhTree ();
        }

        [Fact]
        public void PreorderTraversal_Test1 ()
        {
            var input = new TreeNode (1);
            input.right = new TreeNode (2);
            input.right.left = new TreeNode (3);

            var expected = new List<int> { 1, 2, 3 };

            var actual = _target.PreorderTraversal (input);

            Assert.Equal (expected, actual);
        }
    }
}