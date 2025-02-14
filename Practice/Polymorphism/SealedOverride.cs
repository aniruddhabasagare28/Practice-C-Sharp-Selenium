using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Polymorphism
{
    //A sealed override prevents further overriding in derived classes.
    class BaseClass1
    {
        public virtual void Show() { Console.WriteLine("Base Show"); }
    }

    class DerivedClass1 : BaseClass1
    {
        public sealed override void Show() { Console.WriteLine("Derived Show"); }
    }

    class FurtherDerived : Derived
    {
        // Cannot override Show() because it is sealed
    }

}
