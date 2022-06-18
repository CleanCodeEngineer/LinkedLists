namespace LinkedLists
{
    public class LinkedListNode
    {
        public int Value { get; set; }
        //public char Value { get; set; }

        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }
        //public LinkedListNode(char value)
        //{
        //    Value = value;
        //}
    }
}
