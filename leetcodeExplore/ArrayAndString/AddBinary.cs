using System;
using System.Text;
namespace leetcodeExplore.ArrayAndString
{
    public class AddBinary
    {
        public string Add_Binary(string a, string b)
        {
            if (a.Length <= 0 && b.Length <= 0)
                return string.Empty;

            int maxLen = 0;
            int minLen = 0;
            char[] maxChar;
            char[] minChar;
            if (a.Length > b.Length)
            {
                maxLen = a.Length;
                minLen = b.Length;
                maxChar = a.ToCharArray();
                minChar = b.ToCharArray();
            }
            else
            {
                maxLen = b.Length;
                minLen = a.Length;
                maxChar = a.ToCharArray();
                minChar = b.ToCharArray();
            }
            bool carry = false;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < maxLen; i++)
            {
                if (i < minLen)
                {
                    var temp = (int)maxChar[i] + (int)minChar[i];
                    if (carry)
                        temp++;
                    if (temp == 3)
                    {
                        result.Append("1");
                        carry = true;
                    }
                    else if (temp == 2)
                    {
                        result.Append("0");
                        carry = true;
                    }
                    else if (temp == 1)
                    {
                        result.Append("1");
                        carry = false;
                    }
                    else if (temp == 0)
                    {
                        result.Append("0");
                        carry = false;
                    }
                }else{
                    if(carry){
                        var temp = (int)maxChar[i] + 1;
                        if(temp == 2){
                            result.Append("0");
                        }else if(temp == 1){
                            result.Append("1");
                            carry = false;
                        }else if(temp == 0){
                            result.Append("0");
                            carry = false;
                        }
                    }else{
                        result.Append(maxChar[i].ToString());
                    }
                }
            }
            return result.ToString();
        }
    }
}
