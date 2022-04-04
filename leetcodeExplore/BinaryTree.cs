using System.Collections.Generic;
using leetcodeExplore.model;

namespace leetcodeExplore
{
    public class BinaryTree
    {
        public IList<int> PreorderTraversal (TreeNode root)
        {
            List<int> result = new List<int> ();
            PreorderTraversal (root, result);
            return result;
        }

        public void PreorderTraversal (TreeNode root, List<int> result)
        {
            if (root != null)
            {
                result.Add (root.val);
                PreorderTraversal (root.left, result);
                PreorderTraversal (root.right, result);
            }
        }
    }
   
}