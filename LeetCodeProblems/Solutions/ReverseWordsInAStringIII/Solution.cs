using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ReverseWordsInAStringIII
{
    public class Solution
    {
        public string ReverseWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return s;

            var sb = new StringBuilder();
            var tempStack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c != ' ')
                    tempStack.Push(c);

                if (c == ' ' || i == s.Length - 1)
                {
                    sb.Append(tempStack.ToArray());
                    tempStack.Clear();
                }

                if (c == ' ')
                    sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
