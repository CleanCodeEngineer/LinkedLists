using static LinkedLists.MergeKSortedLinkedLists;

namespace LinkedLists
{
    public class PriorityQueue
    {
        public QueueNode[] Heap { get; set; }
        public int Count { get; set; }
        public PriorityQueue(int maxSize)
        {
            Heap = new QueueNode[maxSize];
            Count = 0;
        }

        public void Enqueue(QueueNode queueNode, int value)
        {
            int pos = Count;
            Heap[pos] = new QueueNode(queueNode.LinkedList, queueNode.Node, queueNode.Value);

            while (pos > 0)
            {
                int parent = (pos - 1) / 2;

                if (Heap[parent].Value <= Heap[pos].Value) break;

                swapIndices(parent, pos);

                pos = parent;
            }

            Count++;
        }

        public QueueNode Dequeue()
        {
            QueueNode queueNode = Heap[0];

            Heap[0] = Heap[Count - 1];
            Heap[Count - 1] = null;

            Count--;

            int pos = 0;

            while (pos < Count / 2)
            {
                int leftChild = pos * 2 + 1;
                int rightChild = leftChild + 1;

                if (rightChild < Count && Heap[rightChild].Value < Heap[leftChild].Value)
                {
                    if (Heap[pos].Value <= Heap[rightChild].Value) break;

                    swapIndices(pos, rightChild);
                    pos = rightChild;
                }
                else
                {
                    if (Heap[pos].Value <= Heap[leftChild].Value) break;

                    swapIndices(pos, leftChild);
                    pos = leftChild;
                }
            }

            return queueNode;
        }

        private void swapIndices(int i, int j)
        {
            QueueNode temp = Heap[i];
            Heap[i] = Heap[j];
            Heap[j] = temp;
        }
    }
}
