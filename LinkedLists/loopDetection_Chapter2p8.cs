using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class loopDetection_Chapter2p8
    {
        public static Node loopDetection(Node head)
        {
            HashSet<Node> nodes = new HashSet<Node>();

            Node node = head;

            while (node.Next != null && !nodes.Contains(node.Next))
            {
                nodes.Add(node.Next);
                node = node.Next;
            }

            if (nodes.Contains(node.Next))
                return node.Next;
            else
                return null;
        }

        // O(n) time and O(1) space.
        public static bool ContainsCycle(LinkedListNode head)
        {
            // Start both runners at the beginning
            var slowRunner = head;
            var fastRunner = head;

            // Until we hit the end of the list
            while (fastRunner != null && fastRunner.Next != null)
            {
                slowRunner = slowRunner.Next;
                fastRunner = fastRunner.Next.Next;

                if (fastRunner == slowRunner)
                    return true;
            }

            // Case: fastRunner hit the end of the list
            return false;
        }
    }
}
