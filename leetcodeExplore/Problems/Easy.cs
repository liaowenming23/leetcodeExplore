namespace leetcodeExplore.Problems
{
    public class Easy
    {
        public int SearchInsert(int[] nums, int target)
        {
            int len = nums.Length;
            var min = 0;
            var max = len - 1;
            int mid = len / 2;
            if (nums[max] < target)
                return len;
            if (nums[max] == target)
                return max;
            if (nums[min] >= target)
                return min;

            while (max - min > 1)
            {
                if (nums[mid] >= target)
                {
                    max = mid;
                    mid = (min + max) / 2;
                }
                else
                {
                    min = mid;
                    mid = (min + max) / 2;
                }
            }
            return max;
        }

    }
}