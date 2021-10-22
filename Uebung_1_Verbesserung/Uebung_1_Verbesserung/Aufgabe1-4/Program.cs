using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_1_4
{
   class Program
   {
      static void Main(string[] args)
      {
         try
         {
            String re1;
            String im1;
            Console.WriteLine("Realteil für die erste komplexe Zahl: ");
            re1 = Console.ReadLine();
            Console.WriteLine("Imaginärteil für die erste komplexe Zahl: ");
            im1 = Console.ReadLine();

            String re2;
            String im2;
            Console.WriteLine("Realteil für die zweite komplexe Zahl: ");
            re2 = Console.ReadLine();
            Console.WriteLine("Imaginärteil für die zweite komplexe Zahl: ");
            im2 = Console.ReadLine();

            Complex z1 = new Complex(Convert.ToDouble(re1), Convert.ToDouble(im1));
            Complex z2 = new Complex(Convert.ToDouble(re2), Convert.ToDouble(im2));

            Complex z3 = z1 / z2;
            String operatorStr = (z3.Im >= 0) ? "+" : "";
            Console.WriteLine("= " + z3.Re + operatorStr + z3.Im + "i");
         }
         catch (DivideByZeroException)
         {
            Console.WriteLine("Üngültiges Ergebnis: Division durch 0");
         }
      }
   }

   class Complex
   {
      public Complex(double Re, double Im)
      {
         this.re = Re;
         this.im = Im;
      }

      public double Re
      {
         set { re = value; }
         get { return re; }
      }

      public double Im
      {
         set { im = value; }
         get { return im; }
      }

      public static Complex operator /(Complex z1, Complex z2)
      {
         if (z2.Re == 0 && z2.Im == 0)
         {
            throw new DivideByZeroException();
         }
         double a = z1.Re;
         double b = z1.Im;
         double c = z2.Re;
         double d = z2.Im;

         double nenner = Math.Pow(c, 2) + Math.Pow(d, 2);
         double real = ((a * c) + (b * d)) / nenner;
         double imag = ((b * c) - (a * d)) / nenner;

         Complex z3 = new Complex(real, imag);
         return z3;
      }

      private double re;
      private double im;
   }
}
