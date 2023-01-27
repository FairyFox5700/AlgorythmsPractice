using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.Stack
{
    public class LinkedListNode
    {
        public int data;
        public LinkedListNode? next;

        public LinkedListNode(int data)
        {
            this.data = data;
            this.next = null;
        }
    }

    internal class StackWithLinkedList
    {
        LinkedListNode? top;

        public StackWithLinkedList()
        {
            top = null;

        }

        public void Push(int data)
        {
            var newObject = new LinkedListNode(data);
            newObject.next = top;
            top = newObject;
        }

        public bool IsEmptyStack()
        {
            return top == null;
        }

        public int Pop()
        {
            if (IsEmptyStack())
            {
                return -1;
            }

            var temp = top;
            top = top.next;
            return temp.data;
        }

        public int Top()
        {
            if (IsEmptyStack())
            {
                return -1;
            }

            return top.data;
        }
    }
}
