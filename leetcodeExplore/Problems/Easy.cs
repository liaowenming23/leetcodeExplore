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

        public int MaxSubArray(int[] nums)
        {
            int max = int.MinValue, temp = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (temp < 0)
                    temp = nums[i];
                else
                    temp += nums[i];

                if (temp > max)
                    max = temp;
            }
            return max;
        }

        public int LengthOfLastWord(string s)
        {
            var strArr = s.ToCharArray();
            int temp = 0, len = 0;
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i] == ' ')
                    temp = 0;
                else
                    temp++;

                if (temp > 0)
                    len = temp;
            }
            return len;
        }
    }
}