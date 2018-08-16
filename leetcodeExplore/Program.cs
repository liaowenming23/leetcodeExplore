using System;
using leetcodeExplore.lib;
using System.Collections.Generic;

namespace leetcodeExplore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //TestLinkedList();
            //TestPivotIndex();
            //TestDominantIndex();
            TestPlusOne();
        }

        static void TestLinkedList()
        {

            MyLinkedList l = new MyLinkedList();
            l.AddAtHead(38);
            l.AddAtHead(45);
            l.DeleteAtIndex(2);
            l.AddAtIndex(1, 24);
            l.AddAtTail(36);
            l.AddAtIndex(3, 72);
            l.AddAtTail(76);
            l.AddAtHead(7);
            l.AddAtHead(36);
            l.AddAtHead(34);
            l.AddAtTail(91);
            l.AddAtTail(69);
            l.AddAtHead(37);
            l.AddAtTail(38);
            l.AddAtTail(4);
            l.AddAtHead(66);
            l.AddAtTail(38);
            l.DeleteAtIndex(14);
            l.AddAtTail(12);
            l.AddAtTail(32);
            var a = l.Get(5);
            l.AddAtIndex(7, 5);
            l.AddAtHead(74);
            var b = l.Get(7);
            var c = l.Get(13);

            while (l.node != null)
            {
                Console.WriteLine(l.node.val);
                l.node = l.node.next;
            }
            //Console.WriteLine($"b : {b}");
            //Console.WriteLine($"c : {c}");
            //Console.WriteLine($"d : {d}");
            //Console.WriteLine($"e : {e}");

        }

        #region Find Pivot Index
        static void TestPivotIndex()
        {
            int[] a = { 1, 7, 3, 6, 5, 6 };
            int[] b = { 1, 2, 3 };
            var result = PivotIndex(a);
            var result1 = PivotIndex(b);
            Console.WriteLine(result);
            Console.WriteLine(result1);
            int[] c = { -1, -1, -1, -1, -1, -1 };
            var r3 = PivotIndex(c);
            Console.WriteLine(r3);
            int[] d = { -1, -1, -1, 0, 0, 0 };
            var r4 = PivotIndex(d);
            Console.WriteLine(r4);
            Console.ReadKey();
        }
        static int PivotIndex(int[] nums)
        {
            int t = 0, s = 0;
            foreach (int n in nums)
                t += n;
            for (int i = 0; i < nums.Length; s += nums[i++])
            {
                if (s * 2 == t - nums[i])
                    return i;
            }
            return -1;
        }
        #endregion

        #region Largest Number At Least Twice of Others
        static void TestDominantIndex()
        {
            int[] a = { 3, 6, 1, 0 };
            int[] b = { 0 };
            var r1 = DominantIndex(a);
            var r2 = DominantIndex(b);
            Console.WriteLine(r1);
            Console.WriteLine(r2);
            Console.ReadKey();
        }
        static int DominantIndex(int[] nums)
        {
            int largestNum = 0;
            int secondNum = 0;
            int resultIndex = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > largestNum)
                {
                    secondNum = largestNum;
                    largestNum = nums[i];
                    resultIndex = i;
                }
                else if (nums[i] > secondNum)
                {
                    secondNum = nums[i];
                }
            }
            if ((secondNum * 2) <= largestNum)
            {
                return resultIndex;
            }
            else
            {
                return -1;
            }

        }
        #endregion

        #region Plus One
        static void TestPlusOne()
        {
            int[] a = { 9 };
            var r1 = PlusOne(a);
            foreach (var item in r1)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        static int[] PlusOne(int[] digits)
        {
            int maxIndex = digits.Length - 1;
            digits[maxIndex] = digits[maxIndex] + 1;
            int cur = maxIndex;
            while (digits[cur] > 9)
            {
                digits[cur] = digits[cur] % 10;
                cur--;
                if (cur < 0)
                    break;
                digits[cur] = digits[cur] + 1;
            }
            if (cur == -1)
            {
                int[] result = new int[digits.Length + 1];
                result[0] = 1;
                for (int i = 1; i < digits.Length; i++)
                {
                    result[i] = digits[i];
                }
                return result;
            }
            return digits;
        }

        #endregion

        #region Diagonal Traverse
        static int[] FindDiagonalOrder(int[,] matrix)
        {
            int y_len = matrix.GetLength(0);
            int x_len = matrix.GetLength(1);
            //if (x_len == 0 || y_len == 0)
               
            int total_len = x_len * y_len;
            int[] result = new int[total_len];

            int x = 0;
            int y = 0;
            bool upperRight = true;
            for (int i = 0; i < total_len; i++)
            {
                while(x < 0 || y < 0){
                    upperRight = upperRight == true ? false : true;
                    if (upperRight)
                    {
                        y--;
                        x++;
                    }
                    else
                    {
                        y++;
                        x--;
                    }
                }
                int val = matrix[y, x];
                result[i] = val;
            }
            return result;
         
        }
        #endregion
    }
}
