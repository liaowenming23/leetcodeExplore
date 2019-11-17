using leetcodeExplore.ArrayAndString;
using Xunit;

namespace leetcodeExploreTest.ArrayAndString
{
  public class RemoveDuplicateArrayTest
  {

    [Theory]
    [InlineData(new int[]{},new int[]{}, 0)]
    [InlineData (new int[] { 1, 1, 2 }, new int[]{1,2},2)]
    [InlineData(new int[]{0,0,1,1,1,2,2,3,3,4},new int[]{0,1,2,3,4},5)]
    public void TestName (int[] input, int[] expected,int expectedLength)
    {
      var target = new RemoveDuplicateArray ();

      var actual = target.RemoveDuplicates (input);

      Assert.Equal (expectedLength, actual);
      for(int i = 0; i < actual; i++){
        Assert.Equal(input[i],expected[i]);
      }
    }
  }
}