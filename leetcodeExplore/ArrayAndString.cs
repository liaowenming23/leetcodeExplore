using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace leetcodeExplore
{
  public class ArrayAndString
  {

    public string Add_Binary (string a, string b)
    {
      int aLen = a.Length;
      int bLen = b.Length;
      if (aLen == 0 && bLen == 0)
        return string.Empty;
      int len;
      if (aLen > bLen)
      {
        len = aLen;
      }
      else
      {
        len = bLen;
      }
      Stack stack = new Stack ();
      bool carry = false;
      for (int i = len - 1; i >= 0; i--)
      {
        int bTemp = 0;
        int aTemp = 0;
        if (aLen > 0)
          aTemp = (int) char.GetNumericValue (a[aLen - 1]);
        if (bLen > 0)
          bTemp = (int) char.GetNumericValue (b[bLen - 1]);
        var temp = aTemp + bTemp;
        if (carry)
          temp++;
        if (temp == 3)
        {
          stack.Push ('1');
          carry = true;
        }
        else if (temp == 2)
        {
          stack.Push ('0');
          carry = true;
        }
        else if (temp == 1)
        {
          stack.Push ('1');
          carry = false;
        }
        else if (temp == 0)
        {
          stack.Push ('0');
          carry = false;
        }
        aLen--;
        bLen--;
      }
      StringBuilder result = new StringBuilder ();
      if (carry)
        result.Append ('1');
      while (stack.Count > 0)
      {
        result.Append (stack.Pop ());
      }
      return result.ToString ();
    }

    public int[] TowSum (int[] numbers, int target)
    {
      int len = numbers.Length;
      int index1 = 0, index2 = 0;
      Dictionary<int, int> map = new Dictionary<int, int> ();
      for (int i = 0; i < len; i++)
      {
        int num = target - numbers[i];
        if (map.ContainsKey (num))
        {
          index1 = map.GetValueOrDefault (num) + 1;
          index2 = i + 1;
          break;
        }
        map.TryAdd (numbers[i], i);
      }
      return new int[] { index1, index2 };
    }

    public int PairSum (int[] nums)
    {
      QuickSort (nums, 0, nums.Length - 1);

      int sum = 0;
      for (int i = 0; i < nums.Length; i += 2)
      {
        sum += nums[i];
      }
      return sum;
    }

    public void QuickSort (int[] a, int left, int right)
    {
      if (left > right || left < 0 || right < 0)
        return;

      int index = Partition (a, left, right);

      if (index != -1)
      {
        QuickSort (a, left, index - 1);
        QuickSort (a, index + 1, right);
      }
    }

    private int Partition (int[] a, int left, int right)
    {
      if (left > right)
        return -1;

      int end = left;

      int pivot = a[right];

      for (int i = left; i < right; i++)
      {
        if (a[i] < pivot)
        {
          Swap (a, i, end);
          end++;
        }
      }

      Swap (a, end, right);

      return end;
    }

    private void Swap (int[] a, int left, int right)
    {
      if (left == right)
        return;
      int temp = a[left];
      a[left] = a[right];
      a[right] = temp;
    }

    public int StrStr (string haystack, string needle)
    {
      int needleLen = needle.Length;
      int haystackLen = haystack.Length;
      if (needleLen == 0)
        return 0;
      int result = 0;
      bool compared = false;
      for (int i = 0; i < haystackLen; i++)
      {
        if (haystack[i] == needle[0])
        {
          if ((i + needleLen) > haystackLen)
            return -1;

          compared = true;
          result = i;

          for (int j = 0; j < needleLen; j++)
          {

            if (haystack[i + j] != needle[j])
              compared = false;

          }
        }

        if (compared)
          break;
      }
      return compared ? result : -1;
    }

    public int FindMaxConsecutiveOnes (int[] nums)
    {
      int len = nums.Length;
      if (len == 0)
        return 0;

      int times = 0, max = 0;

      for (int i = 0; i < len; i++)
      {
        if (nums[i] != 1)
        {
          if (times > max)
            max = times;

          times = -1;
        }
        times++;
      }
      return max > times ? max : times;
    }

    public int MinSubArrayLen (int s, int[] nums)
    {
      int result = 0, r = 0, l = 0, sum = 0;
      int len = nums.Length;

      for (int i = 0; i < len; i++)
      {
        if (nums[i] >= s)
          return 1;

        sum += nums[i];

        while (sum >= s && r >= l)
        {
          if (result == 0 || result > r - l + 1)
          {
            result = r - l + 1;
          }

          sum -= nums[l];
          l++;
        }
        r++;
      }
      return result;
    }

    public IList<int> GetRow (int rowIndex)
    {
      var result = new List<int> ();
      result.Add (1);
      for (int i = 1; i < rowIndex + 1; i++)
      {
        result.Add (1);
        for (int j = i - 2; j >= 0; j--)
        {
          result[j + 1] = result[j + 1] + result[j];
        }
      }
      return result;
    }

    public int RemoveDuplicates (int[] nums)
    {
      if (nums.Length == 0)
        return 0;
      int tempIndex = 0;
      int result = 1;
      for (int i = 1; i < nums.Length; i++)
      {
        if (nums[tempIndex] == nums[i])
        {
          continue;
        }
        else
        {
          if (nums[tempIndex + 1] != nums[i])
            nums[tempIndex + 1] = nums[i];

          tempIndex++;
          result++;
        }
      }
      Array.Resize (ref nums, result);

      return result;
    }

    public int Remove (int[] nums, int val)
    {
      int len = nums.Length;
      int index = 0;

      for (int i = 0; i < len; i++)
      {
        if (nums[i] != val)
        {
          nums[index] = nums[i];
          index++;
        }
      }
      return index;
    }

    public void Reverse (char[] s)
    {
      if (s.Length == 0)
        return;
      var len = s.Length;
      var half = len / 2;

      for (int i = 0; i < half; i++)
      {
        var temp = s[(len - 1) - i];
        s[(len - 1) - i] = s[i];
        s[i] = temp;
      }

    }

    public string Reverse (string s)
    {
      if (string.IsNullOrEmpty (s))
        return string.Empty;

      s = s.Trim ();
      var strArray = s.Split (' ');

      var strBuilder = new StringBuilder ();
      for (int i = strArray.Length - 1; i >= 0; i--)
      {
        if (string.IsNullOrEmpty (strArray[i]))
          continue;

        strBuilder.Append ($"{strArray[i]} ");
      }
      return strBuilder.ToString ().TrimEnd ();
    }

    public string ReverseWords (string s)
    {
      if (string.IsNullOrEmpty (s))
        return s;

      var array = s.Split (' ');
      StringBuilder sb = new StringBuilder ();

      foreach (var a in array)
        sb.Append ($"{Convert(a)} ");
      // return "s'teL ekat edoCteeL tsetnoc";
      return sb.ToString ().Trim ();
    }

    private string Convert (string s)
    {
      var ch = s.ToCharArray ();

      int len = ch.Length - 1;

      for (int i = 0; i < ch.Length / 2; i++)
      {
        var temp1 = ch[i];
        ch[i] = ch[len - i];
        ch[len - i] = temp1;
      }

      return new string (ch);
    }

    public void Rotate (int[] nums, int k)
    {
      if (nums == null)
        return;

      int len = nums.Length;
      k = k % len;
      if (k == 0)
        return;

      Reverse (nums, 0, len - k - 1);
      Reverse (nums, len - k, len - 1);
      Reverse (nums, 0, len - 1);
    }

    private void Reverse (int[] nums, int i, int j)
    {
      while (i < j)
      {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
        i++;
        j--;
      }
    }

    public void MoveZeroes (int[] nums)
    {
      int len = nums.Length;
      if (len == 0)
        return;

      int i = 0, j = len - 1;

      while (i < j)
      {
        if (nums[i] != 0)
        {
          i++;
          continue;
        }

        for (int k = i; k < j; k++)
        {
          nums[k] = nums[k + 1];
        }
        nums[j] = 0;
        j--;
      }
    }
  }
}