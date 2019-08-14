using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.ReverseWordsInAStringIII;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.ReverseWordsInAStringIII
{
    [TestClass]
    public class ReverseWordsInAStringIIITest
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
            var input = "Let's take LeetCode contest";
            var expected = "s'teL ekat edoCteeL tsetnoc";

            //when - running test with sample from leetcode
            var reverted = solution.ReverseWords(input);

            //then - results should be correct
            reverted.Should().Be(expected);
        }
    }
}
