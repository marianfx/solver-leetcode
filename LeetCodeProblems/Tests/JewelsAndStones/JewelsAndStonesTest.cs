using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.JewelsAndStones;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.JewelsAndStones
{
    [TestClass]
    public class JewelsAndStonesTest
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
        public void Given_Solution_When_TestingWithSampleInput_Then_ShouldGetGoodResult()
        {
            var result1 = solution.NumJewelsInStones("aA", "aAAbbbb");
            var result2 = solution.NumJewelsInStones("z", "ZZ");
            var result3 = solution.NumJewelsInStones("wmghx", "yia");
            result1.Should().Be(3);
            result2.Should().Be(0);
            result3.Should().Be(0);
        }
    }
}
