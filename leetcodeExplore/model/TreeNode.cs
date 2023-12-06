namespace leetcodeExplore.model;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    private int? v;

    public TreeNode(int? v)
    {
        this.v = v;
    }

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
