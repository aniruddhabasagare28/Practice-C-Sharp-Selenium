using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Patterns
    {
        public static void Patterns1(int n) 
        {
            for (int i = 0; i < n ; i++)
            {
                for (int s = 0; s < n-i-1; s++)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < 2*i-1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public static void Patterns2(int n)
        {
            for (int i = 1; i < n; i++)  // Loop for rows
            {
                for (int j = n-i-1; j > 0 ; j--)  
                {
                    Console.Write(0); 
                }
                for(int s = 1;  s <= i; s++) 
                { 
                    Console.Write(s); 
                }

                Console.WriteLine(); // Move to the next line
            }
        }

        public static void PrintPyramid(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                string spaces = new string(' ', n - i);
                string stars = new string('*', 2 * i - 1);
                Console.WriteLine(spaces + stars);
            }
        }

        public static void Pattern3(int n)
        {
            for(int i = n;i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write('*');
                }
                  Console.WriteLine();
            }
        }
    }
}
