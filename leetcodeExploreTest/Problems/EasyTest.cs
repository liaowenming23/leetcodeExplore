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
    }
}