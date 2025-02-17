using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class MyQueue
    {
        int rare = -1;
        int front = 0;
        int capacity;
        int[] queue; 

        public MyQueue(int capacity)
        {
            this.capacity = capacity;
            queue = new int[capacity];
        }

        public void Enqueue(int item)
        {
            if(rare == capacity -1)
            {
                Console.WriteLine("Queue is full");
                return;
            }
            queue[++rare] = item;
        }

        public int Dqueue() 
        { 
            if(front > rare)
            {
                Console.WriteLine("Queue is empty");
            }
            return queue[front++];
        }
    }
}
