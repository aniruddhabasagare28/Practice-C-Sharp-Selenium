using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class MyStack
    {
        public int[] stackArray;
        int capacity;
        int top;

        public MyStack(int size) 
        {
            capacity = size;
            stackArray = new int[capacity];
            top = -1;
        }

        public void Push(int value)
        {
            if (top == capacity - 1)
            {
                Console.WriteLine("Stack is Full");
                return;
            }

            stackArray[++top] = value;
        }

        public int Pop() 
        {
            if(top == -1)
            {
                Console.WriteLine("Stack is empty");
                return -1;
            }
            return stackArray[top];
        }

        public int Peek()
        {
            if(top == -1)
            {
                Console.WriteLine("Stack is Empty");
                return -1;
            }
            return stackArray[top];
        }
    }
}
