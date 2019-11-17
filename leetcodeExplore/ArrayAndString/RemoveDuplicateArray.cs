using System;

namespace leetcodeExplore.ArrayAndString
{

  public class RemoveDuplicateArray
  {
    public int RemoveDuplicates (int[] nums)
    {
      if (nums.Length == 0)
        return 0;
      int tempIndex = 0;
      int result = 1;
      for (int i = 1; i < nums.Length; i++)
      {
        if (nums[tempIndex] == nums[i])
        {
          continue;
        }
        else
        {
          if (nums[tempIndex + 1] != nums[i])
            nums[tempIndex + 1] = nums[i];

          tempIndex++;
          result++;
        }
      }
      Array.Resize (ref nums, result);

      return result;
    }
  }
}