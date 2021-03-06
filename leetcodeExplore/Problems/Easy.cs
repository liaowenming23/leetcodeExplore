using System.Collections.Generic;
using leetcodeExplore.model;

namespace leetcodeExplore.Problems
{
    public class Easy
    {
        public int SearchInsert(int[] nums, int target)
        {
            int len = nums.Length;
            var min = 0;
            var max = len - 1;
            int mid = len / 2;
            if (nums[max] < target)
                return len;
            if (nums[max] == target)
                return max;
            if (nums[min] >= target)
                return min;

            while (max - min > 1)
            {
                if (nums[mid] >= target)
                {
                    max = mid;
                    mid = (min + max) / 2;
                }
                else
                {
                    min = mid;
                    mid = (min + max) / 2;
                }
            }
            return max;
        }

        public int MaxSubArray(int[] nums)
        {
            int max = int.MinValue, temp = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (temp < 0)
                    temp = nums[i];
                else
                    temp += nums[i];

                if (temp > max)
                    max = temp;
            }
            return max;
        }

        public int LengthOfLastWord(string s)
        {
            var strArr = s.ToCharArray();
            int temp = 0, len = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i] == ' ')
                    temp = 0;
                else
                    temp++;

                if (temp > 0)
                    len = temp;
            }
            return len;
        }

        public int ClimbStairs(int n)
        {
            int[] temp = new int[n + 1];
            return climbStairs(0, n, temp);
        }

        private int climbStairs(int i, int n, int[] temp)
        {
            if (i > n)
                return 0;
            if (i == n)
                return 1;
            if (temp[i] > 0)
                return temp[i];

            temp[i] = climbStairs(i + 1, n, temp) + climbStairs(i + 2, n, temp);

            return temp[i];
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            var temp = head;
            while (temp != null && temp.next != null)
            {
                if (temp.val.Equals(temp.next.val))
                    temp.next = temp.next.next;
                else
                    temp = temp.next;
            }
            return head;
        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int total = m + n - 1;

            if (n == 0)
                return;
            --n;
            --m;
            for (int i = total; i >= 0; i--)
            {
                if (n < 0)
                    return;

                if (m < 0)
                {
                    nums1[i] = nums2[n];
                    n--;
                }
                else if (nums2[n] >= nums1[m])
                {
                    nums1[i] = nums2[n];
                    n--;
                }
                else
                {
                    nums1[i] = nums1[m];
                    m--;
                }
            }
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();

            AddList(root, result);
            return result;
        }

        private void AddList(TreeNode node, List<int> list)
        {
            if (node is null)
                return;
            AddList(node.left, list);
            list.Add(node.val);
            AddList(node.right, list);
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p is null && q is null)
                return true;

            if (p is null || q is null)
                return false;

            if (!p.val.Equals(q.val))
                return false;

            return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root is null)
                return true;
            return IsSymmetricValue(root.left, root.right);
        }

        private bool IsSymmetricValue(TreeNode left, TreeNode right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            if (!left.val.Equals(right.val))
                return false;

            return IsSymmetricValue(left.left, right.right) && IsSymmetricValue(left.right, right.left);
        }

        public int MaxDepth(TreeNode root)
        {
            int dep = 0;
            return DepthValue(root, dep);
        }

        private int DepthValue(TreeNode node, int dep)
        {
            if (node is null)
                return dep;
            var nextDep = dep + 1;
            var tempA = DepthValue(node.left, nextDep);
            var tempB = DepthValue(node.right, nextDep);
            return tempA > tempB ? tempA : tempB;
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            return BSTToTreeNode(nums, 0, nums.Length - 1);
        }

        private TreeNode BSTToTreeNode(int[] nums, int s, int e)
        {
            if (s > e)
                return null;
            int mid = s + (e - s) / 2;
            var node = new TreeNode(nums[mid]);
            node.left = BSTToTreeNode(nums, s, mid - 1);
            node.right = BSTToTreeNode(nums, mid + 1, e);
            return node;
        }
    }
}