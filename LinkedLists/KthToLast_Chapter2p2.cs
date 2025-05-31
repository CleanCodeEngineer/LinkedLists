namespace LinkedLists
{
    public class KthToLast_Chapter2p2
    {
        // Question: Given the head of a singly linked list and an integer k, write a method to return the k-th to last node in the list.
        // If k is 1, return the last node.
        // If k is equal to the length of the list, return the head node.
        // If k is greater than the length of the list, return null.
        public static LinkedListNode KthToLast(LinkedListNode head, int k)
        {
            if (head == null || k <= 0) return null;

            var node = head;
            var kthnode = head;

            /* Move node, k nodes into the list. */
            for (int i = 0; i < k; i++)
            {
                if (node == null) return null; // Out of bounds

                node = node.Next;
            }

            /* Move them at the same space. When node hits the end, kthnode will be at the right element. */
            while (node != null)
            {
                node = node.Next;
                kthnode = kthnode.Next;
            }

            return kthnode;
        }
    }
}
