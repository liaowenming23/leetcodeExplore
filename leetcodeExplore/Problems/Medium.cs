using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using leetcodeExplore.model;

namespace leetcodeExplore.Problems;

public class Medium
{
    public int LengthOfLongestSubstring(string s)
    {
        var dic = new Dictionary<char, int>();
        int l = 0, r = 0, result = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (dic.ContainsKey(s[i]))
            {
                var p = dic[s[i]];
                dic[s[i]] = i;
                result = Math.Max(result, r - l);
                l = Math.Max(l, p + 1);
            }
            else
                dic.TryAdd(s[i], i);
            r++;
        }
        result = Math.Max(result, r - l);
        return result;
    }


    public string LongestPalindrome(string s)
    {
        if (s.Length < 2)
            return s;
        int start = 0;
        int r1 = 0, r2 = 0;
        while (start < s.Length)
        {
            var end = s.Length - 1;
            while (end > start)
            {
                if (CheckPalindrome(start, end, s))
                {
                    if ((end - start) > (r2 - r1))
                    {
                        r1 = start;
                        r2 = end;
                    }
                }
                end--;
            }
            start++;
        }
        return s[r1..(r2 + 1)];
    }

    private bool CheckPalindrome(int s, int e, string v)
    {
        while (s < e)
        {
            if (v[s] == v[e])
            {
                s++;
                e--;
            }
            else
                return false;
        }
        return true;
    }

    /// <summary>
    /// 6. Zigzag Conversion
    /// </summary>
    /// <param name="s"></param>
    /// <param name="numRows"></param>
    /// <returns></returns>
    public string Convert(string s, int numRows)
    {
        if (numRows == 1)
            return s;
        var result = new char[s.Length];
        var range = (numRows * 2) - 2;
        int p = 0;
        for (int row = 0; row < numRows; row++)
        {
            var start = 0;
            while (start + row < s.Length)
            {
                result[p] = s[start + row];
                p++;
                if (row != 0 && row != (numRows - 1))
                {
                    var p1 = start + range - row;
                    if (p1 < s.Length)
                    {
                        result[p] = s[p1];
                        p++;
                    }
                }
                start += range;
            }
        }
        return new string(result);
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
            if (val > 0)
            {
                maxIndex = i;
                minIndex = i;
                result += val;
            }
        }
        return result;
    }

    /// <summary>
    /// 55. Jump Game
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public bool CanJump(int[] nums)
    {
        var current = nums.Length - 1;
        for (int i = current; i >= 0; i--)
        {
            var distance = current - i;
            if (distance <= nums[i])
            {
                current = i;
            }
        }
        return current == 0;
    }

    /// <summary>
    /// 36. Valid Sudoku
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public bool IsValidSudoku(char[][] board)
    {
        var set = new HashSet<char>();
        for (int i = 0; i < 9; i++)
        {
            if (!ValidCol(board, i, set) || !ValidRow(board, i, set))
                return false;
        }
        return true;
    }

    private bool ValidCol(char[][] board, int y, HashSet<char> set)
    {
        for (int i = 0; i < 9; i++)
        {
            if ((y % 3) == 1 && (i % 3) == 1 && !ValidSquare(board, i, y))
                return false;
            if (board[y][i] == '.')
                continue;
            if (set.Contains(board[y][i]))
                return false;
            set.Add(board[y][i]);
        }
        set.Clear();
        return true;
    }

    private bool ValidRow(char[][] board, int x, HashSet<char> set)
    {
        for (int i = 0; i < 9; i++)
        {
            if (board[i][x] == '.')
                continue;
            if (set.Contains(board[i][x]))
                return false;
            set.Add(board[i][x]);
        }
        set.Clear();
        return true;
    }

    private bool ValidSquare(char[][] board, int x, int y)
    {
        var set = new HashSet<char>();
        for (int i = x - 1; i < x + 2; i++)
        {
            for (int j = y - 1; j < y + 2; j++)
            {
                if (board[j][i] == '.')
                    continue;
                if (set.Contains(board[j][i]))
                    return false;
                set.Add(board[j][i]);
            }
        }
        set.Clear();
        return true;
    }

    /// <summary>
    /// 56. Merge Intervals
    /// </summary>
    /// <param name="intervals"></param>
    /// <returns></returns>
    public int[][] Merge(int[][] intervals)
    {
        if (intervals.Length <= 0)
            return intervals;
        Array.Sort(intervals, (l, r) => l[0] - r[0]);
        var result = new List<int[]>();
        int current = 0;
        result.Add(intervals[0]);
        for (int i = 1; i < intervals.Length; i++)
        {
            var cmin = result[current][0];
            var cmax = result[current][1];
            var min = intervals[i][0];
            var max = intervals[i][1];

            if (min <= cmax)
            {
                if (cmin > min)
                    result[current][0] = min;
                if (cmax < max)
                    result[current][1] = max;
            }
            else
            {
                current++;
                result.Add(intervals[i]);
            }
        }
        return result.ToArray();
    }

    private static readonly Dictionary<char, char[]> _numbersChars = new()
    {
        {'2', new char[]{ 'a','b','c'}},
        {'3', new char[]{ 'd','e','f'}},
        {'4', new char[]{ 'g','h','i'}},
        {'5', new char[]{ 'j','k','l'}},
        {'6', new char[]{ 'm','n','o'}},
        {'7', new char[]{ 'p','q','r','s'}},
        {'8', new char[]{ 't','u','v'}},
        {'9', new char[]{ 'w','x','y','z'}}
    };

    /// <summary>
    /// 17. Letter Combinations of a Phone Number
    /// </summary>
    /// <param name="digits"></param>
    /// <returns></returns>
    public IList<string> LetterCombinations(string digits)
    {
        var result = new List<string>();
        if (digits.Length == 0)
            return result;
        Combination(0, digits.Length - 1, digits, new char[digits.Length], result);
        return result;
    }

    public void Combination(int p, int end, string digits, char[] r, List<string> result)
    {
        char[] nc = _numbersChars[digits[p]];
        for (int i = 0; i < nc.Length; i++)
        {
            r[p] = nc[i];
            if (p == end)
            {
                result.Add(new string(r));
            }
            else Combination(p + 1, end, digits, r, result);

        }
    }

    /// <summary>
    /// 71. Simplify Path
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public string SimplifyPath(string path)
    {
        if (path.Length <= 1)
            return "/";
        var s = new Stack<string>();
        var fs = path.Split('/');
        foreach (var f in fs)
        {
            if (f.Length == 0 || f == ".")
                continue;
            else if (f == "..")
                s.TryPop(out var _);
            else s.Push(f);
        }
        var sb = new StringBuilder();
        if (s.Count == 0)
            return "/";
        while (s.Count != 0)
        {
            var f = s.Pop();
            sb.Insert(0, $"/{f}");
        }
        return sb.ToString();
    }

    /// <summary>
    /// 138. Copy List with Random Pointer
    /// </summary>
    /// <param name="head"></param>
    /// <returns></returns>
    public Node CopyRandomList(Node head)
    {
        var d = new Dictionary<int, Node>();
        Node newNode = null;
        DeepCopy(head, ref newNode, d);
        return newNode;
    }

    private void DeepCopy(Node node, ref Node newNode, Dictionary<int, Node> d)
    {
        if (node is null)
            return;
        if (!d.TryGetValue(node.GetHashCode(), out Node n))
        {
            newNode = new Node(node.val);
            d.TryAdd(node.GetHashCode(), newNode);
            CopyRandom(node, newNode, d);
        }
        else
        {
            newNode = n;
            CopyRandom(node, newNode, d);
        }
        if (node.next is not null)
            DeepCopy(node.next, ref newNode.next, d);
    }

    private void CopyRandom(Node node, Node newNode, Dictionary<int, Node> d)
    {
        if (node.random is not null)
        {
            if (!d.TryGetValue(node.random.GetHashCode(), out Node rn))
            {
                newNode.random = new Node(node.random.val);
                d.TryAdd(node.random.GetHashCode(), newNode.random);
            }
            else
            {
                newNode.random = rn;
            }
        }
    }

    /// <summary>
    /// 200. Number of Islands
    /// </summary>
    /// <param name="grid"></param>
    /// <returns></returns>
    public int NumIslands(char[][] grid)
    {
        if (grid.Length == 0 && grid[0].Length == 0)
            return 0;
        var maxX = grid[0].Length;
        var maxY = grid.Length;
        var result = 0;
        for (int i = 0; i < maxY; i++)
        {
            for (int j = 0; j < maxX; j++)
            {
                if (grid[i][j] != '1')
                    continue;
                var q = new Queue<(int, int)>();
                q.Enqueue((i, j));
                while (q.Any())
                {
                    var (y, x) = q.Dequeue();
                    var up = y - 1;
                    var down = y + 1;
                    var left = x - 1;
                    var right = x + 1;
                    if (up >= 0 && grid[up][x] == '1')
                        EnqueueAndReplace(q, up, x);
                    if (left >= 0 && grid[y][left] == '1')
                        EnqueueAndReplace(q, y, left);
                    if (down < maxY && grid[down][x] == '1')
                        EnqueueAndReplace(q, down, x);
                    if (right < maxX && grid[y][right] == '1')
                        EnqueueAndReplace(q, y, right);
                }
                result++;
            }
        }
        return result;
        void EnqueueAndReplace(Queue<(int, int)> qq, int yy, int xx)
        {
            grid[yy][xx] = '0';
            qq.Enqueue((yy, xx));
        }
    }

    /// <summary>
    /// 199. Binary Tree Right Side View
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> RightSideView(TreeNode root)
    {
        var result = new List<int>();
        if (root is null)
            return result;
        var q = new Queue<TreeNode>();
        q.Enqueue(root);
        while (q.Any())
        {
            var c = q.Count;
            var r = q.Dequeue();
            result.Add(r.val);
            SetNode(r);

            for (int i = 1; i < c; i++)
            {
                var n = q.Dequeue();
                SetNode(n);
            }
        }
        return result;

        void SetNode(TreeNode n)
        {
            if (n.right is not null)
                q.Enqueue(n.right);
            if (n.left is not null)
                q.Enqueue(n.left);
        }
    }

    /// <summary>
    /// 74. Search a 2D Matrix
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        int star = 0, end = rows * cols - 1;
        return Search(star, end);
        bool Search(int s, int e)
        {
            if (e < s)
                return false;
            var dh = (e - s) / 2;

            var h = s + dh;
            var r = h / cols;
            var c = h % cols;

            if (matrix[r][c] == target)
                return true;
            else if (matrix[r][c] > target)
                return Search(s, h - 1);
            else
                return Search(h + 1, e);
        }
    }

    /// <summary>
    /// 909. Snakes and Ladders
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    public int SnakesAndLadders(int[][] board)
    {
        var sr = board.Length - 1;
        var n = board.Length;
        var q = new Queue<int>();
        var g = n * n - 1;
        var result = 0;
        q.Enqueue(0);
        while (q.Any())
        {
            var total = q.Count;
            result++;
            for (int i = 0; i < total; i++)
            {
                var curr = q.Dequeue();
                for (int j = curr + 1; j <= curr + 6; j++)
                {
                    if (j == g)
                        return result;
                    var rr = j / n;
                    var r = sr - rr;
                    int c;

                    if (rr % 2 == 0)
                        c = j % n;
                    else
                        c = sr - (j % n);

                    if (board[r][c] > 0)
                    {
                        var mov = board[r][c] - 1;
                        if (mov == g)
                            return result;
                        q.Enqueue(mov);
                        board[r][c] = -2;
                    }
                    else if (board[r][c] == -1)
                    {
                        q.Enqueue(j);
                        board[r][c] = -2;
                    }
                }
            }
        }
        return -1;
    }

    /// <summary>
    /// 80. Remove Duplicates from Sorted Array II
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int RemoveDuplicates(int[] nums)
    {
        if (nums.Length < 3)
            return nums.Length;
        var index = 2;
        for (int i = 2; i < nums.Length; i++)
        {
            if (!IsDuplicate(i, i - index))
            {
                nums[index] = nums[i];
                index++;
            }
        }

        bool IsDuplicate(int p, int p1)
        {
            var p2 = (2 + p1);
            var p3 = (1 + p1);
            if (nums[p - p2] != nums[p - p3])
                return false;
            if (nums[p - p3] == nums[p])
                return true;
            return false;
        }
        return index;
    }

    /// <summary>
    /// 11. Container With Most Water
    /// </summary>
    /// <param name="height"></param>
    /// <returns></returns>
    public int MaxArea(int[] height)
    {
        int l = 0, r = height.Length - 1;
        var result = 0;
        while (l < r)
        {
            var lh = height[l];
            var rh = height[r];
            int cal;
            if (lh < rh)
            {
                cal = (r - l) * lh;
                l++;
            }
            else
            {
                cal = (r - l) * rh;
                r--;
            }
            if (cal > result)
                result = cal;
        }

        return result;
    }

    /// <summary>
    /// 15. 3Sum
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            int l = i + 1, r = nums.Length - 1;
            while (l < r)
            {
                var sum = nums[i] + nums[l] + nums[r];
                if (sum > 0)
                    r--;
                else if (sum < 0)
                    l++;
                else
                {
                    result.Add(new List<int> { nums[i], nums[l], nums[r] });
                    l++;
                    while (l < nums.Length && nums[l] == nums[l - 1])
                        l++;
                }

            }
        }
        return result;
    }

    /// <summary>
    /// 274. H-Index
    /// </summary>
    /// <param name="citations"></param>
    /// <returns></returns>
    public int HIndex(int[] citations)
    {
        var result = 0;
        Array.Sort(citations);
        var p = citations.Length;
        for (int i = p - 1; i >= 0; i--)
        {
            var d = p - i;
            if (citations[i] >= d)
                result = d;
        }
        return result;
    }

    /// <summary>
    /// 120. Triangle
    /// </summary>
    /// <param name="triangle"></param>
    /// <returns></returns>
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        if (triangle.Count == 0)
            return 0;
        if (triangle.Count == 1)
            return triangle[0][0];
        var len = triangle.Count - 2;
        MinRecursive(triangle, 0, len);
        return triangle[0][0];
    }

    private void MinRecursive(IList<IList<int>> triangle, int y, int len)
    {
        if (y < len)
            MinRecursive(triangle, y + 1, len);
        var nx = y + 1;
        for (int x = 0; x < nx; x++)
        {
            triangle[y][x] += Math.Min(triangle[nx][x], triangle[nx][x + 1]);
        }
    }

    public ListNode SortList(ListNode head)
    {
        if (head is null || head.next is null)
            return head;
        var left = head;
        var right = GetMid(head);
        var t = right.next;
        right.next = null;
        right = t;

        left = SortList(left);
        right = SortList(right);
        return MergeSortedList(left, right);
    }

    public ListNode GetMid(ListNode head)
    {
        var slow = head;
        var fast = head.next;
        while (fast is not null && fast.next is not null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }
        return slow;
    }

    public ListNode MergeSortedList(ListNode left, ListNode right)
    {
        var m = new ListNode();
        var tail = m;
        while (left is not null && right is not null)
        {
            if (left.val <= right.val)
            {
                tail.next = left;
                left = left.next;
            }
            else
            {
                tail.next = right;
                right = right.next;
            }
            tail = tail.next;
        }

        if (left is null)
            tail.next = right;
        if (right is null)
            tail.next = left;
        return m.next;
    }
}


