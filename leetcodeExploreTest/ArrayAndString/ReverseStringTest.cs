using System;
using Xunit;
using leetcodeExplore.ArrayAndString;

namespace leetcodeExploreTest.ArrayAndString
{
    public class ReverseStringTest
    {
        [Theory]
        [InlineData(new char[] { 'h', 'e','l','l','o' }, new char[] { 'o','l', 'l', 'e', 'h' })]
        [InlineData(new char[] { 'H', 'a', 'n', 'n', 'a', 'h' }, new char[] { 'h', 'a', 'n', 'n', 'a','H' })]
        public void ReverseTest(char[] input, char[] expected)
        {
            var target = new ReverseString();

            target.Reverse(input);

            Assert.Equal(expected, input);
        }
    }
}
