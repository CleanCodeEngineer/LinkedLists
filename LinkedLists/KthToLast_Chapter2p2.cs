using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class KthToLast_Chapter2p2
    {
        public static LinkedListNode KthToLast(LinkedListNode head, int k)
        {
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
