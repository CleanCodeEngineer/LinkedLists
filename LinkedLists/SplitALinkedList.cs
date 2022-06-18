namespace LinkedLists
{
    // Question from bytebybyte:
    // Given a linked list, write a function that divides it into two halves.
    // This function should modify the original list and then return a pointer to the second half of the list.
    // eg.
    // l = 1 -> 2 -> 3 -> 4 -> null
    //          ^               ^
    // divide(l) = 3 -> 4
    // l = 1 -> 2
    public class SplitALinkedList
    {
        //public class Node
        //{
        //    public int value;
        //    public Node next;
        //}

        public static LinkedListNode divide(LinkedListNode list)
        {
            if (list == null) return null;

            LinkedListNode runner = list.Next;

            while (runner != null)
            {
                runner = runner.Next;

                if (runner == null) break;

                runner = runner.Next;
                list = list.Next;
            }

            LinkedListNode toReturn = list.Next;
            list.Next = null;

            return toReturn;
        }
    }
}
