using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Parent
    {
        protected void Display()
        {
            Console.WriteLine("Protected Method: Accessible in derived class.");
        }
    }

    public class Child : Parent
    {
        public void Show()
        {
            Display(); // ✅ Allowed (Inherited from Parent)
        }
    }

    
}
