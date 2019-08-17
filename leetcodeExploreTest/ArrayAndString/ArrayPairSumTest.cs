using System;
using Xunit;
using leetcodeExplore.ArrayAndString;

namespace leetcodeExploreTest.ArrayAndString
{
    public class ArrayPairSumTest
    {
        [Theory]
        [InlineData(new int[] { 1, 4, 3, 2 }, 4)]
        public void PairSumTest(int[] input, int expected)
        {
            var targe = new ArrayPairSum();

            var actual = targe.PairSum(input);

            Assert.Equal(expected, actual);
        }
    }
}
