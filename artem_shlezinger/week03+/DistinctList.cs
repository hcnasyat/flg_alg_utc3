namespace Algorithms
{

    class DistinctList
    {
        internal class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode tempNode = head;

            while (tempNode != null && tempNode.next != null)
                if (tempNode.val == tempNode.next.val)
                    tempNode.next = tempNode.next.next;
                else
                    tempNode = tempNode.next;

            return head;
        }
    }
}
