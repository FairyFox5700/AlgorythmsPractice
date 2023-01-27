using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.DataStructures
{
    public class LinkedListNode<T>
    {
        public T Data { get; set; }
        public LinkedListNode<T>? Previous { get; set; }
        public LinkedListNode<T>? Next { get; set; }
    }

    public class DoubledLinkedList<T>
    {
        public LinkedListNode<T>? Head { get; set; }

        // Adding a node at the front of the list
        public void Push(T newData)
        {
            var newNode = new LinkedListNode<T>
            {
                Data = newData,
                Next = Head,
                Previous = null
            };
            if (Head != null)
                Head.Previous = newNode;
            Head = newNode;
        }

        /* Given a node as prev_node, insert a new node after the given node */
        public void InsertAfter(LinkedListNode<T> prevNode, T newData)
        {
            var newNode = new LinkedListNode<T>()
            {
                Data = newData,
                Previous = prevNode,
                Next = prevNode.Next,
            };

            prevNode.Next = newNode;

            if (newNode.Next != null)
            {
                newNode.Next.Previous = newNode;
            }

        }


        // Add a node at the end of the list
        public void Append(T newData)
        {
            var current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            var newNode = new LinkedListNode<T>()
            {
                Data = newData,
                Previous = current,
                Next = null,
            };

            current.Next = newNode;
        }

        public void PrintList(LinkedListNode<T>? node)
        {
            LinkedListNode<T>? last = null;
            Console.WriteLine("Traversal in forward Direction");
            while (node != null)
            {
                Console.Write(node.Data + " ");
                last = node;
                node = node.Next;
            }

            Console.WriteLine();
            Console.WriteLine("Traversal in reverse direction");
            while (last != null)
            {
                Console.Write(last.Data + " ");
                last = last.Previous;
            }
        }

        // Function to delete a node in a Doubly Linked List.
        // head_ref --> pointer to head node pointer.
        // del --> data of node to be deleted.
        public void DeleteNode(LinkedListNode<T>? nodeToDelete)
        {

            if (Head == null || nodeToDelete == null)
            {
                return;
            }

            if (Head == nodeToDelete)
            {
                Head = Head.Next;
            }

            if (nodeToDelete.Next != null)
            {
                nodeToDelete.Next.Previous = nodeToDelete.Previous;
            }

            if (nodeToDelete.Previous != null)
            {
                nodeToDelete.Previous.Next = nodeToDelete.Next;
            }
        }

        // Function to delete the node at the
        // given position in the doubly linked list
        public void DeleteNodeAtGivenPos(int position)
        {
            if (Head == null || position < 0)
            {
                return;
            }

            var current = Head;

            for (int i = 0; i < position; i++)
            {
                current = current?.Next;
            }

            if (current == null)
            {
                return;
            }

            DeleteNode(current);
        }
    }
}
