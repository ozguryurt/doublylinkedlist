using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr;
            DoublyLinkedList list1 = new DoublyLinkedList();
            list1.Add(1); // 1
            list1.Add(2); // 1 2
            list1.RemoveData(4); // 1 2
            list1.RemoveData(1); // 2
            list1.Insert(0, 5); // 5 2
            list1.RemoveIndex(0); // 2
            list1.Insert(0, 9); // 9 2
            list1.Insert(1, 13); // 9 13 2
            list1.Insert(0, -1); // -1 9 13 2

            arr = list1.GetList();
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }
    }

    class DoublyLinkedList
    {
        Node firstNode;
        Node lastNode;

        private int count = 0;

        public int length { get { return count; } }

        public void Add(int data)
        {
            Node newNode = new Node(data);
            if(count == 0)
            {
                firstNode = newNode;
                lastNode = newNode;
                count++;
            }
            else
            {
                newNode.prev = lastNode;
                lastNode.next = newNode;
                lastNode = newNode;
                count++;
            }
        }

        public void Insert(int index, int data)
        {
            if(count != 0)
            {
                if(count == 1)
                {
                    if(index == 0)
                    {
                        Node newNode = new Node(data);
                        firstNode.prev = newNode;
                        newNode.next = firstNode;
                        lastNode = firstNode;
                        firstNode = newNode;
                        count++;
                    }
                    else if(index == 1)
                    {
                        Node newNode = new Node(data);
                        firstNode.next = newNode;
                        newNode.prev = firstNode;
                        lastNode = newNode;
                        count++;
                    }
                    else
                    {
                        throw new Exception("hatalı index");
                    }
                }
                else
                {
                    if (index < count - 1 && index > 0)
                    {
                        Node newNode = new Node(data);
                        Node temp = firstNode;
                        for (int i = 0; i < index; i++)
                        {
                            temp = temp.next;
                        }
                        newNode.prev = temp.prev;
                        temp.prev.next = newNode;
                        newNode.next = temp;
                        temp.prev = newNode;
                        count++;
                    }
                    else if (index == 0)
                    {
                        Node newNode = new Node(data);
                        firstNode.prev = newNode;
                        newNode.next = firstNode;
                        firstNode = newNode;
                        count++;
                    }
                    else if (index == count - 1)
                    {
                        Node newNode = new Node(data);
                        Node prev = lastNode.prev;
                        prev.next = newNode;
                        newNode.prev = prev;
                        newNode.next = lastNode;
                        lastNode.prev = newNode;
                        count++;
                    }
                    else
                    {
                        throw new Exception("hatalı index");
                    }
                }
            }
            else
            {
                throw new Exception("liste boş");
            }
        }

        public void RemoveData(int data)
        {
            if(count != 0)
            {
                Node temp = firstNode;
                while (temp != null)
                {
                    if(temp.data == data)
                    {
                        if (temp.prev == null)
                        {
                            firstNode = temp.next;
                            count--;
                            break;
                        }
                        else if (temp.next == null)
                        {
                            lastNode = temp.prev;
                            count--;
                            break;
                        }
                        else
                        {
                            temp.prev.next = temp.next;
                            temp.next.prev = temp.prev;
                            count--;
                            break;
                        }
                    }
                    temp = temp.next;
                }
            }
            else
            {
                throw new Exception("liste boş");
            }
        }

        public void RemoveIndex(int index)
        {
            if(count != 0)
            {
                if(index < count - 1 && index > 0)
                {
                    Node temp = firstNode;
                    for(int i = 0; i < index; i++)
                    {
                        temp = temp.next;
                    }
                    temp.prev.next = temp.next;
                    temp.next.prev = temp.prev;
                    count--;
                }
                else if(index == 0)
                {
                    firstNode = firstNode.next;
                    count--;
                }
                else if(index == count - 1)
                {
                    lastNode = lastNode.prev;
                    count--;
                }
                else
                {
                    throw new Exception("hatalı index");
                }
            }
            else
            {
                throw new Exception("liste boş");
            }
        }

        public int[] GetList()
        {
            int[] arr = new int[count];
            Node temp = firstNode;
            for(int i = 0; i < count; i++)
            {
                arr[i] = temp.data;
                temp = temp.next;
            }
            return arr;
        }
    }

    class Node
    {
        public Node prev;
        public int data;
        public Node next;

        public Node()
        {

        }
        public Node(int data)
        {
            this.data = data;
        }
    }
}
