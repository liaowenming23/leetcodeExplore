using System.Collections;
using System.Collections.Generic;
using leetcodeExplore.model;

namespace leetcodeExplore
{
    public class BST
    {
        public bool IsValidBST (TreeNode root)
        {
            return ValidBST (root, null, null);
        }

        private bool ValidBST (TreeNode node, int? min_limit, int? max_limit)
        {
            if (node == null) return true;

            int val = node.val;

            if (min_limit != null && val <= min_limit) return false;
            if (max_limit != null && val >= max_limit) return false;

            if (!ValidBST (node.left, min_limit, val)) return false;
            if (!ValidBST (node.right, val, max_limit)) return false;

            return true;
        }

        public BST ()
        {

        }

        public BST (TreeNode root)
        {
            var list = new List<int> ();
            var stack = new Stack ();

        }
    }

    public class BSTIterator
    {
        private Stack<TreeNode> _stack;
        public BSTIterator (TreeNode root)
        {
            _stack = new Stack<TreeNode> ();
            this.leftToStack (root);
        }

        private void leftToStack (TreeNode root)
        {
            while (root != null)
            {
                _stack.Push (root);
                root = root.left;
            }
        }

        /** @return the next smallest number */
        public int Next ()
        {
            var next_node = _stack.Pop ();

            if (next_node.right != null)
            {
                this.leftToStack (next_node.right);
            }

            return next_node.val;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext ()
        {
            return _stack.Count > 0;
        }
    }
}