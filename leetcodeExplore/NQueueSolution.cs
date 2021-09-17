using System.Collections.Generic;

namespace leetcodeExplore
{
    public class NQueueSolution
    {
        private static int _maxRow;
        private static int _maxCol;
        private static int[] _tempSol;
        public List<int[]> Sol(int n)
        {
            _maxCol = n;
            _maxRow = n;
            _tempSol = new int[n];

            var sol = new List<int[]>();
            RunPuzzle(sol, 0);
            return sol;
        }

        public void RunPuzzle(List<int[]> sol, int y)
        {
            for (int x = 0; x < _maxCol; x++)
            {
                if (Check(_tempSol, y, x))
                {
                    _tempSol[y] = x;
                    if (y == _maxRow - 1)
                    {
                        sol.Add(_tempSol);
                        _tempSol[y] = 0;
                        return;
                    }
                    RunPuzzle(sol, y + 1);
                    _tempSol[y] = 0;
                }
            }
        }

        public bool Check(int[] sol, int y, int x)
        {
            for (int i = 0; i < y; i++)
            {
                var x1 = sol[y];
                var y1 = i;
                if (x1 == x)
                    return false;
                else if ((x - x1) == (y - y1)) // m = 1
                    return false;
                else if ((x1 - x) == (y - y1)) // m = -1
                    return false;
            }
            return true;
        }
    }
}