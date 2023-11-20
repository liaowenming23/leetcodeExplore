using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Markup;

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
}
