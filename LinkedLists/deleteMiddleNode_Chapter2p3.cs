using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class deleteMiddleNode_Chapter2p3
    {
        public static void deleteMiddleNode(LinkedListNode head)
        {
            int count = 0;
            var node = head;
            int middleNode = 0;

            while (node != null)
            {
                count++;
                node = node.Next;
            }

            if (count <= 2)
                return;
            else if (count == 3)
                middleNode = 2;
            else if (count % 2 != 0)
                middleNode = (count / 2) + 1;
            else
                middleNode = (count / 2);

            LinkedListNode previousNode = null;
            node = head;

            for (int i = 0; i <= middleNode; i++)
            {
                //if (count % 2 != 0 && i == middleNode - 1)
                //    previousNode = node;
                //else if (count % 2 == 0 && i == middleNode - 2)
                if (i == middleNode - 2)
                {
                    previousNode = node;
                    node = node.Next;
                }
                else if (i == middleNode - 1)
                {
                    previousNode.Next = node.Next;
                }
                else
                    node = node.Next;
            }
        }

        public static void deleteMiddleNode1(LinkedListNode middleNode)
        {
            LinkedListNode node = new LinkedListNode(middleNode.Next.Value);
            node.Next = middleNode.Next.Next;

            middleNode = node;
        }
    }
}
