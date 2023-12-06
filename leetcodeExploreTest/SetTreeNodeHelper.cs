using System.Collections.Generic;
using leetcodeExplore.model;

namespace leetcodeExploreTest;

public static class SetTreeNodeHelper
{
    public static TreeNode Init(int?[] numbers)
    {
        if (numbers.Length == 0)
            return null;
        var result = new TreeNode((int)numbers[0]);
        var n = result;
        var q = new Queue<TreeNode>();

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] is not null)
            {
                n.left = new TreeNode((int)numbers[i]);
                q.Enqueue(n.left);
            }
            i++;
            if (i > numbers.Length)
                return result;
            if (numbers[i] is not null)
            {
                n.right = new TreeNode((int)numbers[i]);
                q.Enqueue(n.right);
            }
            n = q.Dequeue();
        }
        return result;
    }
}
