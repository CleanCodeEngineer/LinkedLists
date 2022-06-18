using System;
using System.Collections.Generic;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //Node head = new Node();
            //Node node1 = new Node();
            //Node node2 = new Node();
            //Node node3 = new Node();
            //Node node4 = new Node();

            //head.Value = 6;
            //head.Next = node1;

            //node1.Value = 8;
            //node1.Next = node2;

            //node2.Value = 6;
            //node2.Next = node3;

            //node3.Value = 2;
            //node3.Next = node4;

            //node4.Value = 8;
            //node4.Next = null;

            //node4.Value = 8;
            //node4.Next = node2;

            //RemoveDuplicates_Chapter2p1.RemoveDuplicates(head);

            //RemoveDuplicates_Chapter2p1.RemoveDuplicates1(head);

            //RemoveDuplicates_Chapter2p1.RemoveDuplicates2(head);

            //RemoveDuplicates_Chapter2p1.deleteDups(head);

            //Node node = Chapter2p8.loopDetection(head);

            //LinkedListNode head1 = new LinkedListNode(1);
            //LinkedListNode node11 = new LinkedListNode(3);
            //LinkedListNode node12 = new LinkedListNode(5);
            //LinkedListNode node3 = new LinkedListNode(4);
            //LinkedListNode node4 = new LinkedListNode(8);

            //LinkedListNode head = new LinkedListNode('a');
            //LinkedListNode node1 = new LinkedListNode('b');
            //LinkedListNode node2 = new LinkedListNode('c');
            //LinkedListNode node3 = new LinkedListNode('d');
            //LinkedListNode node4 = new LinkedListNode('e');
            //LinkedListNode node5 = new LinkedListNode('f');

            //head1.Next = node11;
            //node11.Next = node12;
            //node12.Next = null;
            //node3.Next = null;
            //node3.Next = node4;
            //node4.Next = node5;
            //node4.Next = null;
            //node5.Next = null;
            //node4.Next = node2;

            //bool result = Chapter2p8.ContainsCycle(head);

            //LinkedListNode node = Chapter2p2.KthToLast(head, 0);

            //Chapter2p3.deleteMiddleNode(head);

            //Chapter2p3.deleteMiddleNode1(node2);

            //int maxSum = PairSum_Amazon.PairSum(head);

            //LinkedListNode seconHalfList = SplitALinkedList.divide(head);
            //LinkedListNode firstHalfList = head;

            // * EX: 
            // * Node 1: 1->3->5-> null
            // * Node 2: 2->4->6-> null
            // * Result: 1->2->3->4->5->6-> null

            //LinkedListNode head2 = new LinkedListNode(2);
            //LinkedListNode node21 = new LinkedListNode(4);
            //LinkedListNode node22 = new LinkedListNode(6);

            //head2.Next = node21;
            //node21.Next = node22;
            //node22.Next = null;

            //// * Node 3: 1->10
            //// * Result: 1->1->2->3->4->5->6->10
            //LinkedListNode head3 = new LinkedListNode(1);
            //LinkedListNode node31 = new LinkedListNode(10);

            //head3.Next = node31;
            //node31.Next = null;

            ////List<LinkedListNode> list = new List<LinkedListNode>() { head1, head2, head3 };
            //List<LinkedListNode> list = new List<LinkedListNode>() { };

            //LinkedListNode Result = MergeKSortedLinkedLists.merge(list);

            //Console.WriteLine(Result.Value);

            Console.WriteLine("Random Linked List:");
            // 1 -> 2 -> 3 -> 4 -> null
            // |    |    |    |
            // v    v    v    v
            // 3    1    3    2
            RandomLinkedList.Node node1 = new RandomLinkedList.Node();
            node1.Value = 1;

            RandomLinkedList.Node node2 = new RandomLinkedList.Node();
            node2.Value = 2;

            RandomLinkedList.Node node3 = new RandomLinkedList.Node();
            node3.Value = 3;

            RandomLinkedList.Node node4 = new RandomLinkedList.Node();
            node4.Value = 4;

            node1.Next = node2;
            node2.Next = node3;
            node3.Next = node4;
            node4.Next = null;

            node1.Random = node3;
            node2.Random = node1;
            node3.Random = node3;
            node4.Random = node2;

            RandomLinkedList.Node copy = RandomLinkedList.CloneWithExtraSpace(node1);
            Console.ReadLine();
        }
    }
}
