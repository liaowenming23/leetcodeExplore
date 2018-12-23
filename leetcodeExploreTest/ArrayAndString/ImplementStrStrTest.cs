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
