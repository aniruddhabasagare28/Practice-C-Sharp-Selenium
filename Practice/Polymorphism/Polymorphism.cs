using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Polymorphism
{
    class BaseClass
    {
        public virtual void ShowMessage()
        {
            Console.WriteLine("Message from BaseClass");
        }
    }

    class DerivedClass : BaseClass
    {
        public override void ShowMessage()
        {
            Console.WriteLine("Message from DerivedClass");
        }
    }

    //What happens if a virtual method is called inside a constructor?
    class Base1
    {
        public Base1()
        {
            Show(); // Calls the overridden method in Derived
        }

        public virtual void Show()
        {
            Console.WriteLine("Base Show");
        }
    }

    class Derived : Base1
    {
        private string name = "Derived";

        public override void Show()
        {
            Console.WriteLine(name); // This may result in unexpected behavior
        }
    }
}
