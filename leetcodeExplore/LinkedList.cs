using System.Collections;
using leetcodeExplore.model;

namespace leetcodeExplore
{

    public class LinkedList
    {
        #region Design Linked List
        public SinglyListNode node;
        public int Count = 0;

        /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
        public int Get(int index)
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
        public void AddAtHead(int val)
        {
            if (node == null)
            {
                node = new SinglyListNode(val);
            }
            else
            {
                SinglyListNode newHeadNode = new SinglyListNode(val);
                newHeadNode.next = node;
                this.node = newHeadNode;
            }
            Count++;
        }
        /** Append a node of value val to the last element of the linked list. */
        public void AddAtTail(int val)
        {
            var curr = this.node;
            while (curr.next != null)
            {
                curr = curr.next;
            }
            curr.next = new SinglyListNode(val);
            Count++;
        }

        /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
        public void AddAtIndex(int index, int val)
        {
            if (index == 0)
            {
                this.AddAtHead(val);
                return;
            }
            if (index == Count)
            {
                this.AddAtTail(val);
                return;

            }

            if (index < Count)
            {
                var tempList = this.node;
                for (int i = 0; i < index; i++)
                {
                    if (i == (index - 1))
                    {
                        var curr = new SinglyListNode(val);
                        curr.next = tempList.next;
                        tempList.next = curr;
                    }
                    else
                    {
                        tempList = tempList.next;
                    }
                }
            }

            Count++;
        }

        /** Delete the index-th node in the linked list, if the index is valid. */
        public void DeleteAtIndex(int index)
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
            public SinglyListNode(int x) { val = x; }
        }

        #endregion

        public bool HasCycle(ListNode head)
        {
            bool result = false;

            if (head == null)
                return result;
            Hashtable ht = new Hashtable();

            ht.Add(head.GetHashCode(), head);
            var next = head.next;
            while (next != null)
            {
                if (ht.ContainsKey(next.GetHashCode()))
                {
                    next = null;
                    result = true;
                }
                else
                {
                    ht.Add(next.GetHashCode(), next);
                    next = next.next;
                }
            }
            return result;
        }

        public ListNode DetectCycle(ListNode head)
        {
            if (head == null)
                return null;

            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                    break;
            }

            if (fast == null || fast.next == null)
                return null;
            slow = head;
            while (slow != fast)
            {
                slow = slow.next;
                fast = fast.next;
            }
            return fast;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode result;
            var c1 = GetCount(headA);
            var c2 = GetCount(headB);
            int totalCount = 0;
            if (c1 > c2)
            {
                totalCount = c1 - c2;
                result = GetIntersection(totalCount, headA, headB);
            }
            else
            {
                totalCount = c2 - c1;
                result = GetIntersection(totalCount, headB, headA);
            }
            return result;

            ListNode GetIntersection(int count, ListNode head1, ListNode head2)
            {
                var cur1 = head1;
                var cur2 = head2;

                for (int i = 0; i < count; i++)
                {
                    if (cur1 == null)
                        return null;

                    cur1 = cur1.next;
                }

                while (cur1 != null && cur2 != null)
                {
                    if (cur1 == cur2)
                        return cur1;

                    cur1 = cur1.next;
                    cur2 = cur2.next;
                }
                return null;
            }

            int GetCount(ListNode node)
            {
                int count = 0;
                var current = node;
                while (current != null)
                {
                    count++;
                    current = current.next;
                }
                return count;
            }

        }

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode first = new ListNode(0);
            first.next = head;
            ListNode secend = head;
            for (int i = 0; i < n; i++)
            {
                if (secend == null)
                    return null;
                secend = secend.next;
            }
            ListNode r = first;
            while (true)
            {
                if (secend == null)
                {
                    first.next = first.next.next;
                    break;
                }
                else
                {
                    first = first.next;
                    secend = secend.next;
                }
            }

            return r.next;
        }

        public ListNode ReverseList(ListNode head)
        {
            ListNode last = null;
            ListNode curr = head;
            while (curr != null)
            {
                var temp = curr.next;
                curr.next = last;
                last = curr;
                curr = temp;
            }
            return last;
        }

        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return null;

            head.next = RemoveElements(head.next, val);

            return head.val == val ? head.next : head;
        }

        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return head;

            ListNode odd = head;
            ListNode even = head.next;
            ListNode evenHead = even;

            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return head;
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
                return true;

            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast != null)
                slow = slow.next;

            slow = ReverseList(slow);
            fast = head;

            while (slow != null)
            {
                if (fast.val != slow.val)
                    return false;

                fast = fast.next;
                slow = slow.next;
            }
            return true;
        }

        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
            {
                return l2;
            }
            else if (l2 == null)
            {
                return l1;
            }
            else if (l1.val <= l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode(0);
            var p = l1;
            var q = l2;
            var curr = result;
            int carry = 0;

            while (p != null || q != null)
            {
                var sum = (p?.val ?? 0) + (q?.val ?? 0) + carry;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);

                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }

            if (carry > 0) curr.next = new ListNode(carry);

            return result.next;
        }
    }
}