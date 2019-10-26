using System.Text;

namespace leetcodeExplore.ArrayAndString
{
    public class ReverseWords2
    {
        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            var array = s.Split(' ');
            StringBuilder sb = new StringBuilder();

            foreach (var a in array)
                sb.Append($"{Convert(a)} ");
            // return "s'teL ekat edoCteeL tsetnoc";
            return sb.ToString().Trim();
        }

        private string Convert(string s)
        {
            var ch = s.ToCharArray();

            int len = ch.Length - 1;

            for (int i = 0; i < ch.Length / 2; i++)
            {
                var temp1 = ch[i];
                ch[i] = ch[len - i];
                ch[len - i] = temp1;
            }

            return new string(ch);
        }
    }
}