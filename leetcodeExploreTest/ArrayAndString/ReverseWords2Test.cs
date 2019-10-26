using leetcodeExplore.ArrayAndString;
using Xunit;

namespace leetcodeExploreTest.ArrayAndString
{
    public class ReverseWords2Test
    {
        [Theory]
        [InlineData("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
        public void ReverseWords_Test(string input, string expected)
        {
            var target = new ReverseWords2();

            var actual = target.ReverseWords(input);

            Assert.Equal(expected,actual);
        }
    }
}