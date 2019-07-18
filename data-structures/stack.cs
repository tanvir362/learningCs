using System;

namespace Stack
{
    class Node
    {
        public string Data;
        public Node NextNode;
        public Node()
        {
            NextNode = null;
        }
        public Node(string data, Node nextNode)
        {
            this.Data = data;
            this.NextNode = nextNode;
        }
    }
    class Stack
    {
        public Node Top;
        public Stack()
        {
            Top = new Node();
        }
        public void Push(string data)
        {
            Node newNode = new Node(data, Top.NextNode);
            Top.NextNode = newNode;
        }
        public string Pop()
        {
            
            if(Top.NextNode != null)
            {
                string data = Top.NextNode.Data;
                Top.NextNode = Top.NextNode.NextNode;
                return data;
            }
            
            return "Stack is Empty!";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();
            stack.Push("Tanvir");
            stack.Push("Tonmoy");
            stack.Push("Tabassum");

            int i = 4;
            while (i>0)
            {
                Console.WriteLine(stack.Pop());
                i--;
            }
            Console.ReadKey();
        }
    }
}
