using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using leetcodeExplore.model;
using Microsoft.VisualBasic;

namespace leetcodeExplore.Problems;
public class Easy
{
    public int SearchInsert(int[] num, int target)
    {
        int len = num.Length;
        var min = 0;
        var max = len - 1;
        int mid = len / 2;
        if (num[max] < target)
            return len;
        if (num[max] == target)
            return max;
        if (num[min] >= target)
            return min;

        while (max - min > 1)
        {
            if (num[mid] >= target)
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

    public int HammingWeight(uint n)
    {
        // var bits = new BitArray(new int[] { (int)n });
        // var c = 0;
        // foreach (bool b in bits)
        // {
        //     if (b == true)
        //         c++;
        // }
        int res = 0;
        while (n > 0)
        {
            n &= (n - 1);
            res++;
        }
        return res;
        // n = (n & 0x55555555) + ((n >> 1) & 0x55555555);
        // n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
        // n = (n & 0x0f0f0f0f) + ((n >> 4) & 0x0f0f0f0f);
        // n = (n & 0x00ff00ff) + ((n >> 8) & 0x00ff00ff);
        // n = (n & 0x0000ffff) + ((n >> 16) & 0x0000ffff);
        // return (int)n;
    }

    /// <summary>
    /// 190. Reverse Bits
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public uint ReverseBits(uint n)
    {
        if (n == 0 || n == 0xffffffff) return n;
        // uint r = 0x00000000;
        // for (int i = 0; i < 32; i++)
        // {
        //     uint a = (n >> i) & 1;
        //     r = (r << 1) + a;
        // }
        uint r = 0x00000000;
        for (int i = 0; i < 32; i++)
        {
            r = (r << 1) + (n & 1);
            n = n >> 1;
        }
        return r;
    }


    public uint StringConvertUint(string s)
    {
        return Convert.ToUInt32(s, 2);
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

    public int SingleNumber(int[] nums)
    {
        int temp = 0;
        foreach (var n in nums)
            temp ^= n;

        return temp;
    }

    public bool IsPalindrome(string s)
    {
        var len = s.Length;
        int i = 0, j = len - 1;
        while (i < j)
        {
            if (!IsAlphanumeric(s[i]))
                i++;
            else if (!IsAlphanumeric(s[j]))
                j--;
            else if (s[i] == s[j] || EqualIgnoreCase(s[i], s[j]))
            {
                i++;
                j--;
            }
            else return false;
        }
        return true;
    }

    private bool EqualIgnoreCase(char a, char b)
    {
        var aa = ((byte)a);
        var bb = ((byte)b);
        if (aa < 58 || bb < 58)
            return false;
        var c = aa - bb;
        return c == 32 || c == -32;
    }

    private bool IsAlphanumeric(char c)
    {
        return (64 < ((byte)c) && ((byte)c) < 91) || (96 < ((byte)c) && ((byte)c) < 123) || (47 < ((byte)c) && ((byte)c) < 58);
    }

    public bool IsBalanced(TreeNode root)
    {
        if (root == null) return true;
        var l = Hight(root.left);
        var r = Hight(root.right);
        return System.Math.Abs(l - r) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }

    private int Hight(TreeNode node)
    {
        if (node == null)
            return 0;
        return System.Math.Max(Hight(node.left), Hight(node.right)) + 1;
    }
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        if (root is null)
            return false;
        if (root.left is null && root.right is null)
            return root.val - targetSum == 0;
        return HasPathSum(root.left, targetSum - root.val) || HasPathSum(root.right, targetSum - root.val);
    }

    /// <summary>
    /// 168. Excel Sheet Column Title
    /// </summary>
    /// <param name="columnNumber"></param>
    /// <returns></returns>
    public string ConvertToTitle(int columnNumber)
    {
        var sb = new StringBuilder();
        GetChart(sb, columnNumber);
        return sb.ToString();
    }

    private void GetChart(StringBuilder sb, int num)
    {
        var c = 26;
        num--;
        var r = num / c;
        var n = num - (r * c);
        if (r > 0)
        {
            GetChart(sb, r);
        }
        sb.Append((char)(65 + n));
    }

    /// <summary>
    /// 169. Majority Element
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int MajorityElement(int[] nums)
    {
        var dic = new Dictionary<int, int>();
        var moreThanHalfVal = nums.Length / 2;
        var currentNum = 0;
        var maxCnt = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int cnt = 0;
            var rsl = dic.TryGetValue(nums[i], out cnt);

            cnt++;
            if (cnt > moreThanHalfVal)
                return nums[i];

            if (rsl)
                dic[nums[i]] = cnt;
            else
                dic.TryAdd(nums[i], cnt);

            if (cnt > maxCnt)
            {
                currentNum = nums[i];
                maxCnt = cnt;
            }
        }
        return currentNum;
    }

    /// <summary>
    /// 171. Excel Sheet Column Number
    /// </summary>
    /// <param name="columnTitle"></param>
    /// <returns></returns>
    public int TitleToNumber(string columnTitle)
    {
        var len = columnTitle.Length;
        var result = 0;
        for (int i = len - 1, j = 0; i >= 0; i--, j++)
        {
            result += GetNumberByChar(columnTitle[i], j);
        }
        return result;
    }

    private int GetNumberByChar(char c, int position)
    {
        var i = (int)c - 64;
        return i * (int)Math.Pow(26, position);
    }

}
