using System;
using System.Text;

namespace leetcodeExplore.ArrayAndString
{
  public class ReverseWords
  {
    public string Reverse (string s)
    {
      if (string.IsNullOrEmpty (s))
        return string.Empty;

      s = s.Trim();
      var strArray = s.Split (' ');

      var strBuilder = new StringBuilder ();
      for (int i = strArray.Length - 1; i >= 0; i--)
      {
        if (string.IsNullOrEmpty( strArray[i]))
          continue;

        strBuilder.Append($"{strArray[i]} ");
      }
      return strBuilder.ToString().TrimEnd();
    }
  }
}