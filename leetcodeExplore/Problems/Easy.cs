using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using leetcodeExplore.model;

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

    /// <summary>
    /// Merge Strings Alternately
    /// You are given two strings word1 and word2. Merge the strings by adding letters in alternating order, starting with word1. If a string is longer than the other, append the additional letters onto the end of the merged string.
    /// Return the merged string.
    /// </summary>
    /// <param name="word1"></param>
    /// <param name="word2"></param>
    /// <returns></returns>
    public string MergeAlternately(string word1, string word2)
    {
        if (word1.Length == 0)
            return word2;
        if (word2.Length == 0)
            return word1;
        var words = new StringBuilder(word1.Length + word2.Length);
        var l = Math.Max(word1.Length, word2.Length);
        for (int i = 0; i < l; i++)
        {
            if (i < word1.Length && i < word2.Length)
            {
                words.Append(word1[i]);
                words.Append(word2[i]);
            }
            else if (i < word1.Length && i >= word2.Length)
            {
                while (i < l)
                {
                    words.Append(word1[i]);
                    i++;
                }
            }
            else if (i < word2.Length && i >= word1.Length)
            {
                while (i < l)
                {
                    words.Append(word2[i]);
                    i++;
                }
            }
        }
        return words.ToString();
    }

    /// <summary>
    /// 27. Remove Element
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="val"></param>
    /// <returns></returns>
    public int RemoveElement(int[] nums, int val)
    {
        if (nums.Length == 0)
            return 0;
        int index = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[index] = nums[i];
                index++;
            }
        }
        return index;
    }



    public string GcdOfStrings(string str1, string str2)
    {
        if ((str1 + str2) == (str2 + str1))
        {
            var p = GCD(str1.Length, str2.Length % str1.Length);
            return str1[0..p];
        }
        return string.Empty;

        int GCD(int n1, int n2)
        {
            if (n2 == 0)
                return n1;
            return GCD(n2, n1 % n2);
        }
    }

    public int MaxProfit(int[] prices)
    {
        if (prices.Length == 0)
            return 0;
        var minIndex = 0;
        var maxIndex = 0;
        var result = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[maxIndex] < prices[i])
                maxIndex = i;
            if (prices[minIndex] > prices[i])
                minIndex = i;
            if (maxIndex <= minIndex)
            {
                maxIndex = minIndex;
                continue;
            }
            var val = prices[maxIndex] - prices[minIndex];
            if (val > result)
                result = val;
        }
        return result;
    }

    /// <summary>
    /// 392. Is Subsequence
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
            return true;
        if (t.Length == 0)
            return false;
        var p = -1;
        var e = s.Length - 1;
        for (int i = 0; i < t.Length; i++)
        {
            if (t[i] == s[p + 1])
                p++;

            if (p == e) return true;
        }
        return false;
    }


    /// <summary>
    /// 383. Ransom Note
    /// </summary>
    /// <param name="ransomNote"></param>
    /// <param name="magazine"></param>
    /// <returns></returns>
    public bool CanConstruct(string ransomNote, string magazine)
    {
        var map = new Dictionary<char, int>();
        foreach (var m in magazine)
        {
            if (map.ContainsKey(m))
                map[m] += 1;
            else
                map.TryAdd(m, 1);
        }

        foreach (var r in ransomNote)
        {
            if (map.ContainsKey(r))
            {
                map[r] -= 1;
                if (map[r] < 0)
                    return false;
            }
            else return false;
        }
        return true;
    }

    /// <summary>
    /// 205. Isomorphic Strings
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        var map1 = new Dictionary<char, char>();
        var map2 = new Dictionary<char, char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (map1.TryGetValue(s[i], out var c1))
            {
                if (t[i] != c1)
                    return false;
            }
            else
            {
                map1.TryAdd(s[i], t[i]);
            }

            if (map2.TryGetValue(t[i], out var c2))
            {
                if (s[i] != c2)
                    return false;
            }
            else
            {
                map2.TryAdd(t[i], s[i]);
            }
        }
        return true;
    }

    /// <summary>
    /// 228. Summary Ranges
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<string> SummaryRanges(int[] nums)
    {
        var result = new List<string>();
        if (nums.Length == 0)
            return result;
        int l = 0, r = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] + 1 != nums[i])
            {
                if (l == r)
                    result.Add(nums[l].ToString());
                else
                    result.Add($"{nums[l]}->{nums[r]}");
                l = i;
                r = i;
            }
            else
            {
                r = i;
            }
        }
        if (l == r)
            result.Add(nums[l].ToString());
        else
            result.Add($"{nums[l]}->{nums[r]}");
        return result;
    }

    /// <summary>
    /// Invert Binary Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public TreeNode InvertTree(TreeNode root)
    {
        Invert(root);
        return root;

        void Invert(TreeNode node)
        {
            if (node is null && node is null)
                return;
            var l = node.left;
            node.left = node.right;
            node.right = l;
            Invert(node.left);
            Invert(node.right);
        }
    }

    /// <summary>
    /// 637. Average of Levels in Binary Tree
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<double> AverageOfLevels(TreeNode root)
    {
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        var result = new List<double>();
        while (q.Any())
        {
            long t = 0;
            var s = q.Count;
            for (int i = 0; i < s; i++)
            {
                var n = q.Dequeue();
                t += n.val;
                if (n.left is not null)
                    q.Enqueue(n.left);
                if (n.right is not null)
                    q.Enqueue(n.right);
            }
            var a = t / (double)s;
            result.Add(a);
        }
        return result;
    }
    /// <summary>
    /// 69. Sqrt(x)
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    public int MySqrt(int x)
    {
        if (x == 0 || x == 1)
            return x;

        return Recursive(1, x);
        int Recursive(int ll, int rr)
        {
            if (ll > rr) return rr;
            var m = ll + (rr - ll) / 2;
            var square = (long)m * m;
            if (square == x) return m;
            if (square > x) return Recursive(ll, m - 1);
            else return Recursive(m + 1, rr);
        }
    }

    /// <summary>
    /// 26. Remove Duplicates from Sorted Array
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length < 2)
            return 1;
        var c = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[c])
                continue;
            else
            {
                c++;
                nums[c] = nums[i];
            }
        }
        return c + 1;
    }

    /// <summary>
    /// 1. Two Sum
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var r = target - nums[i];
            if (dict.TryGetValue(r, out var l))
            {
                return new int[] { l, i };
            }
            else
            {
                dict.TryAdd(nums[i], i);
            }
        }
        return new int[] { -1, -1 };
    }

    public bool CanWinNim(int n)
    {
        return n % 4 != 0;
    }
}
