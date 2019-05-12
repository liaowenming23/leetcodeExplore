using System;
namespace leetcodeExplore.ArrayAndString
{
    public class ArrayPairSum
    {
        public int PairSum(int[] nums)
        {
            QuickSort(nums, 0, nums.Length - 1);

            int sum = 0;
            for (int i = 0; i < nums.Length; i+= 2)
            {
                sum += nums[i];
            }
            return sum;
        }

        public void QuickSort(int[] a, int left, int right)
        {
            if (left > right || left < 0 || right < 0)
                return;

            int index = Partition(a, left, right);

            if(index != -1)
            {
                QuickSort(a, left, index - 1);
                QuickSort(a, index + 1, right);
            }
        }

        private int Partition(int[] a, int left, int right)
        {
            if (left > right)
                return -1;

            int end = left;

            int pivot = a[right];

            for (int i = left; i < right; i++)
            {
                if(a[i] < pivot)
                {
                    Swap(a, i, end);
                    end++;
                }
            }

            Swap(a, end, right);

            return end;
        }

        private void Swap(int[] a, int left, int right)
        {
            if (left == right)
                return;
            int temp = a[left];
            a[left] = a[right];
            a[right] = temp;
        }

    }
}
