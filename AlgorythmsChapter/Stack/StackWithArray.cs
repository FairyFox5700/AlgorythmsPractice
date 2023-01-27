using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorythmsChapter.Stack
{
    internal class StackWithArray
    {
        private int[] elements;
        private int top;
        private int max;
        public StackWithArray(int size)
        {
            elements = new int[size];
            top = -1;
            max = size;
        }

        public bool IsEmptyStack()
        {
            var stack = new Stack<int>();
            return top == -1;
        }

        public bool IsFullStack()
        {
            return top == (max - 1);
        }

        public void Push(int item)
        {
            if (IsFullStack())
            {
                Console.WriteLine("Stack Overflow");
                return;
            }
            else
            {
                elements[++top] = item;
            }
        }

        public int Pop()
        {
            if (IsEmptyStack())
            {
                Console.WriteLine("Stack Underflow");
                return -1;
            }
            else
            {
                Console.WriteLine("Poped element is: " + elements[top]);
                return elements[top--];
            }
        }

        public void PrintStack()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return;
            }
            else
            {
                for (int i = 0; i <= top; i++)
                {
                    Console.WriteLine("Item[" + (i + 1) + "]: " + elements[i]);
                }
            }
        }
    }
}
