using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
        public ListNode(params int[] args)
        {
            var walker = this;
            if (args.Length == 0)
                return;

            walker.val = args[0];
            for (var i = 1; i < args.Length; i++)
            {
                walker.next = new ListNode(args[i]);
                walker = walker.next;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            var walker = this;
            while (walker != null)
            {
                output.Insert(0, walker.val);
                walker = walker.next;
            }
            return output.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(ListNode))
                return false;

            var walker1 = this;
            var walker2 = obj as ListNode;
            while (walker1 != null && walker2 != null)
            {
                if (walker1.val != walker2.val)
                    return false;

                walker1 = walker1.next;
                walker2 = walker2.next;
            }

            if (walker1 != null || walker2 != null)
                return false;

            return true;
        }
    }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // init root
            var sum = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0);
            var remainder = sum / 10;
            sum = sum % 10;
            ListNode pointerOut = new ListNode(sum);

            // go
            var pointerL1 = l1?.next;
            var pointerL2 = l2?.next;
            var tempPointer = pointerOut;
            while (pointerL1 != null || pointerL2 != null)
            {
                // add new node with sum of digits and keep remainder
                sum = remainder + (pointerL1 != null ? pointerL1.val : 0) + (pointerL2 != null ? pointerL2.val : 0);
                remainder = sum / 10;
                sum = sum % 10;
                tempPointer.next = new ListNode(sum);

                // go next
                tempPointer = tempPointer.next;
                pointerL1 = pointerL1?.next;
                pointerL2 = pointerL2?.next;
            }

            // check if remainder left
            if (remainder > 0)
                tempPointer.next = new ListNode(remainder);

            return pointerOut;
        }
    }
}
