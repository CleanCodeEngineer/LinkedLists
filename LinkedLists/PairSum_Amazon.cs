namespace LinkedLists
{
    public class PairSum_Amazon
    {
        // Question: Calculate Max Pair (first and last node's value) Sum in a Linked List
        // O(n) time and O(1) space
        public static int PairSum(LinkedListNode head)
        {
            // calculate the size of the linked list
            int n = Size(head);
            // find half size of linked list
            int p = n / 2;

            // find the second half start node (x)
            LinkedListNode current = head;

            for (int i = 0; i < p - 1; i++)
            {
                current = current.Next;
            }

            // second half start node
            LinkedListNode x = current.Next;
            // modify the original list
            current.Next = null;

            // reverse second half of the linked list
            LinkedListNode otherHead = ReverseLinkedList(x);

            // compute the max sum
            int max = 0;

            while (head != null)
            {
                int sum = head.Value + otherHead.Value;

                if (sum > max)
                    max = sum;

                head = head.Next;
                otherHead = otherHead.Next;
            }

            return max;
        }

        // calculate the size of the linked list
        public static int Size(LinkedListNode head)
        {
            int size = 0;

            if (head == null)
                return 0;

            var node = head;

            while (node != null)
            {
                node = node.Next;
                size++;
            }

            return size;
        }

        // reverse the linked list
        public static LinkedListNode ReverseLinkedList(LinkedListNode head)
        {
            if (head == null)
                return null;

            LinkedListNode prev = null, current = head, next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev;

            return head;
        }
    }
}
