
using System;

namespace leetcodeExplore;

public class Codility
{
    public int solution(int[] A)
    {
        // Array.Sort(A);
        QuickSort(A, 0, A.Length - 1);
        var t = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] < 1)
                continue;
            if ((A[i] - t) > 1)
                return t + 1;
            t = A[i];
        }
        return t == 0 ? 1 : t + 1;
    }

    public int solution1(Tree T)
    {
        // Implement your solution here


        return Height(T) - 1;
    }

    public string solution2(string S)
    {
        for (int i = 0; i < S.Length - 1; i++)
        {
            if (S[i] > S[i + 1])
                return S.Substring(0, i) + S.Substring(i + 1, S.Length - (i + 1));
        }
        return S.Substring(0, S.Length - 1);
    }

    public int solution3(int[][] A)
    {
        return 0;
        // Implement your solution here
        // Array.Sort(A);
        // var l = 0;
        // var r = 1;
        // var end = A.Length - 1;
        // var result = A[end] - A[0];

        // while (l == A.Length - 2)
        // {
        //     while (r == A.Length - 1)
        //     {
        //         var leftVal = A[l] - A[0];
        //         var midVal = A[r] - A[l];
        //         var rightVal = A[A.Length - 1] - A[r];
        //         var m = 0;
        //         if (leftVal > midVal)
        //             m = leftVal;
        //         else
        //             m = midVal;

        //         if (rightVal > m)
        //             m = rightVal;

        //         if (result > m)
        //             result = m;
        //         r++;
        //     }
        //     l++;
        // }
        // return result;
    }

    public void QuickSort(int[] a, int left, int right)
    {
        if (left >= right)
            return;

        var pivot = Partition(a, left, right);
        QuickSort(a, left, pivot - 1);
        QuickSort(a, pivot + 1, right);
    }

    public int Partition(int[] a, int left, int right)
    {
        var pivot = a[right];
        var m = left;
        for (int i = left; i < right; i++)
        {
            if (a[i] < pivot)
            {
                Swap(a, m, i);
                m++;
            }
        }
        Swap(a, m, right);
        return m;
    }

    private void Swap(int[] a, int left, int right)
    {
        int temp = a[left];
        a[left] = a[right];
        a[right] = temp;
    }

    public int Height(Tree t)
    {
        if (t is null)
            return 0;
        var l = Height(t.l);
        var r = Height(t.r);
        if (l > r)
            return l + 1;
        else
            return r + 1;
    }
}


public class Tree
{
    public int x;
    public Tree l;
    public Tree r;

    public Tree(int val)
    {
        x = val;
    }
}