public class Node
{
    public int val;
    public Node next;
    public Node random;

    public Node(int _val)
    {
        val = _val;
        next = null;
        random = null;
    }
}


public class RandomizedSet
{
    private HashSet<int> _hashSet;
    private Random _r;
    public RandomizedSet()
    {
        _hashSet = new HashSet<int>();
        _r = new Random();
    }

    public bool Insert(int val) => _hashSet.Add(val);
    public bool Remove(int val) => _hashSet.Remove(val);
    public int GetRandom() => _hashSet.ElementAt(_r.Next(_hashSet.Count));

}

public class Trie
{
    private HashSet<string> _words;

    public Trie()
    {
        _words = new();
    }

    public void Insert(string word)
    {
        if (_words.Contains(word))
            return;
        _words.Add(word);
    }

    public bool Search(string word)
    {
        return _words.TryGetValue(word, out var _);
    }

    public bool StartsWith(string prefix)
    {
        var l = prefix.Length - 1;
        foreach (var w in _words)
        {
            if (w.Length < l + 1)
                continue;
            var i = 0;
            while (i < l)
            {
                if (prefix[i] != w[i])
                    break;
                i++;
            }
            if (i != l)
                continue;
            if (prefix[i] == w[i])
                return true;
        }
        return false;
    }
}

public class Trie1
{

    TrieNode root;
    HashSet<string> strings;

    public Trie1()
    {
        root = new('R');
        strings = new();
    }

    public void Insert(string word)
    {

        strings.Add(word);
        TrieNode node = root;
        int i = 0;
        while (i < word.Length)
        {
            if (node.AlphaDict.ContainsKey(word[i]))
            {
                // Already exists
            }
            else
            {
                node.AlphaDict[word[i]] = new TrieNode(word[i]);
            }
            node = node.AlphaDict[word[i]];
            i++;
        }
    }

    public bool Search(string word)
    {
        return strings.Contains(word);

    }

    public bool StartsWith(string prefix)
    {
        int i = 0;
        TrieNode node = root;
        while (i < prefix.Length)
        {
            if (node.AlphaDict.TryGetValue(prefix[i], out node))
            {
                // Continue
            }
            else
            {
                return false;
            }

            i++;
        }
        return true;
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> AlphaDict { get; set; }

    public char Character { get; set; }

    public TrieNode(char c)
    {
        this.Character = c;
        this.AlphaDict = new();
    }
}

