using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Polymorphism
{
    //How does C# resolve which method to call in a deep inheritance hierarchy with multiple overrides?
    class A
    {
        public virtual void Show() { Console.WriteLine("A"); }
    }

    class B : A
    {
        public override void Show() { Console.WriteLine("B"); }
    }

    class C : B
    {
        public override void Show() { Console.WriteLine("C"); }
    }

}
