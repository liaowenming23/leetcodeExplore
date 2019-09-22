using leetcodeExplore.ArrayAndString;
using Xunit;

namespace leetcodeExploreTest.ArrayAndString
{
  public class PascalTest
  {

    [Fact]
    public void GetRowTest ()
    {
      var input = 4;

      var expected = new int[] { 1, 4, 6,4, 1 };

      var target = new Pascal ();
      var actual = target.GetRow (input);

      Assert.Equal (expected, actual);
    }
  }
}