namespace LinkedLists
{
    public class deleteMiddleNode_Chapter2p3
    {
        // Time complexity: O(n)
        // Space complexity: O(1)
        public static LinkedListNode DeleteMiddleNode(LinkedListNode head)
        {
            if (head == null || head.Next == null)
                return head; // Nothing to delete

            LinkedListNode slow = head;
            LinkedListNode fast = head;
            LinkedListNode prev = null;

            // Use slow/fast pointer to find the middle
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                prev = slow;
                slow = slow.Next;
            }

            // Delete the middle node
            if (prev != null)
                prev.Next = slow.Next;

            return head;
        }
    }
}
