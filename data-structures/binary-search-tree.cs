/* 
* Md. Tanvir Ahmed
* tanvirahmed.cse.bubt@gmail.com
*/
using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    class BaseEntity
    {
        public int Id;
    }
    class Person : BaseEntity
    {
        
        public string Name;
        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
    class Node<T>
    {
        public T Data;
        public Node<T> LeftNode;
        public Node<T> RightNode;
        public Node(T data)
        {
            this.Data = data;
            this.LeftNode = null;
            this.RightNode = null;
        }
        public void Copy(Node<T> node)
        {
            this.Data = node.Data;
        }
    }
    class BinarySearchTree<T> where T : BaseEntity
    {
        private Node<T> Root;
        private List<T> sortedList = new List<T>(); // this list will be used for provideing sorted data list of the BST
        private int Flag; // it will determine modification to the BST
        public BinarySearchTree(T data)
        {
            Root = new Node<T>(data);
            Flag = 0;
        }
        public void Insert(T data)
        {
            Flag = 1;
            int flg = 0;
            Node<T> currentNode = Root;
            Node<T> parent = Root;
            while (currentNode != null)
            {
                if(data.Id <= currentNode.Data.Id)
                {
                    flg = 1;
                    parent = currentNode;
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    flg = 2;
                    parent = currentNode;
                    currentNode = currentNode.RightNode;
                }
            }
            Node<T> newNode = new Node<T>(data);
            if (flg == 1)
            {
                parent.LeftNode = newNode;
            }
            else if (flg == 2)
            {
                parent.RightNode = newNode;
            }
            else Root = newNode;
            //Console.WriteLine(currentNode.Data.Id);
        }
        private void Traverse(Node<T> currentNode)
        {
            if (currentNode.LeftNode != null)
            {
                Traverse(currentNode.LeftNode);
            }
            sortedList.Add(currentNode.Data);
            //Console.WriteLine("Traversing " + currentNode.Data.Id);
            if (currentNode.RightNode != null)
            {
                Traverse(currentNode.RightNode);
            }
        }
        public List<T> Sort()
        {
            if (Flag == 1)
            {
                sortedList.Clear();
                Traverse(Root);
            }
            Flag = 0;
            return sortedList;  
        }
        public T Search(int id)
        {
            Node<T> currentNode = Root;
            while (currentNode != null)
            {
                if (id == currentNode.Data.Id)
                {
                    return currentNode.Data;
                }
                else if (id < currentNode.Data.Id)
                {
                    
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    currentNode = currentNode.RightNode;
                }
            }
            return default(T);
        }
        public void Delete(int id)
        {
            Flag = 1;
            Node<T> currentNode = Root;
            Node<T> nodeToDelete;
            Node<T> prev1 = null; // parent node of the nodeToDelete
            int flg = 0; // use to determine left child or richt child
            while (currentNode != null)
            {
                if (id == currentNode.Data.Id)
                {
                    nodeToDelete = currentNode;
                    //finding leftmost node of the right subtree
                    if(nodeToDelete.LeftNode == null && nodeToDelete.RightNode == null) // for leaf node
                    {
                        if (prev1 != null)
                        {
                            if (flg == 1)
                            {
                                prev1.LeftNode = null;
                            }
                            else if (flg == 2)
                            {
                                prev1.RightNode = null;
                            }
                            break;
                        }
                        else Root = null;
                    }
                    else if(nodeToDelete.LeftNode == null || nodeToDelete.RightNode == null) // has one single child
                    {
                        Node<T> childNode = nodeToDelete.LeftNode == null ? nodeToDelete.RightNode : nodeToDelete.LeftNode;
                        nodeToDelete.Copy(childNode);
                        nodeToDelete.LeftNode = childNode.LeftNode;
                        nodeToDelete.RightNode = childNode.RightNode;
                        break;
                    }
                    else //has both left and right child
                    {
                        Node<T> recentNode = nodeToDelete.RightNode;
                        Node<T> parentOfRecent = nodeToDelete;
                        int rsntFlg = 0;
                        if(recentNode != null)
                        {
                            //finding leftmost node of right subtree
                            while (recentNode.LeftNode != null)
                            {
                                rsntFlg = 1;
                                parentOfRecent = recentNode;
                                recentNode = recentNode.LeftNode;
                            }
                            //RecursiveDelete(nodeToDelete, recentNode.Data.Id);
                            nodeToDelete.Copy(recentNode);
                            if(rsntFlg == 1) parentOfRecent.LeftNode = recentNode.RightNode;
                            else parentOfRecent.RightNode = recentNode.RightNode;
                            break;
                        }

                    }

                }
                else if (id < currentNode.Data.Id)
                {
                    flg = 1;
                    prev1 = currentNode;
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    flg = 2;
                    prev1 = currentNode;
                    currentNode = currentNode.RightNode;
                }

            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person(10, "Tanvir");
            Person person2 = new Person(8, "Tonmoy");
            Person person3 = new Person(13, "Tabassum");
            Person person4 = new Person(6, "Toufiq");
            Person person5 = new Person(9, "Taif");
            Person person6 = new Person(12, "Tanjiba");
            Person person7 = new Person(14, "Taskia");
            Person person10 = new Person(10, "Tahira");

            BinarySearchTree<Person> bst = new BinarySearchTree<Person>(person1);
            bst.Insert(person2);
            bst.Insert(person3);
            bst.Insert(person4);
            bst.Insert(person5);
            bst.Insert(person6);
            bst.Insert(person7);

            List<Person> sortedList = bst.Sort();
            foreach (Person prsn in sortedList)
            {
                Console.WriteLine(prsn.Name);
            }
            
            Person person = bst.Search(8);
            if (person != null)
            {
                Console.WriteLine(person.Id + "    " + person.Name);
            }
            else
            {
                Console.WriteLine("Not found!");
            }

            bst.Delete(10);
            Console.WriteLine("After deletion:");
            sortedList = bst.Sort();
            foreach (Person prsn in sortedList)
            {
                Console.WriteLine(prsn.Name);
            }

            Console.ReadKey();
        }
    }
}
