namespace leetcodeExplore
{
  public class LinkedList
  {
    #region Design Linked List
    public SinglyListNode node;
    public int Count = 0;
    

    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int Get (int index)
    {
      if (Count != 0 && index < Count)
      {
        SinglyListNode tempList = node;
        for (int i = 0; i < index; i++)
        {
          tempList = tempList.next;
        }
        return tempList.val;
      }
      else
        return -1;

    }

    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void AddAtHead (int val)
    {
      if (node == null)
      {
        node = new SinglyListNode (val);
      }
      else
      {
        SinglyListNode newHeadNode = new SinglyListNode (val);
        newHeadNode.next = node;
        this.node = newHeadNode;
      }
      Count++;
    }
    /** Append a node of value val to the last element of the linked list. */
    public void AddAtTail (int val)
    {
      var curr = this.node;
      while (curr.next != null)
      {
        curr = curr.next;
      }
      curr.next = new SinglyListNode (val);
      Count++;
    }

    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void AddAtIndex (int index, int val)
    {
      var tempList = this.node;
      if (index < Count)
      {
        for (int i = 0; i < index; i++)
        {
          if (i == (index - 1))
          {
            var curr = new SinglyListNode (val);
            curr.next = tempList.next;
            tempList.next = curr;
          }
          else
          {
            tempList = tempList.next;
          }
        }
      }
      else if (index == 0)
      {
        this.AddAtHead (val);
        return;
      }
      else if (index == Count)
      {
        this.AddAtTail (val);
        return;
      }
      else
        return;
      Count++;
    }

    /** Delete the index-th node in the linked list, if the index is valid. */
    public void DeleteAtIndex (int index)
    {
      var tempList = this.node;
      if (index == 0)
        this.node = this.node.next;
      else if (index < Count)
      {
        for (int i = 0; i < index; i++)
        {
          if (i == (index - 1))
          {
            var prev = tempList;
            tempList = tempList.next;
            prev.next = tempList.next;
          }
          else
          {
            tempList = tempList.next;
          }
        }
      }
      else
      {
        return;
      }
      Count--;
    }

    public class SinglyListNode
    {
      public int val;
      public SinglyListNode next;
      public SinglyListNode (int x) { val = x; }
    }

    #endregion

    public bool HasCycle (ListNode head)
    {
      bool[] test = new bool[256];
      var x = head;
      return true;
    }

  }

  public class ListNode
  {
    public int val;
    public ListNode next;
    public ListNode (int x)
    {
      val = x;
      next = null;
    }
  }
}