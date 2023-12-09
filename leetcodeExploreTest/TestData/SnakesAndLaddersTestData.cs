using System.Collections;
using System.Collections.Generic;

namespace leetcodeExploreTest.TestData;

public class SnakesAndLaddersTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{
            new int[][]{
                new int[]{-1,-1,-1,-1,-1,-1},
                new int[]{-1,-1,-1,-1,-1,-1},
                new int[]{-1,-1,-1,-1,-1,-1},
                new int[]{-1,35,-1,-1,13,-1},
                new int[]{-1,-1,-1,-1,-1,-1},
                new int[]{-1,15,-1,-1,-1,-1},
            },
            4
        };
        yield return new object[]{
            new int[][]{
                new int[]{-1,-1},
                new int[]{-1,3},
            },
            1
        };
        yield return new object[]{
            new int[][]{
                new int[]{-1,-1,-1},
                new int[]{-1,9,8},
                new int[]{-1,8,9},
            },
            1
        };

        yield return new object[]{
            new int[][]{
                new int[]{-1,-1,2,-1},
                new int[]{2,13,15,-1},
                new int[]{-1,10,-1,-1},
                new int[]{-1,6,2,8},
            },
            2
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
