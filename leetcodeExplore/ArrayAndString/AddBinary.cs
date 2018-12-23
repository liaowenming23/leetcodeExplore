using System;
using System.Text;
using System.Collections;
namespace leetcodeExplore.ArrayAndString
{
    public class AddBinary
    {
        public string Add_Binary(string a, string b)
        {
            int aLen = a.Length;
            int bLen = b.Length;
            if (aLen == 0 && bLen == 0)
                return string.Empty;
            int len;
            if (aLen > bLen){
                len = aLen;
            }else{
                len = bLen;
            }
            Stack stack = new Stack();
            bool carry = false;
            for (int i = len - 1; i >= 0; i--)
            {
                int bTemp = 0;
                int aTemp = 0;
                if (aLen > 0)
                    aTemp =  (int)char.GetNumericValue(a[aLen - 1]);
                if (bLen > 0)
                    bTemp = (int)char.GetNumericValue(b[bLen - 1]);
                var temp = aTemp + bTemp;
                if (carry)
                    temp++;
                if (temp == 3)
                {
                    stack.Push('1');
                    carry = true;
                }
                else if (temp == 2)
                {
                    stack.Push('0');
                    carry = true;
                }
                else if (temp == 1)
                {
                    stack.Push('1');
                    carry = false;
                }
                else if (temp == 0)
                {
                    stack.Push('0');
                    carry = false;
                }
                aLen--;
                bLen--;
            }
            StringBuilder result = new StringBuilder();
            if (carry)
                result.Append('1');
            while(stack.Count > 0){
                result.Append(stack.Pop());
            }
            return result.ToString();
        }
    }
}
