using System;

namespace leetcodeExplore.ArrayAndString
{
  public class RotateArray
  {
    public void Rotate(int[] nums, int k)
    {
      if (nums == null)
        return;

      int len = nums.Length;
      k = k % len;
      if (k == 0)
        return;

      Reverse(nums, 0, len - k - 1);
      Reverse(nums, len - k, len - 1);
      Reverse(nums, 0, len - 1);
    }

    private void Reverse(int[] nums, int i, int j)
    {
      while (i < j)
      {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
        i++;
        j--;
      }
    }
  }
}