using System;
using System.Collections.Generic;

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

            Console.WriteLine("UsingEventHandler");
            var example10 = new UsingEventHandler();
            example10.RunExample();
            Console.WriteLine("==================");

            Console.WriteLine("UsingEventHandler2");
            var example11 = new UsingEventHandler2();
            example11.RunExample();
            Console.WriteLine("==================");

            Console.ReadKey();

            Console.WriteLine("ExceptionAtEventHandlerExample");
            var example12 = new ExceptionAtEventHandlerExample();
            example12.RunExample();
            Console.WriteLine("==================");


            Console.ReadKey();

            Console.WriteLine("ExceptionAtEventHandlerExample2");
            var example13 = new ExceptionAtEventHandlerExample2();
            example13.RunExample();
            Console.WriteLine("==================");



            Console.ReadKey();
            Console.ReadKey();
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
        Instead of using Action type event, we can use EventHandler or EvenHandler<T> in this code
     */

    public class MyArgs:EventArgs
    {
        public MyArgs(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }

    public class Pub3
    {
        public event EventHandler<MyArgs> OnChange = delegate { };
        public void Raise()
        {
            OnChange(this, new MyArgs(42));
        }
    }
    class UsingEventHandler
    {
        public void RunExample()
        {
            Pub3 p = new Pub3();
            p.OnChange += (sender, e) => { Console.WriteLine("Evend handler - Event raised :{0}", e.Value); };
            p.OnChange += (sender, e) => { Console.WriteLine("Evend handler - Event raised :{0}", e.Value); };
            p.OnChange += (sender, e) => { Console.WriteLine("Evend handler - Event raised :{0}", e.Value); };
            p.Raise();
        }
    }

    /*
        Pub class use MyArgs as type of event argument. So when you raising the event, you need to pass an instance of MyArgs. Subscrabers to event can access the arguments and use it
        You can customise the removel of subscribers which is called a custom event accessor we will see in a next example.

        Custom event accessor looks a lot like proprty with a get and set accessors. Instead of get and set, we use add and remove.
        Most important one we need to do is making sure this is thread safe via lock.
        If you use regular event syntax, compiler generates the accessor for you, this makets it clear that events are not delegates, instead they are convenient wrapper around delegatest.

        Delegates executed in sequential order. Generally, the order is the order of how they were added. But it is not a rule, it is not specified within CLI

     */

    public class MyArgs2 : EventArgs
    {
        public MyArgs2(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
    }

    public class Pub4
    {
        private event EventHandler<MyArgs2> onChange = delegate { };
        public event EventHandler<MyArgs2> OnChange
        {
            add
            {
                lock(onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public void Raise()
        {
            onChange(this, new MyArgs2(42));
        }
    }
    class UsingEventHandler2
    {
        public void RunExample()
        {
            Pub4 p = new Pub4();
            p.OnChange += (sender, e) => { Console.WriteLine("Evend handler - Event raised :{0}", e.Value); };
            p.OnChange += (sender, e) => { Console.WriteLine("Evend handler - Event raised :{0}", e.Value); };
            p.OnChange += (sender, e) => { Console.WriteLine("Evend handler - Event raised :{0}", e.Value); };
            p.Raise();
        }
    }


    public class Pub5
    {
        public event EventHandler OnChange = delegate { };
       
        public void Raise()
        {
            OnChange(this, EventArgs.Empty);
        }
    }
    class ExceptionAtEventHandlerExample
    {
        public void RunExample()
        {
            Pub5 p = new Pub5();

            p.OnChange += (sender, e) => { Console.WriteLine("Subscriber 1 called"); };
            p.OnChange += (sender, e) => { throw new Exception("Subscriber 1 called"); };
            p.OnChange += (sender, e) => { Console.WriteLine("Subscriber 3 called"); };

            try
            {
                p.Raise();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Catched : " + ex.Message);
                Console.ReadKey();
            }
        }
    }

    /*
        Normally that was not the original code in the book. I added try catch around p.Raise. But next example will put better exception handling I assume
        Becase we can not see subscriber 3 called in this base handling so we need better one
     */
    public class Pub6
    {
        public event EventHandler OnChange = delegate { };

        public void Raise()
        {
            var exceptions = new List<Exception>(); 
            foreach(Delegate handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if(exceptions.Count > 0)
            {
                throw new Exception($"{exceptions.Count} exception happened");
            }
        }
    }

    class ExceptionAtEventHandlerExample2
    {
        public void RunExample()
        {
            Pub6 p = new Pub6();

            p.OnChange += (sender, e) => { Console.WriteLine("Subscriber 1 called"); };
            p.OnChange += (sender, e) => { throw new Exception("Subscriber 2 called"); };
            p.OnChange += (sender, e) => { Console.WriteLine("Subscriber 3 called"); };

            try
            {
                p.Raise();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Catched : " + ex.Message);
                Console.ReadKey();
            }
        }
    }

}