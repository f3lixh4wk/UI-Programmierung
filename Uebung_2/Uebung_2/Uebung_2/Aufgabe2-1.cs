using System;
/*
 * Diese Aufgabe hat das Ziel, Sie für die Unterschiede zwischen Verweis- und Wertetypen zu sensibilieren.
   Definieren Sie zu diesem Zweck eine Klasse Test, die über ein privates Feld testfeld vom Typ int sowie 
   eine zugehörige Eigenschaft TestEigenschaft verfügt, mit der man den Wert von testfeld zurückgeben und festlegen kann. 
   Definieren Sie einen allgemeinen Konstruktor, mit dessen Hilfe testfeld initialisiert werden kann. Überschreiben Sie außerdem 
   die Methode ToString, so dass sie den Wert von testfeld in String-Form zurückgibt.
   Definieren Sie des Weiteren eine Struktur, die den gleichen Namen und den gleichen Inhalt wie die Klasse Test hat. Um einen Namenskonflikt zu vermeiden, definieren Sie die
   Klasse Test im Namensraum MeineKlassen und die Struktur Test im Namensraum MeineStrukturen.
 */
namespace MeineStrukturen
{
   struct Test
   {
      public Test(int testfeld)
      {
         this.testfeld = testfeld;
      }

      public override string ToString()
      {
         return testfeld.ToString();
      }
      public int TestEigenschaft { set => testfeld = value; get => testfeld; }

      private int testfeld;
   }
}

namespace MeineKlassen
{
   class Test
   {
      public Test(int testfeld)
      {
         this.testfeld = testfeld;
      }

      public Test(Test test)
      {
         this.testfeld = test.testfeld;
      }

      public override string ToString()
      {
         return testfeld.ToString();
      }
      public int TestEigenschaft { set => testfeld = value; get => testfeld; }

      private int testfeld;
   }
}

namespace Aufgabe_2_1
{
   using MeineKlassen;
   //using MeineStrukturen;

   class MainClass
   {
      static void Main(string[] args)
      {
         Test t1 = new Test(13);
         Test t2 = new Test(13);
         Test t3 = new Test(t1); // Kopierkonstruktor hinzugefügt
         Vergleiche(t1, t2, t3); //Stelle 1
         t3.TestEigenschaft = 42;
         Vergleiche(t1, t2, t3); //Stelle 2
         ÄndereEigenschaft(ref t1, 121); // ref hinzugefügt
         Vergleiche(t1, t2, t3); //Stelle 3
         Console.ReadKey();
      }
      static void Vergleiche(Test t1, Test t2, Test t3)
      {
         Console.WriteLine("t1: {0}, t2: {1}, t3: {2}", t1, t2, t3);
         Console.WriteLine("Vergleich zwischen t1 und t2 ergibt: {0}", t1.Equals(t2));
         Console.WriteLine("Vergleich zwischen t1 und t3 ergibt: {0}", t1.Equals(t3));
         Console.WriteLine("Vergleich zwischen t2 und t3 ergibt: {0}", t2.Equals(t3));
      }
      static void ÄndereEigenschaft(ref Test t, int neuerWert) // ref hinzugefügt
      {
         t.TestEigenschaft = neuerWert;
      }
   }
   
   /*Antwort:
    * Variante using MeineKlassen:
    * Es werden 2 unterschiedliche Instanzen der Klasse Test t1 und t2 erstellt. Anschließend wird die Instanz t3 mit t1 initialisiert.
    * An Stelle 1 unterscheiden sich t1 und t3 nicht, da t3 eine Referenzinstanz von t1 ist und sich nur zu t2 unterscheiden.
    * An Stelle 2 wurde t3 ein neuer Wert zugewiesen, was dazu führt, dass dieser Wert auch t1 zugewiesen wird. t3 zeigt sozusagen auf
    * die Speicheradresse von t1 und man kann den Wert von t1 "über" t3 verändern.
    * An Stelle 3 bekommen wir denselben Effekt wie an Stelle 2 nur das hier t1 ein neuer Wert zugewiesen wird und gleichzeitig t3 denselben
    * Wert zugewiesen bekommt.
    * Um eine inhaltiche Gleichheit zwischen t1 und t3 zu erreichen muss ein Kopierkonstruktor in der Klasse Test hinzugefügt werden und t3 mit
    * t3 = new Test(t1) initialisiert werden.
    * 
    * Variante using MeineStrukturen:
    * An Stelle 1 besitzen alle 3 Instanzen denselben Wert und es wird auf inhaltliche Gelichheit überprüft, sodass die Equals Methode true liefert.
    * An Stelle 2 hat sich nur der Wert der Instanz t3 geändert, sodass nur der Vergleich von t1 und t2 true liefert.
    * An Stelle 3 wurde der Wert von t1 nicht verändert, da die Mehtode ÄndereEigenschaft die Instanz t1 kopiert und diese nach Verlassen der Methode
    * stirbt. Der Wert von t1 wurde aber nicht verändert.
    * An der Methode ÄndereEigenschaft muss das Test Objekt mit dem Schlüsselwort ref übergeben werden, sowohl im Header der Methode als auch beim Aufruf.
    */
}
