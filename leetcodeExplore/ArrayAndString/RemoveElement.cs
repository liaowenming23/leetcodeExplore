using System;
namespace leetcodeExplore.ArrayAndString
{
    public class RemoveElement
    {
        public RemoveElement()
        {
        }

        public int Remove(int[] nums, int val)
        {
            int len = nums.Length;
            int index = 0;

            for (int i = 0; i < len; i++)
            {
                if(nums[i] != val)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }
            return index;
        }
    }
}
