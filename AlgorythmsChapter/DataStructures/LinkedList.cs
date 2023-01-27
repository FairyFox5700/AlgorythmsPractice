namespace AlgorythmsChapter.DataStructures
{

    public class Node<T>
        where T : struct, IEquatable<T>, IComparable<T>, IComparable
    {
        public Node(T value)
        {
            Data = value;
        }

        public T Data { get; set; }
        public Node<T>? Next { get; set; }

    }

    internal class LinkedList<T>
        where T : struct, IEquatable<T>, IComparable<T>, IComparable
    {
        public Node<T>? Head { get; set; }

        /* Inserts a new Node at front of the list. */
        public void Push(T value)
        {
            var newNode = new Node<T>(value);
            newNode.Next = Head;
            Head = newNode;
        }

        /* Inserts a new node after the given prev_node. */

        public void InsertAfter(T value, Node<T> prevNode)
        {
            if (prevNode == null) return;

            var newNode = new Node<T>(value);
            prevNode.Next = newNode;
            newNode.Next = prevNode.Next;
        }

        /* Appends a new node at the end. */

        public void Append(T value)
        {
            var current = Head?.Next;
            while (current != null)
            {
                current = current.Next;
            }

            if (current == null)
            {
                Head = new Node<T>(value);
            }
            else
            {
                current.Next = new Node<T>(value);
            }
        }

        /* This function prints contents of linked list starting from the given node */
        public void PrintList()
        {
            var node = Head;
            while (node != null)
            {
                Console.WriteLine(node.ToString());
                node = node.Next;
            }
        }

        //Given a key, deletes the first
        // occurrence of key in linked list
        public void DeleteByValue(T value)
        {
            Node<T> prev = null;
            var current = Head;

            if (current != null && current.Data.Equals(value))
            {
                Head = current.Next;
            }

            while (current != null && !current.Data.Equals(value))
            {
                prev = current;
                current = current.Next;
            }

            if (current == null || prev == null)
            {
                return;
            }

            prev.Next = current.Next;
        }

        // Given a reference (pointer to pointer)
        // to the head of a list and a position,
        // deletes the node at the given position
        public void DeleteNodeAtIndex(int index)
        {
            if (Head == null)
            {
                return;
            }

            if (index == 0)
            {
                Head = Head.Next;
                return;
            }

            var current = Head?.Next;
            var currentIndex = 0;
            Node<T> prev = null;
            while (current != null && currentIndex != index)
            {
                prev = current;
                current = current.Next;
            }

            if (current == null || prev == null)
            {
                return;
            }

            prev.Next = current.Next;
        }
    }
}
