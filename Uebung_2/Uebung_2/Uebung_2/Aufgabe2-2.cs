using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_2_2
{
   class Program
   {
      /*
       * int                                     = Wertetyp      
         short[]                                 = Wertetyp
         double                                  = Wertetyp
         System.Collections.Generic.List<string> = Verweistyp (class)
         string                                  = Verweistyp (class)
         struct A{string s;}                     = Wertetyp
         bool                                    = Wertetyp
         class B{bool b;}                        = Verweistyp
         object                                  = Verweistyp (class)
         enum E{X, Y, Z}                         = Wertetyp 
         Int32                                   = Wertetyp (struct)
         System.Nullable<long>                   = Wertetyp (struct)
       */
      enum E { X, Y, Z};
      static void Main(string[] args)
      {
         E t1 = E.X;
         E t2 = E.X;
         E t3 = t1; 
         Vergleiche(t1, t2, t3);
         t3 = E.Y;
         Vergleiche(t1, t2, t3); 
         ÄndereEigenschaft(ref t1, E.Z); 
         Vergleiche(t1, t2, t3); 
         Console.ReadKey();
      }
      static void Vergleiche(E t1, E t2, E t3)
      {
         Console.WriteLine("t1: {0}, t2: {1}, t3: {2}", t1, t2, t3);
         Console.WriteLine("Vergleich zwischen t1 und t2 ergibt: {0}", t1.Equals(t2));
         Console.WriteLine("Vergleich zwischen t1 und t3 ergibt: {0}", t1.Equals(t3));
         Console.WriteLine("Vergleich zwischen t2 und t3 ergibt: {0}", t2.Equals(t3));
      }
      static void ÄndereEigenschaft(ref E t, E neuerWert) 
      {
         t = neuerWert;
      }
   }
}
