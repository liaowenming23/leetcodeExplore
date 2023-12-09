using System;
using System.Collections;
using System.Collections.Generic;

namespace leetcodeExploreTest.TestData;

public class SearchMatrixTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{
            new int[][]{
                new int[]{1,3,5,7},
                new int[]{10,11,16,20},
                new int[]{23,30,34,60}
            },
            3,
            true
        };
        yield return new object[]{
            new int[][]{
                new int[]{1,3,5,7},
                new int[]{10,11,16,20},
                new int[]{23,30,34,60}
            },
            12,
            false
        };
        yield return new object[]{
            new int[][]{
                new int[]{1,3,5,7},
                new int[]{10,11,16,20},
                new int[]{23,30,34,60}
            },
            61,
            false
        };
        yield return new object[]{
            new int[][]{
                new int[]{1,3,5,7},
                new int[]{10,11,16,20},
                new int[]{23,30,34,60}
            },
            60,
            true
        };
        yield return new object[]{
            new int[][]{
                new int[]{1,3,5,7},
                new int[]{10,11,16,20},
                new int[]{23,30,34,60}
            },
            20,
            true
        };
        yield return new object[]{
            new int[][]{
                new int[]{1}
            },
            1,
            true
        };
        yield return new object[]{
            new int[][]{
                new int[]{1, 2}
            },
            2,
            true
        };
        yield return new object[]{
            new int[][]{
                new int[]{1, 2}
            },
            3,
            false
        };
        yield return new object[]{
            new int[][]{
                new int[]{}
            },
            2,
            false
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
