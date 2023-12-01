namespace leetcodeExplore.model;

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        this.val = x;
        this.next = null;
    }
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}
