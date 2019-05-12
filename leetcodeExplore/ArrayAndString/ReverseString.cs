using System;
namespace leetcodeExplore.ArrayAndString
{
    public class ReverseString
    {
        public void Reverse(char[] s)
        {
            if (s.Length == 0)
                return;
            var len = s.Length;
            var half = len / 2;

            for (int i = 0; i < half; i++)
            {
                var temp = s[(len-1) - i];
                s[(len - 1) - i] = s[i];
                s[i] = temp;
            }

        }
    }
}
