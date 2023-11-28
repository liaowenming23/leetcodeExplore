using System.Collections;
using System.Collections.Generic;

namespace leetcodeExploreTest.TestData;

public class MergeTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{
            new int[][]{
                new int[]{1,3},
                new int[]{2,6},
                new int[]{8,10},
                new int[]{15,18}
            },
            new int[][]{
            new int[]{1,6},
            new int[]{8,10},
            new int[]{15,18}
            }
        };

        yield return new object[]{
            new int[][]{
                new int[]{1,4},
                new int[]{4,5}
            },
            new int[][]{
                new int[]{1,5},
            }
        };

        yield return new object[]{
            new int[][]{
                new int[]{1,7},
                new int[]{2,8},
                new int[]{3,9},
                new int[]{10, 21}
            },
            new int[][]{
                new int[]{1,9},
                new int[]{10,21}
            }
        };

        yield return new object[]{
            new int[][]{
                new int[]{1,4},
                new int[]{1,4}
            },
            new int[][]{
                new int[]{1,4}
            }
        };

        yield return new object[]{
            new int[][]{
                new int[]{1,4},
                new int[]{5,6}
            },
            new int[][]{
                new int[]{1,4},
                new int[]{5,6}
            }
        };
        yield return new object[]{
            new int[][]{
                new int[]{1,4},
                new int[]{0,4}
            },
            new int[][]{
                new int[]{0,4}
            }
        };
        yield return new object[]{
            new int[][]{
                new int[]{1,4},
                new int[]{0,3}
            },
            new int[][]{
                new int[]{0,4}
            }
        };
        yield return new object[]{
            new int[][]{
                new int[]{1,4},
                new int[]{0,0}
            },
            new int[][]{
                new int[]{0,0},
                new int[]{1,4}
            }
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}