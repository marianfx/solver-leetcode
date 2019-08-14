using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Solutions.TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var mapping = new Hashtable();
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];
                if (mapping[num] == null)
                    mapping.Add(num, i);
                else if (num * 2 == target)//special case target/2 (others can't appear 2 times)
                    return new int[2] { (int)mapping[num], i };
            }

            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];

                var posibleSumPair = mapping[target - num];
                if (posibleSumPair != null && i != (int)posibleSumPair)//not the same num
                    return new int[2] { i, (int)posibleSumPair };
            }

            return new int[] { 0, 0 };//backup
        }
    }
}
