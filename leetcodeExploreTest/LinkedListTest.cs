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
      node.next.next = node;

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
      node.next.next.next.next.next.next.next = node.next;

      var expected = node.next;

      var actual = _target.DetectCycle (node);
      Assert.Equal (expected, actual);
    }

    [Fact]
    public void IntersectionLinkedList_Test1 ()
    {
      var intersectionNode = new ListNode (8);
      intersectionNode.next = new ListNode (4);
      intersectionNode.next.next = new ListNode (5);

      ListNode node1 = new ListNode (4);
      node1.next = new ListNode (1);
      node1.next.next = intersectionNode;

      ListNode node2 = new ListNode (5);
      node2.next = new ListNode (0);
      node2.next.next = new ListNode (1);
      node2.next.next.next = intersectionNode;

      var expected = intersectionNode;

      var actual = _target.GetIntersectionNode (node1, node2);
      Assert.Equal (expected, actual);
    }

    [Fact]
    public void IntersectionLinkedList_Test2 ()
    {
      ListNode node1 = new ListNode (2);
      node1.next = new ListNode (6);
      node1.next.next = new ListNode (4);

      ListNode node2 = new ListNode (1);
      node1.next = new ListNode (5);

      ListNode expected = null;

      var actual = _target.GetIntersectionNode (node1, node2);

      Assert.Equal (expected, actual);
    }

    [Fact]
    public void RemoveNthFromEnd_Test1 ()
    {
      ListNode input = new ListNode (1);
      input.next = new ListNode (2);
      input.next.next = new ListNode (3);
      input.next.next.next = new ListNode (4);
      input.next.next.next.next = new ListNode (5);

      var expected = new ListNode (1);
      expected.next = new ListNode (2);
      expected.next.next = new ListNode (3);
      expected.next.next.next = new ListNode (5);

      var actual = _target.RemoveNthFromEnd (input, 2);

      while (expected != null)
      {
        Assert.Equal (expected.val, actual.val);
        expected = expected.next;
        actual = actual.next;
      }
    }

    [Fact]
    public void RemoveNthFromEnd_Test ()
    {
      ListNode input = new ListNode (1);
      input.next = new ListNode(2);

      ListNode expected = new ListNode(2);

      var actual = _target.RemoveNthFromEnd (input, 2);

      while (expected != null)
      {
        Assert.Equal (expected.val, actual.val);
        expected = expected.next;
        actual = actual.next;
      }
    }
  }
}