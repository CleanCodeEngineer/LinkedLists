using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    // Question from bytebybyte
    // Given a linked list where each node has two pointers, one to the next node and one to a random
    // node in the list, clone the linked list.
    // eg.
    // 1 -> 2 -> 3 -> 4 -> null
    // |    |    |    |
    // v    v    v    v
    // 3    1    3    2
    public class RandomLinkedList
    {
        public class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node Random { get; set; }
        }

        public static Node CloneWithExtraSpace(Node n)
        {
            if (n == null) return n;

            // HashMap
            // Map nodes in old list to equivalent nodes in new list
            Dictionary<Node, Node> mapping = new Dictionary<Node, Node>();

            // Create new linked list, minus the random node pointers. Save mapping
            // of equivalent old node to new node
            Node copy = new Node();
            copy.Value = n.Value;

            Node nCurr = n;
            Node copyCurr = copy;

            mapping.Add(nCurr, copyCurr);

            while (nCurr.Next != null)
            {
                copyCurr.Next = new Node();
                copyCurr.Next.Value = nCurr.Next.Value;

                nCurr = nCurr.Next;
                copyCurr = copyCurr.Next;

                mapping.Add(nCurr, copyCurr);
            }

            // Copy the random pointers. Find the random pointer in the original
            // list and look up the equivalent using the map
            nCurr = n;
            copyCurr = copy;

            while (nCurr != null)
            {
                copyCurr.Random = mapping[nCurr.Random];

                nCurr = nCurr.Next;
                copyCurr = copyCurr.Next;
            }

            return copy;
        }
    }
}
