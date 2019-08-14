using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Solutions.TwoSum;
using FluentAssertions;

namespace Tests.TwoSum
{
    [TestClass]
    public class TwoSumTest
    {
        #region Setup
        private Solution solution;

        [TestInitialize]
        public void SetUp()
        {
            solution = new Solution();
        }

        [TestCleanup]
        public void TearDown()
        {
            solution = null;
        }
        #endregion

        [TestMethod]
        public void Given_Solution_When_TestingWithSampleInput_Then_Should_GetGoodResult()
        {
            //given = in test initialize
            var input = new int[] { 2, 7, 11, 15 };
            var inputTarget = 9;
            var expected = new int[] { 0, 1 };
            var input2 = new int[] { 3, 2, 4 };
            var inputTarget2 = 6;
            var expected2 = new int[] { 1, 2 };
            var input3 = new int[] { -3, 4, 3, 90 };
            var inputTarget3 = 0;
            var expected3 = new int[] { 0, 2 };

            //when - running test with sample from leetcode
            var result = solution.TwoSum(input, inputTarget);
            var result2 = solution.TwoSum(input2, inputTarget2);
            var result3 = solution.TwoSum(input3, inputTarget3);

            //then - results should be correct
            result.Should().Equal(expected);
            result2.Should().Equal(expected2);
            result3.Should().Equal(expected3);
        }
    }
}
