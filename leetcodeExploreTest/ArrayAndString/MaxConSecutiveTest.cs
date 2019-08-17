using System;
using Xunit;
using leetcodeExplore.ArrayAndString;

namespace leetcodeExploreTest.ArrayAndString
{
    public class MaxConSecutiveTest
    {
        public MaxConSecutiveTest()
        {
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 0, 1, 1, 1}, 3)]
        public void FindMaxConsecutiveOnesTest(int[] input, int expected)
        {
            var target = new MaxConsecutive();

            var actual = target.FindMaxConsecutiveOnes(input);

            Assert.Equal(expected, actual);
        }
    }
}
