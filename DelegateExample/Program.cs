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
            p.OnChange += () => Console.WriteLine("Event Raised to method 3");
            p.OnChange += () =>
            {
                Console.WriteLine("Event Raised to method 4");
                Console.WriteLine("Event Raised to method 5");
            };
            p.Raise();
        }
    }
}