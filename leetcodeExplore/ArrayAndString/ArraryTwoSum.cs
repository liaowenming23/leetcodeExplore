using System;
using System.Collections.Generic;

namespace leetcodeExplore.ArrayAndString
{
    public class ArraryTwoSum
    {
        public ArraryTwoSum()
        {
        }

        public int[] TowSum(int[] numbers, int target)
        {
            int len = numbers.Length;
            int index1 = 0, index2 = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < len; i++)
            {
                int num = target - numbers[i];
                if (map.ContainsKey(num))
                {
                    index1 = map.GetValueOrDefault(num) + 1;
                    index2 = i + 1;
                    break;
                }
                map.Add(numbers[i], i);
            }
            return new int[] { index1, index2 };
        }
    }
}
