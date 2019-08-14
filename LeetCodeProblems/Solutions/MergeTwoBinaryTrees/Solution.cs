using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.MergeTwoBinaryTrees
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public int MaxLevel { get; set; }

        public TreeNode(int x) { val = x; }

        public override string ToString()
        {
            return DisplayRSD();
        }

        private string DisplayRSD()
        {
            GetMaxLevelRecursive(this, 0);
            var spaces = MaxLevel - 1;
            var output = "";
            var toVisit = new Queue<TreeNode>(new TreeNode[] { this, null });
            while (toVisit.Count > 0)
            {
                var current = toVisit.Dequeue();
                // level change
                if (current == null)
                {
                    output += "\n";
                    spaces--;
                    toVisit.Enqueue(null);
                    if (toVisit.Peek() == null) break;//null after null
                    continue;
                }

                var valStr = current.val == -1000000 ? " " : current.val.ToString();
                output += valStr.PadLeft(spaces + 1).PadRight(spaces + 1);
                if (current.left != null)
                    toVisit.Enqueue(current.left);
                else if (current.val != -1000000)
                    toVisit.Enqueue(new TreeNode(-1000000));
                if (current.right != null)
                    toVisit.Enqueue(current.right);
                else if (current.val != -1000000)
                    toVisit.Enqueue(new TreeNode(-1000000));
            }

            return output;
        }

        private void GetMaxLevelRecursive(TreeNode node, int level)
        {
            if (node == null)
            {
                if (level > MaxLevel)
                    MaxLevel = level;
                return;
            }

            GetMaxLevelRecursive(node.left, level + 1);
            GetMaxLevelRecursive(node.right, level + 1);
        }
    }

    public class Solution
    {
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return null;

            var newTree = MergeCurrentNode(t1, t2);//build root
            var toVisit1 = new Stack<TreeNode>(new TreeNode[] { t1 });//will hold the nodes that need to be visited (not yet visited) from T1. Null means no node available here, But T2 has some.
            var toVisit2 = new Stack<TreeNode>(new TreeNode[] { t2 });//will hold the nodes that need to be visited (not yet visited) from T2. Null means no node available here, But T1 has some.
            var parents = new Stack<TreeNode>(new TreeNode[] { newTree });//will hold the nodes that need to be visited (not yet visited) from T2. Null means no node available here, But T1 has some.
            while (toVisit1.Count > 0 || toVisit2.Count > 0)
            {
                // the nodes in the stacks are already in the new node; will need to add only the children; they can pe null
                var currentT1 = toVisit1.Pop();
                var currentT2 = toVisit2.Pop();
                var currentParent = parents.Pop();

                //merge and push
                var newLeftNode = MergeCurrentNode(currentT1?.left, currentT2?.left);
                if (newLeftNode != null)
                {
                    currentParent.left = newLeftNode;
                    toVisit1.Push(currentT1?.left);
                    toVisit2.Push(currentT2?.left);
                    parents.Push(newLeftNode);
                }

                var newRightNode = MergeCurrentNode(currentT1?.right, currentT2?.right);
                if (newRightNode != null)
                {
                    currentParent.right = newRightNode;
                    toVisit1.Push(currentT1?.right);
                    toVisit2.Push(currentT2?.right);
                    parents.Push(newRightNode);
                }
            }

            return newTree;
        }

        public TreeNode MergeCurrentNode(TreeNode currentT1, TreeNode currentT2)
        {
            if (currentT1 == null && currentT2 == null)
                return null;

            var currentNodeValue = 0;
            if (currentT1 != null)
                currentNodeValue += currentT1.val;
            if (currentT2 != null)
                currentNodeValue += currentT2.val;

            return new TreeNode(currentNodeValue);
        }
    }
}
