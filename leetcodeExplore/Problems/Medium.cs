using System;
using System.Collections.Generic;

namespace leetcodeExplore.Problems
{
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

    }
}