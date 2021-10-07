using CustomEventArguments.Models;
using EventFirstLook.Models;
using System;

namespace AnonymousMethods
{
    // It is possible to associate an event directly to a block of code statements at the
    // time of event registration. Formally, such code is termed an anonymous method.

    // The basic syntax of an anonymous method matches the following pseudocode:
    // SomeType t = new SomeType();
    // t.SomeEvent += delegate (optionallySpecifiedDelegateArgs)
    // { /* statements */ };

    // The following important points about the interaction between an anonymous method scope and the scope of the
    // defining method should be mentioned:
    // • An anonymous method cannot access ref or out parameters of the defining method.
    // • An anonymous method cannot have a local variable with the same name as a local variable in the outer method.
    // • An anonymous method can access instance variables(or static variables, as appropriate) in the outer class scope.
    // • An anonymous method can declare local variables with the same name as outer class member variables
    //   (the local variables have a distinct scope and hide the outer class member variables).
    class Program
    {
        static void Main()
        {
            Car c1 = new Car("SlugBug", 100, 10);
            int aboutToBlowCounter = 0;

            // Register event handlers as anonymous methods.
            c1.AboutToBlow += delegate
            {
                aboutToBlowCounter++;
                Console.WriteLine("Eek! Going too fast!");
            };

            c1.AboutToBlow += delegate (object sender, CarEventArgs e)
            {
                aboutToBlowCounter++;
                Console.WriteLine("Message from Car: {0}", e.msg);
            };

            c1.Exploded += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("Fatal Message from Car: {0}", e.msg);
            };

            // This will eventually trigger the events.
            for (int i = 0; i < 6; i++)
            {
                c1.Accelerate(20);
            }

            Console.WriteLine("\nAboutToBlow event was fired {0} times.", aboutToBlowCounter);

            Console.ReadLine();
        }
    }
}