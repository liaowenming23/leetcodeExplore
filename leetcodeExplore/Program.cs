using System;
using System.Collections;
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
            //TestPlusOne();
            //TestFindDiagonalOrder();
            //TestSpiralOrder();
            //TestGenerate();
            //StackTest();
            // PadLeftTest();
            // Console.ReadKey ();
            var queen = 4;
            var target = new NQueueSolution();
            var actual = target.Sol(queen);
            foreach (var s in actual)
            {
                for (int y = 0; y < s.Length; y++)
                {
                    var px = s[y];
                    for (int x = 0; x < s.Length; x++)
                    {
                        if (x == px)
                            Console.Write("Q");
                        else
                            Console.Write(".");
                    }
                    Console.WriteLine();
                }
            }
        }

        #region LinkedList
        static void TestLinkedList()
        {

            LinkedList l = new LinkedList();
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
        #endregion

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
        static void TestFindDiagonalOrder()
        {
            int[,] a = new int[,]
            { { 1, 2, 3, }, { 4, 5, 6 }, { 7, 8, 9 }
            };
            int[,] b = new int[,]
            { { 3 }, { 2 }
            };
            //var r1 = FindDiagonalOrder(a);
            var r1 = FindDiagonalOrder(b);
            foreach (var item in r1)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        static int[] FindDiagonalOrder(int[,] matrix)
        {
            int y_len = matrix.GetLength(0);
            int x_len = matrix.GetLength(1);
            if (x_len == 0 && y_len == 0)
                return new int[0];
            int total_len = x_len * y_len;
            int[] result = new int[total_len];

            int direction = 0;
            if (x_len == 1)
                direction = 1;
            XY xy = new XY { x = 0, y = 0 };
            result[0] = matrix[xy.y, xy.x];
            for (int i = 1; i < total_len; i++)
            {
                if ((xy.y == 0 && direction == 2 && xy.x < (x_len - 1)) || (xy.y == (y_len - 1) && direction == 3))
                {
                    direction = 0;
                }
                else if ((xy.x == 0 && direction == 3) || (xy.x == (x_len - 1) && direction == 2))
                {
                    direction = 1;
                }
                else if (xy.x < (x_len - 1) && xy.y > 0 && direction < 2)
                {
                    direction = 2;
                }
                else if (xy.x > 0 && xy.y < (y_len - 1) && direction < 2)
                {
                    direction = 3;
                }

                switch (direction)
                {
                    case 0:
                        xy = ToRight(xy);
                        break;
                    case 1:
                        xy = ToDown(xy);
                        break;
                    case 2:
                        xy = ToRightUp(xy);
                        break;
                    case 3:
                        xy = ToLeftDown(xy);
                        break;
                }
                try
                {
                    result[i] = matrix[xy.y, xy.x];

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        //0
        static XY ToRight(XY xy)
        {
            xy.x++;
            return xy;
        }
        //1
        static XY ToDown(XY xy)
        {
            xy.y++;
            return xy;
        }
        //2
        static XY ToRightUp(XY xy)
        {
            xy.x++;
            xy.y--;
            return xy;
        }
        //3
        static XY ToLeftDown(XY xy)
        {
            xy.x--;
            xy.y++;
            return xy;
        }

        public class XY
        {
            public int x { get; set; }
            public int y { get; set; }
        }
        #endregion

        #region Spiral Matrix
        static void TestSpiralOrder()
        {
            int[,] a = new int[,]
            { { 1, 2, 3, }, { 4, 5, 6 }, { 7, 8, 9 }
            };

            int[,] b = new int[,]
            { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }
            };
            var r1 = SpiralOrder(b);
            foreach (var item in r1)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        public static IList<int> SpiralOrder(int[,] matrix)
        {

            int min_x = 0, min_y = 1;
            int max_y = matrix.GetLength(0);
            int max_x = matrix.GetLength(1);
            if (max_y == 0 && max_x == 0)
                return new int[0];
            int direction = 0;
            int total_len = max_x * max_y;
            int[] result = new int[total_len];
            XY xy = new XY { x = 0, y = 0 };
            result[0] = matrix[xy.y, xy.x];
            for (int i = 1; i < total_len; i++)
            {
                //right
                if (direction == 3 && xy.y == min_y)
                {
                    direction = 0;
                    min_y++;
                }
                //down
                else if (direction == 0 && xy.x == (max_x - 1))
                {
                    direction = 1;
                    max_x--;
                }
                //left
                else if (direction == 1 && xy.y == (max_y - 1))
                {
                    direction = 2;
                    max_y--;
                }
                //up
                else if (direction == 2 && xy.x == min_x)
                {
                    direction = 3;
                    min_x++;
                }
                switch (direction)
                {
                    case 0:
                        xy = ToRight(xy);
                        break;
                    case 1:
                        xy = ToDown(xy);
                        break;
                    case 2:
                        xy = ToLeft(xy);
                        break;
                    case 3:
                        xy = ToUp(xy);
                        break;
                }

                try
                {
                    result[i] = matrix[xy.y, xy.x];

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return result;
        }

        //2
        static XY ToLeft(XY xy)
        {
            xy.x--;
            return xy;
        }
        //3
        static XY ToUp(XY xy)
        {
            xy.y--;
            return xy;
        }
        #endregion

        #region Generate
        public static void TestGenerate()
        {
            var a = Generate(0);
            foreach (var row in a)
            {
                string str = string.Empty;
                foreach (var col in row)
                {
                    str += $"{col},";
                }
                Console.WriteLine(str);
            }
            Console.ReadKey();
        }

        public static IList<IList<int>> Generate(int numRows)
        {
            int[][] result = new int[numRows][];
            for (int i = 0; i < numRows; i++)
            {
                result[i] = new int[i + 1];
                for (int j = 0; j < (i + 1); j++)
                {
                    if ((i - 1) <= 0 || (j - 1) < 0 || (j + 1) > i)
                    {
                        result[i][j] = 1;
                    }
                    else
                    {
                        result[i][j] = result[i - 1][j - 1] + result[i - 1][j];
                    }
                }
            }
            return result;
        }

        public static void StackTest()
        {
            string a = "112233";
            Stack stack = new Stack();
            stack.Push(a.ToCharArray());
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        public static void PadLeftTest()
        {
            string a = "1";

            Console.WriteLine(a);
        }
    }
    #endregion

}