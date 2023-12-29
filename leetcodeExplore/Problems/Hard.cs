using System.Collections.Generic;
using System.Text;

namespace leetcodeExplore.Problems;

public class Hard
{
    /// <summary>
    /// 135. Candy
    /// </summary>
    /// <param name="ratings"></param>
    /// <returns></returns>
    public int Candy(int[] ratings)
    {
        if (ratings.Length == 0)
            return 0;

        int result = 1, up = 0, down = 0, peak = 0;
        for (int i = 1; i < ratings.Length; i++)
        {
            var pre = ratings[i - 1];
            var curr = ratings[i];
            if (pre < curr)
            {
                up++;
                down = 0;
                peak = up;
                result += 1 + up;
            }
            else if (pre == curr)
            {
                up = 0;
                down = 0;
                peak = 0;
                result++;
            }
            else
            {
                up = 0;
                down++;
                result += 1 + down;
                if (peak >= down)
                    result--;
            }
        }
        return result;
    }

    /// <summary>
    /// 51. N-Queens
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public IList<IList<string>> SolveNQueens(int n)
    {
        // list is solutions
        // int[] is per queen position
        var solutions = new List<int[]>();
        var tempSol = new int[n];
        // start with first row 
        Puzzle(solutions, tempSol, n, 0);
        IList<IList<string>> result = new List<IList<string>>();

        var cs = new char[n];
        for (int i = 0; i < n; i++)
        {
            cs[i] = '.';
        }

        foreach (var s in solutions)
        {
            var board = new List<string>();
            for (int y = 0; y < s.Length; y++)
            {
                var x = s[y];
                cs[x] = 'Q';
                board.Add(new string(cs));
                cs[x] = '.';
            }
            result.Add(board);
        }
        return result;
    }

    private void Puzzle(List<int[]> solutions, int[] tempSol, int n, int y)
    {
        for (int x = 0; x < n; x++)
        {
            if (CheckPuzzleCondition(tempSol, x, y))
            {
                tempSol[y] = x; // put x position in row(y)
                if (y == tempSol.Length - 1)
                {
                    solutions.Add((int[])tempSol.Clone());
                    tempSol[y] = 0; // clean last row x position 
                    return;
                }
                Puzzle(solutions, tempSol, n, y + 1);
                tempSol[y] = 0; //clean recursive x position in row(y)
            }
        }
    }

    private static bool CheckPuzzleCondition(int[] sol, int x, int y)
    {
        for (int i = 0; i < y; i++)
        {
            var queenX = sol[i];
            var queenY = i;
            if (queenX == x) // same column
                return false;
            // queenY alway less than current y
            if ((y - queenY) == (x - queenX)) // slope m = 1 , check right
                return false;
            if ((y - queenY) == (queenX - x)) // check left 
                return false;
        }
        return true;
    }
}
