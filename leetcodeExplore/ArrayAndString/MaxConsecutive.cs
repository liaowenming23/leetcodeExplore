using System;
namespace leetcodeExplore.ArrayAndString
{
    public class MaxConsecutive
    {
        public MaxConsecutive()
        {
        }


        public int FindMaxConsecutiveOnes(int[] nums)
        { 
            int len = nums.Length;
            if (len == 0)
                return 0;

            int times = 0, max = 0;

            for (int i = 0; i < len; i++)
            {
                if(nums[i] != 1)
                {
                    if (times > max)
                        max = times;

                    times = -1;
                }
                times++;
            }
            return max > times ? max : times;
        }
    }
}
