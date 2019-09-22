using System.Collections;
using System.Collections.Generic;

namespace leetcodeExplore.ArrayAndString
{
  public class Pascal
  {
    public IList<int> GetRow (int rowIndex)
    {
      var result = new List<int>();
      result.Add (1);
      for (int i = 1; i < rowIndex+1; i++)
      {
        result.Add(1);
        for(int j = i - 2; j >= 0;j--){
          result[j+1] = result[j+1] + result[j];
        }
      }
      return result;
    }
  }
}