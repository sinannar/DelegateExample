using System;

namespace DelegateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new DelegateExample();
            example.RunExample();

            var example2 = new DelegateExample2();
            example2.RunExample();

            var example3 = new DelegateExample3();
            example3.RunExample();

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

}