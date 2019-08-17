using System;
using leetcodeExplore.ArrayAndString;
using Xunit;

namespace leetcodeExploreTest.ArrayAndString
{
    public class ArrayTwoSumTest
    {

        public ArrayTwoSumTest()
        {

        }

        [Theory]
        [InlineData(new int[] { -1, 0 }, -1, new int[] { 1, 2 })]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
        [InlineData(new int[] { 0, 0, 3, 4 }, 0, new int[] { 1, 2 })]
        [InlineData(new int[] { 5, 25, 75 }, 100, new int[] { 2, 3 })]
        public void TowSumTest(int[] input, int t, int[] expected)
        {
            var target = new ArraryTwoSum();

            var actaul = target.TowSum(input, t);

            Assert.Equal(expected, actaul);
        }
    }
}
