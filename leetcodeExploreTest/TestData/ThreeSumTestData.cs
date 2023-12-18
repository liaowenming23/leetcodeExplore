using System.Collections;
using System.Collections.Generic;

namespace leetcodeExploreTest.TestData;

public class ThreeSumTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{
            new int[]{-1,0,1,2,-1,-4},
            new List<List<int>>{
                new List<int>{-1,-1,2},
                new List<int>{-1,0,1}
            }
        };

        yield return new object[]{
            new int[]{0,1,1},
            new List<List<int>>{}
        };

        yield return new object[]{
            new int[]{0,0,0},
            new List<List<int>>{
                new List<int>{0,0,0}
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
