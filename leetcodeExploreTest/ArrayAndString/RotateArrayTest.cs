using System;
using Xunit;
using leetcodeExplore.ArrayAndString;

namespace leetcodeExploreTest.ArrayAndString
{
  public class RotateArrayTest
  {

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
    public void RotateTest(int[] input, int k, int[] expected)
    {
      var target = new RotateArray();
      target.Rotate(input,k);

      for(int i = 0; i < input.Length; i++){
        Assert.Equal(expected[i],input[i]);
      }
    }
  }
}