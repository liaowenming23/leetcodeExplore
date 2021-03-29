using leetcodeExplore.Problems;
using Xunit;

namespace leetcodeExploreTest.Problems
{
    public class EasyTest
    {
        private readonly Easy _target;

        public EasyTest()
        {
            _target = new Easy();
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 5, 6 }, 5, 2)]
        [InlineData(new int[] { 1, 3, 5, 6 }, 2, 1)]
        [InlineData(new int[] { 1, 3, 5, 6 }, 7, 4)]
        [InlineData(new int[] { 1, 3, 5, 6 }, 0, 0)]
        public void SearchInsertTest(int[] nums, int target, int expected)
        {
            var actual = _target.SearchInsert(nums, target);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 5, 4, -1, 7, 8 }, 23)]
        [InlineData(new int[] { -1 }, -1)]
        public void MaxSubArrayTest(int[] nums, int expected)
        {
            var actual = _target.MaxSubArray(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Hello World", 5)]
        [InlineData(" ", 0)]
        [InlineData("a ", 1)]
        [InlineData("b   a    ", 1)]
        [InlineData("Today is a nice day", 3)]
        public void LengthOfLastWordTest(string s, int expected)
        {
            var actual = _target.LengthOfLastWord(s);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        public void ClimbStairsTest(int n, int expected)
        {
            var actual = _target.ClimbStairs(n);
            Assert.Equal(expected, actual);
        }
    }
}