using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.KeyboardRow;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.KeyboardRow
{
    [TestClass]
    public class KeyboardRowTest
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
            var input = new string[] { "Hello", "Alaska", "Dad", "Peace" };
            var expected = new string[] { "Alaska", "Dad" };

            //when - running test with sample from leetcode
            var reverted = solution.FindWords(input);

            //then - results should be correct
            reverted.Should().Equal(expected);
        }
    }
}
