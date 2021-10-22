using System;

namespace Aufgabe_1_2
{
	using System;
	using System.Globalization;
	using System.Text;

	class Program
	{
		static void Main(string[] args)
		{

			Film test = new Film("dJaNgo unCHAINED", "quenTin teReNTiNo", new DateTime(2020, 06, 30), new TimeSpan(2, 31, 34), 18);
			test.ZeichenkettenKorrigieren();
			bool datumEingegeben = false;
			bool zuJung = false;
			DateTime geburtsdatum = new();
			while (test.Gesamtspielzeit.TotalHours < 20)
			{
				try
				{
					if(!datumEingegeben)
					{
						Console.WriteLine("Bitte geben Sie ihr Geburtsdatum ein (Format: DD.MM.JJJJ): ");
						if (DateTime.TryParse(Console.ReadLine(), new CultureInfo("de-DE"), DateTimeStyles.None, out DateTime datum))
						{
							geburtsdatum = datum;
							datumEingegeben = true;
						}
						else
						{
							Console.WriteLine("Bitte beachten Sie das korrekte Datum Format!");
							Console.ReadLine();
							Console.Clear();
							continue;
						}
					}
					test.Abspielen(geburtsdatum);
				}
				catch (InvalidOperationException e)
				{
					Console.WriteLine($"{e.Message}");
					Console.ReadLine();
					Console.Clear();
					zuJung = true;
					break;
				}
				Console.WriteLine(" ");
				Console.WriteLine($"Titel: {test.Titel}");
				Console.WriteLine($"Regisseur: {test.Regisseur}");
				Console.WriteLine($"Release Date: {test.ReleaseDatum}");
				Console.WriteLine($"Spielzeit: {test.Spielzeit}");
				Console.WriteLine($"Mindesalter: {test.Mindestalter}");
				Console.WriteLine($"Gesamt Spielzeit: {test.Gesamtspielzeit}");
				Console.WriteLine($"Wie häufig Abgespielt: {test.WieHäufigAbgespielt}");
				Console.WriteLine($"All time favorite: {test.IstAllzeitFavorit}");
				Console.WriteLine("----------------------------------");
			}
			try
			{
				if(!zuJung)
				{
					Console.WriteLine("Geben Sie dem Film eine Bewertung: ");
					test.Bewertung = Convert.ToInt32(Console.ReadLine());
					if (!test.Bewertung.HasValue)
					{
						Console.WriteLine("Die Bewertung ist null");
					}
					Console.WriteLine("Du hast den Film mit der Qualität: " + test.Qualitätskategorie + " bewertet");
				}
			}
			catch (ArgumentOutOfRangeException e)
			{
				Console.WriteLine(" ");
				Console.WriteLine($"{e.Message}");
			}
			catch(FormatException e)
			{
				Console.WriteLine(" ");
				Console.WriteLine($"{e.Message}");
			}
		}
	}

	class Film
	{
		//backing field
		private string titel;
		private string regisseur;
		private DateTime releaseDatum;
		private TimeSpan spielzeit;
		private byte mindestalter;
		private int? bewertung;
		private int wieHäufigAbgespielt;

		//properties
		public string Titel
		{
			get => titel;
		}
		public string Regisseur
		{
			get => regisseur;
		}
		public DateTime ReleaseDatum
		{
			get => releaseDatum;
		}
		public TimeSpan Spielzeit
		{
			get => spielzeit;
		}
		public TimeSpan Alter
		{
			get => DateTime.Today - releaseDatum;
		}
		public TimeSpan Gesamtspielzeit
		{
			get => new TimeSpan(wieHäufigAbgespielt * Spielzeit.Ticks);
		}
		public byte Mindestalter
		{
			get => mindestalter;
		}
		public int? Bewertung
		{
			get => bewertung;
			set
			{
				if (value < 1 || value > 5)
					throw new ArgumentOutOfRangeException("Bewertung ungültig!");

				bewertung = (int)value;

			}
		}
		public int WieHäufigAbgespielt
		{
			get => wieHäufigAbgespielt;
		}
		public bool IstAllzeitFavorit
		{
			get => (Gesamtspielzeit.TotalHours > 20) ? true : false;
		}

		public enum Qualität
		{
			Unbewertet,
			Schlecht,
			Mittelmäßig,
			Gut
		}

		public Qualität Qualitätskategorie
		{
			get
			{
				return (bewertung == 5 || bewertung == 4) ? Qualität.Gut
					  : (bewertung == 3) ?						  Qualität.Mittelmäßig
					  : (bewertung == 2 || bewertung == 1) ? Qualität.Schlecht
																		: Qualität.Unbewertet;
			}
		}

		public Film(string titel, string regisseur, DateTime releaseDatum, TimeSpan spielzeit, byte mindestalter)
		{
			this.titel = titel;
			this.regisseur = regisseur;
			this.releaseDatum = releaseDatum;
			this.spielzeit = spielzeit;
			this.mindestalter = mindestalter;
			ZeichenkettenKorrigieren();
		}

		public bool MindestalterErreicht(DateTime geburtsDatum)
		{
			TimeSpan alter = DateTime.Today - geburtsDatum;
			if (alter.TotalDays / 365 >= mindestalter)
			{
				return true;
			}
			return false;
		}

		public void Abspielen(DateTime geburtsDatum)
		{
			if (MindestalterErreicht(geburtsDatum))
			{
				wieHäufigAbgespielt++;
			}
			else
			{
				throw new InvalidOperationException("Alter des Konsumenten entspricht nicht dem Mindestalter");
			}
		}

		public void ZeichenkettenKorrigieren()
		{
			StringBuilder stringBuilder = new StringBuilder(titel.ToLower());

			for (int i = 0; i < stringBuilder.Length; i++)
			{
				try
				{
					if (i == 0)
					{
						stringBuilder[0] = char.ToUpper(stringBuilder[0]);
					}

					if (stringBuilder[i] == ' ')
					{
						stringBuilder[i + 1] = char.ToUpper(stringBuilder[i + 1]);
					}
				}

				catch (IndexOutOfRangeException e)
				{
					Console.WriteLine($"{e.Message}");
				}
			}

			titel = stringBuilder.ToString();
			stringBuilder.Clear();
			stringBuilder.Insert(0, regisseur.ToLower());

			for (int i = 0; i < stringBuilder.Length; i++)
			{
				try
				{
					if (i == 0)
					{
						stringBuilder[0] = char.ToUpper(stringBuilder[0]);
					}
					if (stringBuilder[i] == ' ')
					{
						stringBuilder[i + 1] = char.ToUpper(stringBuilder[i + 1]);
					}
				}

				catch (IndexOutOfRangeException e)
				{
					Console.WriteLine($"{e.Message}");
				}
			}

			regisseur = stringBuilder.ToString();
		}
	}
}