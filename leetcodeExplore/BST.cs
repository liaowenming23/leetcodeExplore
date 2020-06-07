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
    }
}