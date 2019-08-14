using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.AddTwoNumbers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.AddTwoNumbers
{
    [TestClass]
    public class AddTwoNumbersTest
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
            var inputA = new ListNode(new int[] { 2, 4, 3 });
            var inputB = new ListNode(new int[] { 5, 6, 4 });
            var expected = new ListNode(new int[] { 7, 0, 8 });

            //when - running test with sample from leetcode
            var result = solution.AddTwoNumbers(inputA, inputB);

            //then - results should be correct
            result.Should().Be(expected);
        }
    }
}
