using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_2_3
{
   class MainClass
   {
      static void Main(string[] args)
      {
         int i, j;
         object obj;
         
         i = 42;
         obj = i; //Stelle 1

         i = 13; //Stelle 3

         j = (int)obj; //Stelle 2
         System.Console.WriteLine(j);
      }
      /*Antwort:
       * An Stelle 1 wird obj der Wert von i zugewiesen, obj befindet sich auf dem Heap und i auf dem Stack.
       * An Stelle 2 wird der Wert von obj aus dem Heap geholt und der Variablen j auf dem Stack zugewiesen.
       * An Stelle 3 wird i auf dem Stack der Wert 13 zugewiesen, obj auf dem Heap wird dabei nicht verändert.
       */
   }
}
