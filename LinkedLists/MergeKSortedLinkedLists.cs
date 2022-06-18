using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class MergeKSortedLinkedLists
    {
        /**
         * Question: You are given an array of k Sorted linked-lists lists, each linked-list is sorted in ascending order [2,3,4,5,7]. 
         * Merge all the linked-lists into one sorted linked-list and return it. 
         * 
         * Class
         *  Node:
         * 		val: number
         * 		next: Node || null
         * Node(int val = 0, Node next = null)
         * 
         * EX: 
         * Node 1: 1->3->5 -> null
         * Node 2: 2->4->6 -> null
         * Result: 1->2->3->4->5->6 -> null
         * 
         * 
         * Duplicates ok
         * Node 1: 1->3->5
         * Node 2: 2->4->6
         * Node 3: 1->10
         * Result: 1->1->2->3->4->5->6->10
         *
         * NO Constraints on Performance and Memory
         */

        // Priority Queue, Add an element to a priority queue will take LogN time.
        // And the priority queue will always going to be length k. 
        // And removing from the priority queue takes constant time.
        // Min-Heap

        // we're defining a class to have 3 fields: LinkedList number, Node in the LinkedList and the Value of that Node in that LinkedList 
        public class QueueNode
        {
            public int LinkedList { get; set; }
            public LinkedListNode Node { get; set; }
            public int Value { get; set; }

            public QueueNode(int linkedList, LinkedListNode node, int value)
            {
                LinkedList = linkedList;
                Node = node;
                Value = value;
            }
        }

        // * Node 1: 1->3->5-> null
        // * Node 2: 2->4->6-> null
        public static LinkedListNode merge(List<LinkedListNode> linkedListNodes)
        {
            // Edge Case
            if (linkedListNodes.Count == 0) return null;

            // Using built-in Priority Queue class in C# in .NET 6+ (Not supported in current project, .NET version: 5)
            // Priority Queue of QueueNode element and its priority (value in each linkedlist node because it's sorted)
            PriorityQueue pq = new PriorityQueue(linkedListNodes.Count);

            int resultSize = 0;

            for (int i = 0; i < linkedListNodes.Count; i++)
            {
                resultSize += PairSum_Amazon.Size(linkedListNodes[i]);

                pq.Enqueue(new QueueNode(i, linkedListNodes[i], linkedListNodes[i].Value), linkedListNodes[i].Value);
            }

            // defining the result linked list
            LinkedListNode newNode = new LinkedListNode(0);
            LinkedListNode newhead = newNode;

            for (int i = 0; pq.Count != 0; i++)
            {
                // every time we remove the min number in the priority queue
                QueueNode n = pq.Dequeue();

                // create a new node to add to the new linked list
                LinkedListNode node = new LinkedListNode(n.Value);
                newNode.Next = node;

                // point to the next in the new linked list nodes
                newNode = newNode.Next;

                resultSize--;

                // move to the next pointer in the poped linkd list nodes
                LinkedListNode currentLinkedListNode = n.Node.Next;

                if (resultSize > 0 && currentLinkedListNode != null)
                {
                    pq.Enqueue(new QueueNode(n.LinkedList, currentLinkedListNode, currentLinkedListNode.Value), currentLinkedListNode.Value);
                }
            }

            return newhead.Next;
        }

        // Node 1: 1->3->5 -> null
        // Node 2: 2->4->6 -> null
        // merge 2 sorted LinkedLists
        // merge(1,2)
        // node1 = 1, node2 = 2
        // newHead = 1, node1 = 3
        // node3 = newHead = 1
        // 3 > 2 result = [1,2], node2 = 4
        // 3 < 4 result = [1,2,3], node1 = 5, node3 = 3
        //       result = [1,2,3,4], node2 = 6, node3 = 4
        //EX:
        //Node 2: 2->4->6
        //Node 3: 1->10
        //EX:
        //Node 2: 2->4->6
        //Node 3: 1->3

        private static Node merge(Node head1, Node head2)
        {
            Node newHead = new Node();
            Node node1 = head1;
            Node node2 = head2;

            if (node1.Value < node2.Value)
            {
                newHead = node1;
                node1 = node1.Next;
            }
            else
            {
                newHead = node2;
                node2 = node2.Next;
            }

            Node node3 = newHead;

            while (node1 != null && node2 != null)
            {
                // comparing head1 to head2
                if (node1.Value < node2.Value)
                {
                    node3.Next = node1;
                    node1 = node1.Next;
                }
                else if (node1.Value > node2.Value)
                {
                    node3.Next = node2;
                    node2 = node2.Next;
                }

                node3 = node3.Next;
            }

            if (node1 == null && node2 != null)
            {
                node3.Next = node2;
            }
            else if (node2 == null && node1 != null)
            {
                node3.Next = node1;
            }

            return newHead;
        }

        public static Node MergeKSortedLinkedList(List<Node> nodes)
        {
            Node resultHead = nodes[0];

            // for loop
            for (int i = 1; i < nodes.Count; i++)
            {
                // 1,2 => link
                // (1,2) , 3
                resultHead = merge(resultHead, nodes[i]);
            }

            return resultHead;
        }
    }
}
