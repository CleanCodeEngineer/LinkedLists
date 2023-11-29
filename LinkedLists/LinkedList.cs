using System;
namespace DataStructures
{
    // We use a linked list to store a sequence of objects, which consists of nodes. 
    // Each node has two parts: a Value and the Address of the next node in the list.
    // These nodes are linked together. we refer to the first node as the Head and the last node as the Tail.

    // RunTime Complexity:
    // LookUp by Value: O(n), by Address: O(n)
    // Insert: At the End: O(1), At the Beginning: O(1), In the middle: O(n) (finding the item, then updating the list)
    // Delete: From the Beginning: O(1), From the End: O(n), From the Middle: O(n)

    // A LinkedList is one of the fundamental data stucture that you need to master.
    // Here's how to build a linked list in C#:
    public class LinkedList
    {
        // We only need the Node class inside the LinkedList, and we don't want ouside access to it.
        private class Node
        {
            public Node(int value)
            {
                this.value = value;
            }

            public int value;
            // keep a reference to the next node
            public Node next;
        }

        // HEAD
        private Node first;
        // TAIL
        private Node last;

        // These are the essential methods required in a LinkedList.
        // addFirst
        public void addFirst(int item)
        {
            var node = new Node(item);

            // If the list is empty
            if (first == null)
                first = last = node;
            else
            {
                node.next = first;
                first = node;
            }
        }

        // addLast
        public void addLast(int item)
        {
            var node = new Node(item);

            if (isEmpty())
                first = last = node;
            else
            {
                last.next = node;
                last = node;
            }
        }

        // deleteFirst
        public void removeFirst()
        {
            // edge cases
            if (isEmpty())
                return;

            if (first == last)
            {
                first = last = null;
                return;
            }

            // [10 -> 20 -> 30]
            // first -> 10
            // first -> 20, [20 -> 30]
            // we need two new references, first and second
            // we keep 20 somewhere
            var second = first.next;
            // remove the first item by removing the link between 10 and 20
            first.next = null;

            first = second;
        }

        // deleteLast
        public void removeLast()
        {
            // [10 -> 20 -> 30]
            // last -> 30
            // we traverse this list from the beginning, and when we reach the item just before the last one,
            // we keep a reference to that node for updating the last item.
            // lst -> 20

            // edge case: empty list
            if (isEmpty())
                throw new Exception();

            // edge case: single item
            if (last == first)
            {
                last = first = null;
                return;
            }

            var previousNode = getPrevious(last);
            // Removing the link to the last item allows Garbage Collection to reclaim the memory occupied by this item.
            last = previousNode;
            last.next = null;
        }

        // contains
        public bool contains(int item)
        {
            Node currentNode = first;

            while (currentNode != null)
            {
                if (currentNode.value == item)
                    return true;

                currentNode = currentNode.next;
            }

            return false;
        }

        // indexOf
        public int indexOf(int item)
        {
            int index = 0;
            var currentNode = first;

            while (currentNode != null)
            {
                if (currentNode.value == item)
                    return index;

                currentNode = currentNode.next;
                index++;
            }

            return -1;
        }

        // size
        public int size()
        {
            if (isEmpty())
                return 0;

            if (first == last)
                return 1;

            Node currentNode = first;
            int size = 1;

            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
                size++;
            }

            return size;
        }

        // ToArray
        public int[] ToArray()
        {
            int[] array = new int[size()];
            int currentValue = first.value;
            Node nextNode = first.next;
            array[0] = currentValue;

            for (int i = 1; i < size(); i++)
            {
                array[i] = nextNode.value;
                nextNode = nextNode.next;
            }

            return array;
        }

        private Boolean isEmpty()
        {
            return first == null;
        }

        private Node getPrevious(Node node)
        {
            var currentNode = first;

            while (currentNode != null)
            {
                if (currentNode.next == node) return currentNode;
                currentNode = currentNode.next;
            }

            return null;
        }
    }
}
