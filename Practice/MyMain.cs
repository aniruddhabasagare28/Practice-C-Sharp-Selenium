using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Practice.Constructor;
using Practice.Polymorphism;

namespace Practice
{
    class Program
    {
        static void Main()
        {
            Car car = new Car("Honda"); // parameterized contructor
            Car CopiedCar = new Car(car);

            

            A obj4 = new C();
            obj4.Show(); // Calls the most derived override: "C"

            //What will be the output of the following code?
            Base2 objforNewKeyword = new Derived2();
            objforNewKeyword.Show();

            //What happens if a virtual method is called inside a constructor?
            Base1 der = new Derived();
            der.Show();


            BaseClass obj1 = new BaseClass();
            obj1.ShowMessage();  // Output: Message from BaseClass

            DerivedClass obj2 = new DerivedClass();
            obj2.ShowMessage();  // Output: Message from DerivedClass

            BaseClass obj3 = new DerivedClass();
            obj3.ShowMessage();  // Output: Message from DerivedClass (Polymorphism)

            Child obj = new Child();
            obj.Show(); // ✅ Allowed (Calling the method that accesses the protected method)
             // obj.Display(); ❌ Not Allowed (Cannot access protected members directly)
        }
    }
}
