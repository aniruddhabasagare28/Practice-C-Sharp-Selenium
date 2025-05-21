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
            int[] numbers = { 1,5,6,3, 2, 3, 4, 5, 6 };

            Practice.IsSubstring("Aniruddha","ddha");

            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

            coffee = new MilkDecorator(coffee);  // Adding Milk
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");

            coffee = new SugarDecorator(coffee); // Adding Sugar
            Console.WriteLine($"{coffee.GetDescription()} - ${coffee.GetCost()}");


            for (int i = 0; i <= 5; i++)
            {
                Console.Write(Practice.FibonacciRecursive(i)+" ");

            }


            MyStack stack = new MyStack(5);
            stack.Push(3);
            stack.Push(4);
            stack.Push(1);
            stack.Push(6);
            stack.Push(7);
            stack.Push(8);

            Practice p = new Practice();
            p.LinQuery();

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
