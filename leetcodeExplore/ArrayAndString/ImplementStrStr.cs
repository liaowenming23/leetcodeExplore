using System;
namespace leetcodeExplore.ArrayAndString
{
    public class ImplementStrStr
    {
        public int StrStr(string haystack, string needle)
        {
            int haystackLen = haystack.Length;
            int needleLen = needle.Length;
            int indexOf = -1;
            int compareInfex = 0;
            for (int i = 0; i < haystackLen; i++)
            {
                if(haystack[i] == needle[compareInfex] && indexOf < 0)
                {
                    indexOf = i;
                    compareInfex++;
                }
                else
                {
                    if(haystack[i] == needle[compareInfex])
                    {
                        compareInfex++;
                    }
                    else
                    {
                        indexOf = -1;
                        compareInfex = 0;
                    }
                }
                if(compareInfex >= needleLen)
                {
                    break;
                }
            }
            return indexOf;
        }
    }
}
