using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.KeyboardRow
{
    public class Solution
    {
        public string[] FindWords(string[] words)
        {
            int N = words.Length;
            var output = new List<string>();//max same words
            var dictionary = new Dictionary<char, short>()
            {
                { 'Q', 1 },
                { 'W', 1 },
                { 'E', 1 },
                { 'R', 1 },
                { 'T', 1 },
                { 'Y', 1 },
                { 'U', 1 },
                { 'I', 1 },
                { 'O', 1 },
                { 'P', 1 },
                { 'A', 2 },
                { 'S', 2 },
                { 'D', 2 },
                { 'F', 2 },
                { 'G', 2 },
                { 'H', 2 },
                { 'J', 2 },
                { 'K', 2 },
                { 'L', 2 },
                { 'Z', 3 },
                { 'X', 3 },
                { 'C', 3 },
                { 'V', 3 },
                { 'B', 3 },
                { 'N', 3 },
                { 'M', 3 },
            };

            foreach (var word in words)
            {
                var rowId = dictionary[char.ToUpper(word[0])];
                var i = 1;
                for (; i < word.Length; i++)
                    if (dictionary[char.ToUpper(word[i])] != rowId)
                        break;//other row, don't add

                if (i == word.Length)
                    output.Add(word);
            }

            return output.ToArray();
        }
    }
}
