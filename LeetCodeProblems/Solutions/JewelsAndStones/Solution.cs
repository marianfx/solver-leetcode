using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.JewelsAndStones
{
    public class Solution
    {
        public int NumJewelsInStones(string J, string S)
        {
            var output = 0;
            var letters = new int[52];

            foreach (var c in S)
            {
                var index = (short)(c < 91 ? c - 65 : c - 71);
                letters[index]++;
            }

            foreach (var c in J)
            {
                var index = (short)(c < 91 ? c - 65 : c - 71);
                output += letters[index];
            }

            return output;
        }
    }
}
