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
}
