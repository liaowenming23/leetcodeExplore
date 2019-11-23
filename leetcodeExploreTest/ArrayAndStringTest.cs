using leetcodeExplore;
using Xunit;

namespace leetcodeExploreTest
{
  public class ArrayAndStringTest
  {
    private readonly ArrayAndString _target;

    public ArrayAndStringTest ()
    {
      _target = new ArrayAndString ();
    }

    [Theory]
    [InlineData ("11", "1", "100")]
    [InlineData ("1010", "1011", "10101")]
    public void Add_Binary_Test (string a, string b, string expected)
    {
      var actual = _target.Add_Binary (a, b);

      //Assert
      Assert.Equal (expected, actual);
    }

    [Theory]
    [InlineData (new int[] { 1, 4, 3, 2 }, 4)]
    public void PairSumTest (int[] input, int expected)
    {
      var actual = _target.PairSum (input);

      Assert.Equal (expected, actual);
    }

    [Theory]
    [InlineData (new int[] {-1, 0 }, -1, new int[] { 1, 2 })]
    [InlineData (new int[] { 2, 7, 11, 15 }, 9, new int[] { 1, 2 })]
    [InlineData (new int[] { 0, 0, 3, 4 }, 0, new int[] { 1, 2 })]
    [InlineData (new int[] { 5, 25, 75 }, 100, new int[] { 2, 3 })]
    public void TowSumTest (int[] input, int t, int[] expected)
    {
      var actaul = _target.TowSum (input, t);

      Assert.Equal (expected, actaul);
    }

    [Theory]
    [InlineData ("abcdefg", "cd", 2)]
    [InlineData ("aaaaa", "bba", -1)]
    [InlineData ("hello", "ll", 2)]
    [InlineData ("a", "", 0)]
    [InlineData ("", "a", -1)]
    [InlineData ("mississippi", "issip", 4)]
    public void StrStrTest (string haystack, string needle, int expected)
    {
      var actual = _target.StrStr (haystack, needle);

      Assert.Equal (expected, actual);
    }

    [Theory]
    [InlineData (new int[] { 1, 1, 0, 1, 1, 1 }, 3)]
    public void FindMaxConsecutiveOnesTest (int[] input, int expected)
    {
      var actual = _target.FindMaxConsecutiveOnes (input);

      Assert.Equal (expected, actual);
    }

    [Theory]
    [InlineData (7, new int[] { 2, 3, 1, 2, 4, 3 }, 2)]
    public void MinSubArrayLenTest (int s, int[] input, int expected)
    {
      var actual = _target.MinSubArrayLen (s, input);

      Assert.Equal (expected, actual);
    }

    [Fact]
    public void GetRowTest ()
    {
      var input = 4;

      var expected = new int[] { 1, 4, 6, 4, 1 };

      var actual = _target.GetRow (input);

      Assert.Equal (expected, actual);
    }

    [Theory]
    [InlineData (new int[] { }, new int[] { }, 0)]
    [InlineData (new int[] { 1, 1, 2 }, new int[] { 1, 2 }, 2)]
    [InlineData (new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, new int[] { 0, 1, 2, 3, 4 }, 5)]
    public void TestName (int[] input, int[] expected, int expectedLength)
    {
      var actual = _target.RemoveDuplicates (input);

      Assert.Equal (expectedLength, actual);
      for (int i = 0; i < actual; i++)
      {
        Assert.Equal (input[i], expected[i]);
      }
    }

    [Theory]
    [InlineData (new int[] { 3, 2, 2, 3 }, 3, 2)]
    [InlineData (new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, 5)]
    public void RemoveTest (int[] input, int val, int expected)
    {
      var actual = _target.Remove (input, val);

      Assert.Equal (expected, actual);
    }

    [Theory]
    [InlineData (new char[] { 'h', 'e', 'l', 'l', 'o' }, new char[] { 'o', 'l', 'l', 'e', 'h' })]
    [InlineData (new char[] { 'H', 'a', 'n', 'n', 'a', 'h' }, new char[] { 'h', 'a', 'n', 'n', 'a', 'H' })]
    public void ReverseTest (char[] input, char[] expected)
    {
      _target.Reverse (input);

      Assert.Equal (expected, input);
    }

    [Theory]
    [InlineData ("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc")]
    public void ReverseWords_Test (string input, string expected)
    {
      var actual = _target.ReverseWords (input);

      Assert.Equal (expected, actual);
    }

    [Theory]
    [InlineData ("the sky is blue", "blue is sky the")]
    [InlineData ("  hello world!  ", "world! hello")]
    [InlineData ("a good   example", "example good a")]
    public void Reverse (string input, string expected)
    {
      var actual = _target.Reverse (input);

      Assert.Equal (expected, actual);
    }

    [Theory]
    [InlineData (new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new int[] { 5, 6, 7, 1, 2, 3, 4 })]
    public void RotateTest (int[] input, int k, int[] expected)
    {
      _target.Rotate (input, k);

      for (int i = 0; i < input.Length; i++)
      {
        Assert.Equal (expected[i], input[i]);
      }
    }

    [Theory]
    [InlineData (new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
    [InlineData (new int[] { 0, 0, 1 }, new int[] { 1, 0, 0 })]
    public void MoveZeroesTest (int[] input, int[] expected)
    {
      _target.MoveZeroes (input);
      Assert.Equal (input, expected);
    }
  }
}