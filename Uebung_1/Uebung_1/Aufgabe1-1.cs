using System;

namespace Aufgabe_1_1
{
   class Program
   {
      static void Main()
      {
         Testklasse test = new Testklasse();

         try
         {
            test.Test = 10;
            Console.WriteLine("test besitzt den Wert: {0}", test.Test);
            test.Test = 101;
         }
         catch(Exception exec)
         {
            Console.WriteLine(exec);
         }
      }
   }

   class Testklasse
   {
      int test;
      public int Test
      {
         set
         {
            if (value < 0 || value > 100)
               throw new ArgumentOutOfRangeException("Wert nicht zulässig");
            else
               test = value;
         }
         get
         { return test; }
      }
   }
}
