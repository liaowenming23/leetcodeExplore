using System;
namespace leetcodeExplore.ArrayAndString
{
    public class MinimumSizeSubarray
    {

        public int MinSubArrayLen(int s, int[] nums)
        {
            int result = 0, r = 0, l = 0, sum = 0;
            int len = nums.Length;

            for (int i = 0; i < len; i++)
            {
                if (nums[i] >= s)
                    return 1;

                sum += nums[i];

                while(sum >= s && r >= l)
                {
                    if(result == 0 || result > r - l + 1)
                    {
                        result = r - l + 1;
                    }

                    sum -= nums[l];
                    l++;
                }
                r++;
            }
            return result;
        }
    }
}
