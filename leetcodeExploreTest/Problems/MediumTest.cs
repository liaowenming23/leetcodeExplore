using leetcodeExplore.Problems;
using Xunit;

namespace leetcodeExploreTest.Problems
{
    public class MediumTest
    {
        private readonly Medium _target;

        public MediumTest()
        {
            _target = new();
        }

        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        [InlineData(" ", 1)]
        [InlineData("aab", 2)]
        [InlineData("abba", 2)]
        public void LengthOfLongestSubstringTest(string input, int expected)
        {
            var actual = _target.LengthOfLongestSubstring(input);
            Assert.Equal(expected, actual);
        }
    }
}