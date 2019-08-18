using System;
using leetcodeExplore.ArrayAndString;
using Xunit;

namespace leetcodeExploreTest.ArrayAndString
{
    public class MinimumSizeSubarrayTest
    {
        [Theory]
        [InlineData(7, new int[] { 2,3,1,2,4,3}, 2)]
        public void MinSubArrayLenTest(int s, int[] input, int expected)
        {
            var target = new MinimumSizeSubarray();

            var actual = target.MinSubArrayLen(s, input);

            Assert.Equal(expected, actual);
        }
    }
}
