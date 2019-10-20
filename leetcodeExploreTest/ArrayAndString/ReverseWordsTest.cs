using System;
using leetcodeExplore.ArrayAndString;
using Xunit;

namespace leetcodeExploreTest.ArrayAndString
{
  public class ReverseWordsTest
  {
    [Theory]
    [InlineData ("the sky is blue", "blue is sky the")]
    [InlineData ("  hello world!  ", "world! hello")]
    [InlineData ("a good   example", "example good a")]
    public void Reverse (string input, string expected)
    {
      var target = new ReverseWords ();
      var actual = target.Reverse (input);

      Assert.Equal (expected, actual);
    }
  }
}