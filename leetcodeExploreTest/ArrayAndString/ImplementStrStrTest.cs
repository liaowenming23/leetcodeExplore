using System;
using Xunit;
using leetcodeExplore.ArrayAndString;

namespace leetcodeExploreTest.ArrayAndString
{

    public class ImplementStrStrTest
    {
        [Theory]
        [InlineData("abcdefg","cd",2)]
        [InlineData("aaaaa", "bba", -1)]
        [InlineData("hello", "ll", 2)]
        [InlineData("a", "", 0)]
        [InlineData("", "a", -1)]
        [InlineData("mississippi", "issip", 4)]
        public void StrStrTest(string haystack, string needle, int expected)
        {
            //Arrange

            //Act
            var target = new ImplementStrStr();
            var actual = target.StrStr(haystack, needle);

            Assert.Equal(expected, actual);
        }
    }
}
