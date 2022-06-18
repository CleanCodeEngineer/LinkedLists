using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    // 2.1 Remove Dups: Write code to remove duplicates from an unsorted linked list.
    // How would you solve this problem if a temporary buffer is not allowed?
    public static class RemoveDuplicates_Chapter2p1
    {
        public static void RemoveDuplicates(Node startNode)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            Node currentNode = new Node();
            currentNode = startNode;

            Node previousNode = new Node();
            previousNode = null;

            while (currentNode != null)
            {
                if (numbers.ContainsKey(currentNode.Value))
                {
                    previousNode.Next = currentNode.Next;
                    currentNode.Next = null;
                    currentNode = previousNode.Next;
                }
                else
                {
                    numbers.Add(currentNode.Value, 1);
                    previousNode = currentNode;
                    currentNode = currentNode.Next;
                }
            }
        }

        // Hash Table
        // O(N) time, where N is the number of elements in the linked list.
        public static void RemoveDuplicates1(Node node)
        {
            //HashSet<int> set = new HashSet<int>();
            Hashtable numbers = new Hashtable();

            Node previous = new Node();
            previous = null;

            while (node != null)
            {
                //if (set.Contains(node.Value))
                if (numbers.Contains(node.Value))
                {
                    previous.Next = node.Next;
                    node.Next = null;
                    node = previous.Next;
                }
                else
                {
                    //set.Add(node.Value);
                    numbers.Add(node.Value, 1);
                    previous = node;
                    node = node.Next;
                }
            }
        }

        // using 2 pointers and without temporary buffer
        public static void RemoveDuplicates2(Node node)
        {
            // current pointer iterates through the linked list
            Node current = node;

            // node pointer checks all subsequent nodes for duplicates
            node = node.Next;

            Node previous =  node;

            while (node != null || current != null)
            {
                if (node == null)
                {
                    current = current.Next;
                    node = current.Next;
                }

                if (node != null)
                {
                    if (node.Value == current.Value)
                    {
                        previous.Next = node.Next;
                        node.Next = null;
                        node = previous.Next;
                    }
                    else
                    {
                        //set.Add(node.Value);
                        previous = node;
                        node = node.Next;
                    }
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        // This code runs in O(1) space, but O(N^2) time.
        public static void deleteDups(Node head)
        {
            Node current = head;

            while (current != null)
            {
                /* Remove all future nodes that have the same value */
                Node runner = current;

                while (runner.Next != null)
                {
                    if (runner.Next.Value == current.Value)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }
        }
    }
}
