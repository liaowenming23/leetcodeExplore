using System;
using leetcodeExplore.ArrayAndString;
using Xunit;

namespace leetcodeExploreTest.ArrayAndString
{
    public class RemoveElementTest
    {
        public RemoveElementTest()
        {
        }

        [Theory]
        [InlineData(new int[] { 3,2,2,3}, 3, 2)]
        [InlineData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
        public void RemoveTest(int[] input, int val, int expected)
        {
            var target = new RemoveElement();
            var actual = target.Remove(input, val);

            Assert.Equal(expected, actual);
        }
    }
}
