using System;

namespace EventsandCallbacks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DelegateExample");
            var example = new DelegateExample();
            example.RunExample();
            Console.WriteLine("==================");

            Console.WriteLine("DelegateExample2");
            var example2 = new DelegateExample2();
            example2.RunExample();
            Console.WriteLine("==================");

            Console.WriteLine("DelegateExample3");
            var example3 = new DelegateExample3();
            example3.RunExample();
            Console.WriteLine("==================");

            Console.WriteLine("UsingLambdaExpressions");
            var example4 = new UsingLambdaExpressions();
            example4.RunExample();
            Console.WriteLine("==================");

            Console.WriteLine("UsingLambdaExpressionsWithMultipleStatements");
            var example5 = new UsingLambdaExpressionsWithMultipleStatements();
            example5.RunExample();
            Console.WriteLine("==================");

            Console.WriteLine("UsingBuiltInFunction");
            var example6 = new UsingBuiltInFunction();
            example6.RunExample();
            Console.WriteLine("==================");

            Console.WriteLine("UsingBuiltInAction");
            var example7 = new UsingBuiltInAction();
            example7.RunExample();
            Console.WriteLine("==================");


            Console.WriteLine("UsingEvents");
            var example8 = new UsingEvents();
            example8.RunExample();
            Console.WriteLine("==================");

            Console.WriteLine("UsingEvents2");
            var example9 = new UsingEvents2();
            example9.RunExample();
            Console.WriteLine("==================");




            Console.ReadKey();
            Console.WriteLine();
        }
    }

    class DelegateExample
    {
        public delegate int Calculate(int x, int y);

        public int Add(int x, int y) { return x + y; }
        public int Multiply(int x, int y) { return x * y; }

        public void RunExample()
        {
            Calculate calc = Add;
            Console.WriteLine(calc(1, 2));

            Calculate mult = Multiply;
            Console.WriteLine(mult(1, 2));

            Console.ReadKey();
            Console.WriteLine();
        }
    }

    class DelegateExample2
    {
        public void Method1()
        {
            Console.WriteLine("Method 1");
        }
        public void Method2()
        {
            Console.WriteLine("Method 2");
        }

        public delegate void Del();

        public void RunExample()
        {
            Del d = Method1;
            d += Method2;

            d();
            Console.ReadKey();
            Console.WriteLine();
        }
    }

    class Base { }
    class InheritedA : Base { }
    class InheritedB : Base { }

    class DelegateExample3
    {
        public InheritedA Method1()
        {
            Console.WriteLine("Method 1");
            return new InheritedA();
        }
        public InheritedB Method2()
        {
            Console.WriteLine("Method 2");
            return new InheritedB();
        }

        public delegate Base Del();

        public void RunExample()
        {
            Del d = Method1;
            d += Method2;

            d();
            Console.ReadKey();
            Console.WriteLine();
        }
    }

    class UsingLambdaExpressions
    {

        public delegate int Calculate(int x, int y);

        public void RunExample()
        {
            Calculate add = (x, y) => x + y;
            Console.WriteLine(add(1, 2));

            Calculate mult = (x, y) => x * y;
            Console.WriteLine(mult(1, 2));

            Console.ReadKey();
            Console.WriteLine();
        }
    }

    class UsingLambdaExpressionsWithMultipleStatements
    {

        public delegate int Calculate(int x, int y);

        public void RunExample()
        {
            Calculate add = (x, y) =>
            {
                Console.WriteLine("add");
                return x + y;
            };
            Console.WriteLine(add(1, 2));

            Calculate mult = (x, y) =>
            {
                Console.WriteLine("mult");
                return x * y;
            };
            Console.WriteLine(mult(1, 2));

            Console.ReadKey();
            Console.WriteLine();
        }
    }

    class UsingBuiltInFunction
    {
        public void RunExample()
        {
            Func<int, int, int> add = (x, y) =>
            {
                Console.WriteLine("add");
                return x + y;
            };
            Console.WriteLine(add(1, 2));

            Func<int, int, int> mult = (x, y) =>
            {
                Console.WriteLine("mult");
                return x * y;
            };
            Console.WriteLine(mult(1, 2));

            Console.ReadKey();
            Console.WriteLine();
        }
    }

    class UsingBuiltInAction
    {
        public void RunExample()
        {
            Action<int, int> add = (x, y) =>
            {
                Console.WriteLine("Action add");
            };
            add(1, 2);

            Action<int, int> mult = (x, y) =>
            {
                Console.WriteLine("Action mult");
            };
            mult(1, 2);

            Console.ReadKey();
            Console.WriteLine();
        }
    }

    class Pub
    {
        public Action OnChange { get; set; }

        public void Raise()
        {
            if (OnChange != null)
            {
                OnChange();
            }
        }
    }

    class UsingEvents
    {
        public void RunExample()
        {
            Pub p = new Pub();
            p.OnChange += () => Console.WriteLine("Event Raised to method 1");
            p.OnChange += () => Console.WriteLine("Event Raised to method 2");
            //p.OnChange = () => Console.WriteLine("Event Raised to method 2"); //This is legid code
            p.OnChange += () => Console.WriteLine("Event Raised to method 3");
            p.OnChange += () =>
            {
                Console.WriteLine("Event Raised to method 4");
                Console.WriteLine("Event Raised to method 5");
            };
            p.Raise();
            //p.OnChange(); //This is legid code
        }
    }
    /*
        A popular design pattern called publish - subscribe is part of events. You can subscribe to an event and then you are notified when the publisher of the event raises a new event.
        Delegates from the basis for the event system in C#. Above we can see the example of this usage.
        At Runexample of UsingEvents class, code creates a new instance of Pub, subscribe to event with different methods and then raises the event by p. Pub class is completely unaware of subscribers.
        If there was no subscriber, the null check would prevent the error so there is check happens on Pub.
        This system works, but you can delete previous subscriber easily with using = instead of += so this is one down side of this implementations.
        Second weakness is outside of Pub, we can directly call p.OnChange to raise new event instead of calling p.Raise to let P handle it. C# use special event keyword to handle this.
     */

    class Pub2
    {
        public event Action OnChange = delegate { };

        public void Raise()
        {
            OnChange();
        }
    }

    class UsingEvents2
    {
        public void RunExample()
        {
            Pub2 p = new Pub2();
            p.OnChange += () => Console.WriteLine("Event Raised to method 1");
            p.OnChange += () => Console.WriteLine("Event Raised to method 2");
            //p.OnChange = () => Console.WriteLine("Event Raised to method 2"); //This give compile error
            p.OnChange += () => Console.WriteLine("Event Raised to method 3");
            p.OnChange += () =>
            {
                Console.WriteLine("Event Raised to method 4");
                Console.WriteLine("Event Raised to method 5");
            };
            p.Raise();
            //p.OnChange(); //This is give compile error
        }
    }

    /*
        So we change Pub class to re implement as Pub2 with event with this 2 problem. Direc assignment is not valid also eventhought OnChange is public, outside of class they can not invoke it.
        Initialising OnChange with delegate{} will let me decrease the code because it is initialised so it can not be null anymore.
     */
}