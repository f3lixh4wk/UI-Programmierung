using System;

namespace Uebung_1
{
   class Aufgabe1_1
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
               throw new ArgumentOutOfRangeException("test");
            else
               test = value;
         }
         get
         { return test; }
      }
   }
}
