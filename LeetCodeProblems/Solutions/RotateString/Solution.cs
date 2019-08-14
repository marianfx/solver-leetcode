using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.RotateString
{
    public class Solution
    {
        public bool RotateString(string A, string B)
        {
            if (A.Length != B.Length)//impossible when different length
                return false;

            var N = A.Length;
            var positions = new int[100];
            for (var i = 0; i < N; i++)
                positions[i] = i - 1;//init as left-shifted, so I check the initial states in the first loop

            for (var j = 0; j < N; j++)//max shifts
            {
                //shift
                for (var i = 0; i < N; i++)
                    positions[i] = (positions[i] + 1) % N;

                //check
                var ok = true;
                for (var i = 0; i < N; i++)
                    if (A[positions[i]] != B[i])
                    {
                        //not yet finished, need to do more shifts
                        ok = false;
                        break;
                    }

                if (!ok)
                    continue;

                //finished
                return true;
            }

            return false;
        }
    }
}
