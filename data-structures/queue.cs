using System;

namespace Queue
{
    class Node<T>
    {
        public T Data;
        public Node<T> NextNode;
        public Node()
        {
            this.Data = default(T);
            this.NextNode = null;
        }
        public Node(T data, Node<T> nextNode)
        {
            this.Data = data;
            this.NextNode = nextNode;
        }

    }
    class Queue<T>
    {
        public Node<T> Top;
        public Queue()
        {
            Top = new Node<T>();
        }
        public void Push(T data)
        {
            Node<T> newNode = new Node<T>(data, null);
            Node<T> currentNode = Top;
            while(currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
            }
            currentNode.NextNode = newNode;
        }
        public T Pop()
        {
            if(Top.NextNode != null)
            {
                T data = Top.NextNode.Data;
                Top.NextNode = Top.NextNode.NextNode;
                return data;
            }

            return default(T);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            queue.Push("Tanvir");
            queue.Push("Tonmoy");
            queue.Push("Tabassum");

            int i = 4;
            string data;
            while (i > 0)
            {
                data = queue.Pop();
                if (data != default(string)) Console.WriteLine(data);
                else Console.WriteLine("Queue is empty!");
                i--;
            }
            Console.ReadKey();
        }
    }
}
