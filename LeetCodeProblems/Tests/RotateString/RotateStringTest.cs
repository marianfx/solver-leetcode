using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.RotateString;

namespace Tests.RotateString
{
    [TestClass]
    public class RotateStringTest
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
            //given = in test initialize, this does not require any more initializing

            //when - running test with sample from leetcode
            var result1 = solution.RotateString("abcde", "cdeab");
            var result2 = solution.RotateString("abcde", "abced");

            //then - results should be correct
            result1.Should().Be(true);
            result2.Should().Be(false);
        }
    }
}
