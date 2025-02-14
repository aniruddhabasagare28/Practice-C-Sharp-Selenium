using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Polymorphism
{
    //What will be the output of the following code?
    class Base2
    {
        public virtual void Show()
        {
            Console.WriteLine("Base Show");
        }
    }

    class Derived2 : Base2
    {
        public new void Show()
        {
            Console.WriteLine("Derived Show");
        }
    }

}
