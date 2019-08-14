using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solutions.MergeTwoBinaryTrees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.MergeTwoBinaryTrees
{
    [TestClass]
    public class MergeTwoBinaryTrees
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
            var oneNode = new TreeNode(1)
            {
                left = new TreeNode(3),
                right = new TreeNode(2)
            };
            oneNode.left.left = new TreeNode(5);

            var twoNode = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };
            twoNode.left.right = new TreeNode(4);
            twoNode.right.right = new TreeNode(7);


            //when - running test with sample from leetcode
            var resultTree = solution.MergeTrees(oneNode, twoNode);

            //then - results should be correct
            resultTree.val.Should().Be(3);
            resultTree.left.val.Should().Be(4);
            resultTree.right.val.Should().Be(5);
            resultTree.left.left.val.Should().Be(5);
            resultTree.left.right.val.Should().Be(4);
            resultTree.right.left.Should().Be(null);
            resultTree.right.right.val.Should().Be(7);
        }
    }
}
