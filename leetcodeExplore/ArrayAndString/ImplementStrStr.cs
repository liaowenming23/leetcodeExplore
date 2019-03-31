using System;
namespace leetcodeExplore.ArrayAndString
{
    public class ImplementStrStr
    {
        public int StrStr(string haystack, string needle)
        {
            int needleLen = needle.Length;
            int haystackLen = haystack.Length;
            if (needleLen == 0)
                return 0;
            int result = 0;
            bool compared = false;
            for (int i = 0; i < haystackLen; i++)
            {
                if(haystack[i] == needle[0])
                {
                    if ((i + needleLen) > haystackLen)
                        return -1;

                    compared = true;
                    result = i;

                    for (int j = 0; j < needleLen; j++)
                    {

                        if (haystack[i + j] != needle[j])
                            compared = false;
                         
                    }
                }

                if (compared)
                    break;
            }
            return compared ? result : - 1;
        }
    }
}
