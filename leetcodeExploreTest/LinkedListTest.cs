using leetcodeExplore;
using Xunit;

namespace leetcodeExploreTest
{
  public class LinkedListTest
  {
    private readonly LinkedList _target;

    public LinkedListTest ()
    {
      _target = new LinkedList ();
    }

    [Fact]
    public void HasCycle_Test1 ()
    {
      ListNode node = new ListNode (3);
      node.next = new ListNode (2);
      node.next.next = new ListNode (0);
      node.next.next.next = new ListNode (-4);
      node.next.next.next.next = node.next;

      var actual = _target.HasCycle (node);

      Assert.True (actual);
    }

    [Fact]
    public void HasCycle_Test2 ()
    {
      ListNode node = new ListNode (1);
      node.next = new ListNode (2);
      node.next.next = node;

      var actual = _target.HasCycle (node);

      Assert.True (actual);
    }

    [Fact]
    public void HasCycle_Test3 ()
    {
      ListNode node = new ListNode (1);

      var actual = _target.HasCycle (node);

      Assert.False (actual);
    }

    [Fact]
    public void DetectCycle_Test1 ()
    {
      ListNode node = new ListNode (3);
      node.next = new ListNode (2);
      node.next.next = new ListNode (0);
      node.next.next.next = new ListNode (-4);
      node.next.next.next.next = node.next;

      var expected = node.next;

      var actual = _target.DetectCycle (node);
      Assert.Equal (expected, actual);
    }

    [Fact]
    public void DetectCycle_Test2 ()
    {
      ListNode node = new ListNode (1);
      node.next = new ListNode (2);
      node.next.next = node.next;

      var expected = node;

      var actual = _target.DetectCycle (node);
      Assert.Equal (expected, actual);
    }

    [Fact]
    public void DetectCycle_Test3 ()
    {
      ListNode node = new ListNode (1);
      node.next = new ListNode (2);
      node.next.next = new ListNode (3);
      node.next.next.next = new ListNode (4);
      node.next.next.next.next = new ListNode (5);
      node.next.next.next.next.next = new ListNode (6);
      node.next.next.next.next.next.next = new ListNode (7);
      node.next.next.next.next.next.next.next = node.next

      var expected = node.next;

      var actual = _target.DetectCycle (node);
      Assert.Equal (expected, actual);
    }
  }
}