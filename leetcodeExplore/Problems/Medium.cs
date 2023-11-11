using System;
using System.Collections.Generic;

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
        int start = 0, end = 0;
        int r1 = 0, r2 = 0;

        while (end < s.Length)
        {
            if (CheckPalindrome(start, end, s[start..end]))
            {
                r1 = start;
                r2 = end;
            }
            end++;
        }
        return s[r1..r2];
    }

    private bool CheckPalindrome(int s, int e, string v)
    {
        if (v[s] != v[e])
            return false;
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
}
