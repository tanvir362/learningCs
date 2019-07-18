using System;

namespace LinkedList
{
    class Node
    {
        public string Data;
        public int Key;
        public Node NextNode;
        public Node(int key, string data, Node nextNode)
        {
            this.Key = key;
            this.Data = data;
            this.NextNode = nextNode;
        }
        public Node()
        {
            this.Key = -1; //convention key can not be negative
            this.Data = null;
            this.NextNode = null;

        }
    }
    class LinkedList
    {
        public Node Start;
        public LinkedList()
        {
            Start = new Node();
        }
        public void Insert(int key, string data)
        {
            Node newNode = new Node(key, data, Start.NextNode);
            Start.NextNode = newNode;
        }
        public string GetData(int key)
        {
            Node currentNode = Start.NextNode;
            while(currentNode != null)
            {
                if (currentNode.Key == key) return currentNode.Data;
                currentNode = currentNode.NextNode;
            }
            return "Key not found!";
        }
        public void Delete(int key)
        {
            Node currentNode = Start;
            while (currentNode.NextNode != null)
            {
                if (currentNode.NextNode.Key == key)
                {
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                    return;
                }
                currentNode = currentNode.NextNode;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();
            linkedList.Insert(1, "Tanvir");
            linkedList.Insert(2, "Tonmoy");
            linkedList.Insert(4, "It shoud not be here");
            linkedList.Insert(3, "Tabassum");

            Console.WriteLine(linkedList.GetData(1));
            Console.WriteLine(linkedList.GetData(2));
            Console.WriteLine(linkedList.GetData(3));
            Console.WriteLine(linkedList.GetData(4));
            linkedList.Delete(4);
            Console.WriteLine(linkedList.GetData(1));
            Console.WriteLine(linkedList.GetData(2));
            Console.WriteLine(linkedList.GetData(3));
            Console.WriteLine(linkedList.GetData(4));
            Console.ReadKey();
        }
    }
}
