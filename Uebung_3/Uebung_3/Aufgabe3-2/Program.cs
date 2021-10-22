using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_3_2
{
	class Program
	{
		static void testeMeineEventListe<T>(T element)
		{
			MeineEventListe<T> liste = new MeineEventListe<T>();
			
			// Event Handler registrieren
			liste.ElementHinzugefügt += MeineEventListe<T>.BehandleEreignis;
			liste.ElementEntfernt += MeineEventListe<T>.BehandleEreignis;
			
			liste.ElementHinzufügen(element);
			liste.ElementHinzufügen(element);

			Console.WriteLine(liste[1]);
			int anzahl = liste.AnzahlElemente;
			Console.WriteLine("Die Liste besitzt: " + anzahl + " Element");

			liste.ElementEntfernen(element);
			Console.WriteLine("");
		}
		static void Main(string[] args)
		{
			int value1 = 10;
			double value2 = 20.34;
			string value3 = "testString";
			Program.testeMeineEventListe(value1);
			Program.testeMeineEventListe(value2);
			Program.testeMeineEventListe(value3);
		}
	}

	interface IEventListe<T>
	{
		T this[int index]
		{
			get;
			set;
		}
		int AnzahlElemente
		{
			get;
		}
		void ElementHinzufügen(T element);
		void ElementEntfernen(T element);
		event System.EventHandler<T> ElementHinzugefügt;
		event System.EventHandler<T> ElementEntfernt;
	}

	public class MeineEventListe<T> : IEventListe<T>
	{
		public event System.EventHandler<T> ElementHinzugefügt;
		public event System.EventHandler<T> ElementEntfernt;

		private List<T> list = new List<T>();
		public T this[int i]
		{
			get { return list[i]; }
			set { list[i] = value; }
		}

		public int AnzahlElemente => list.Count;

		public void ElementHinzufügen(T element)
		{
			list.Add(element);
			ElementHinzugefügt.Invoke("Element wurde hinzufgefügt: ", element);
		}

		public void ElementEntfernen(T element)
		{
			if (!list.Any())
			{
				Console.WriteLine("Liste leer!");
				return;
			}
			list.Remove(element);
			ElementEntfernt.Invoke("Element wurde entfernt: ", element);
		}

		public static void BehandleEreignis(object sender, T element) 
		{
			Console.WriteLine(sender.ToString() + element.ToString());
		}
	}
}
