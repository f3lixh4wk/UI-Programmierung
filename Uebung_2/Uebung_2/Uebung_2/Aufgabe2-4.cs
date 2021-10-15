using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

namespace Aufgabe_2_4
{
   class MainClass
   {
      static void Main()
      {
         Hauptmenü hauptmenü = new Hauptmenü();
         hauptmenü.Run();
      }
   }

   [Serializable()]
   class Film
   {
      //backing field
      private string titel;
      private string regisseur;
      private DateTime releaseDatum;
      private TimeSpan spielzeit;
      private byte mindestalter;
      private int bewertung = 0;
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
         get => wieHäufigAbgespielt * Spielzeit;
      }
      public byte Mindestalter
      {
         get => mindestalter;
      }
      public Nullable<int> Bewertung
      {
         get => bewertung;
         set
         {
            if (value < 0 || value > 5)
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
                 : (bewertung == 3) ? Qualität.Mittelmäßig
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

      public string LangeBeschreibung
      {
         get
         {
            return string.Format(
            "{0,-25}{1}\n{2,-25}{3}\n{4,-25}{5:dd\\.MM\\.yyyy}\n{6,-25}{7:hh\\:mm\\:ss}\n" +
            "{8,-25}{9}\n{10,-25}{11}\n{12,-25}{13}\n{14,-25}{15:%d} Tage\n{16,-25}{17:hh\\:mm\\:ss}\n" +
            "{18,-25}{19}{20}",
            "Titel:", Titel,
            "Regisseur:", Regisseur,
            "Release-Datum:", ReleaseDatum,
            "Spielzeit:", Spielzeit,
            "Mindestalter:", Mindestalter,
            "Bewertung:", Bewertung.HasValue ? Bewertung.Value.ToString() : "nicht vorhanden",
            "Anzahl Abspielungen:", WieHäufigAbgespielt,
            "Alter:", Alter,
            "Gesamtspielzeit:", Gesamtspielzeit,
            "Qualitätskategorie:", Qualitätskategorie,
            IstAllzeitFavorit ? "\nDer Film ist ein Allzeit-Favorit!" : "");
         }
      }
   }

   class Hauptmenü
   {
      List<Film> filmliste = new List<Film>();
      bool beenden = false;
      public void Run()
      {
         do
         {
            ZeigeMenü();
            char eingabe = Console.ReadKey(true).KeyChar;
            switch (eingabe)
            {
               case '1':
                  FilmHinzufügen();
                  break;
               case '2':
                  AlleFilmeAuflisten();
                  break;
               case '3':
                  ListeLeeren();
                  break;
               case '4':
                  FilmAuswählen();
                  break;
               case '5':
                  StatistikAusgeben();
                  break;
               case '6':
                  ListeSpeichern();
                  break;
               case '7':
                  ListeLaden();
                  break;
               case '8':
                  MenüBeenden();
                  break;
               default:
                  Console.WriteLine("Ungültige Eingabe!");
                  Console.ReadKey(true);
                  break;
            }
         } while (!beenden);
      }
      void ZeigeMenü()
      {
         Console.Clear();
         Console.WriteLine("Willkommen! Was wollen Sie tun?\n" +
         "(1) Film Hinzufügen\n" +
         "(2) Alle Filme Auflisten\n" +
         "(3) Liste leeren\n" +
         "(4) Film auswählen\n" +
         "(5) Statistik ausgeben\n" +
         "(6) Liste speichern\n" +
         "(7) Liste laden\n" +
         "(8) Menü beenden\n");
      }
      void FilmHinzufügen()
      {
         //Ergänzen
         Console.WriteLine("Film hinzufügen");
         Console.WriteLine("Bitte geben Sie einen Titel an: ");
         string titel = Console.ReadLine();
         Console.WriteLine("Bitte geben Sie einen Regisseur an: ");
         string regisseur = Console.ReadLine();
         Console.WriteLine("Bitte geben Sie das Release Datum an: ");
         DateTime releaseDatum = Convert.ToDateTime(Console.ReadLine());
         Console.WriteLine("Bitte geben Sie die Spielzeit an: ");
         TimeSpan spielzeit = TimeSpan.Parse(Console.ReadLine());
         Console.WriteLine("Bitte geben Sie das Mindestalter an: ");
         byte mindestalter = Convert.ToByte(Console.ReadLine());

         Film film = new Film(titel, regisseur, releaseDatum, spielzeit, mindestalter);
         filmliste.Add(film);
      }
      void AlleFilmeAuflisten()
      {
         //Ergänzen
         foreach(Film film in filmliste)
         {
            Console.WriteLine(film.LangeBeschreibung + "\n");
         }
         Console.ReadLine();
      }
      void ListeLeeren()
      {
         //Ergänzen
         filmliste.Clear();
      }
      void FilmAuswählen()
      {
         Film gefundenerFilm = null;
         //Ergänzen: Filmtitel eingeben lassen, Film suchen
         Console.WriteLine("Geben Sie den Filmtitel ein, den sie suchen:");
         string filmTitel = Console.ReadLine();
         foreach(Film film in filmliste)
         {
            if (film.Titel == filmTitel)
               gefundenerFilm = film;
         }
         if (gefundenerFilm == null)
         {
            Console.WriteLine("Der Film konnte nicht gefunden werden!");
            Console.ReadKey(true);
            return;
         }
         Console.WriteLine("Starte Untermenü...");
         Console.ReadKey(true);
         Untermenü untermenü = new Untermenü(filmliste, gefundenerFilm);
         untermenü.Run();
      }
      void StatistikAusgeben()
      {
         //Ergänzen
         Film längsterTitel = filmliste.First();
         int anzahlAllzeitFavoriten = 0;
         TimeSpan gesamtLängeAllerFilme = new TimeSpan(0,0,0);
         TimeSpan gesamtAbspielZeitAllerFilme = new TimeSpan(0,0,0);
         foreach(Film film in filmliste)
         {
            if (längsterTitel.Spielzeit < film.Spielzeit)
            {
               längsterTitel = film;
            }

            if (film.IstAllzeitFavorit)
               ++anzahlAllzeitFavoriten;

            gesamtLängeAllerFilme += film.Spielzeit;
            gesamtAbspielZeitAllerFilme += film.Gesamtspielzeit;
         }
         TimeSpan durchschnittlicheLängeAllerFilme = gesamtLängeAllerFilme / filmliste.Count;

         Console.WriteLine("Länge des längsten Filmtitels: " + längsterTitel.Titel + ": " + längsterTitel.Spielzeit);
         Console.WriteLine("Anzahl von Allzeit-Favoriten: " + anzahlAllzeitFavoriten);
         Console.WriteLine("Durchschnittliche Filmlänge: " + durchschnittlicheLängeAllerFilme);
         Console.WriteLine("Gesamte Abspielzeit: " + gesamtAbspielZeitAllerFilme);
         Console.ReadLine();
      }

      void ListeSpeichern()
      {
         if (IstListeLeer())
            return;
         Console.Write("Bitte den Pfad zum Speichern eingeben: ");
         string pfad = ConsoleTools.LeseZeichenkette();
         BinaryFormatter formatter = new BinaryFormatter();
         try
         {
            using (System.IO.FileStream fs = new System.IO.FileStream(pfad, FileMode.Create))
            {
#pragma warning disable SYSLIB0011 // Typ oder Element ist veraltet
               formatter.Serialize(fs, filmliste);
#pragma warning restore SYSLIB0011 // Typ oder Element ist veraltet
               Console.WriteLine("Die Liste wurde erfolgreich gespeichert!");
            }
         }
         catch (Exception exc)
         {
            Console.WriteLine("Ein Fehler ist aufgetreten: " + exc.Message);
         }
         Console.ReadKey(true);
      }

      void ListeLaden()
      {
         if (!IstListeLeer(false))
         {
            Console.Write("Die aktuelle Liste geht verloren, wenn eine andere geladen wird. Fortfahren (j/n)? ");
            if (!ConsoleTools.LeseJaNein())
               return;
         }
         Console.Write("Bitte den Pfad zum Laden eingeben: ");
         string pfad = ConsoleTools.LeseZeichenkette();
         BinaryFormatter formatter = new BinaryFormatter();
         try
         {
            using (System.IO.FileStream fs = new System.IO.FileStream(pfad, FileMode.Open))
            {
#pragma warning disable SYSLIB0011 // Typ oder Element ist veraltet
               filmliste = (List<Film>)formatter.Deserialize(fs);
#pragma warning restore SYSLIB0011 // Typ oder Element ist veraltet
               Console.WriteLine("Die Liste wurde erfolgreich geladen!");
            }
         }
         catch (Exception exc)
         {
            Console.WriteLine("Ein Fehler ist aufgetreten: " + exc.Message);
         }
         Console.ReadKey(true);
      }

      bool IstListeLeer(bool druckeInfo = true)
      {
         if (filmliste.Count == 0)
         {
            if (druckeInfo)
            {
               Console.WriteLine("Es sind keine Filme vorhanden!");
               Console.ReadKey(true);
            }
            return true;
         }
         else
            return false;
      }

      void MenüBeenden()
      {
         Console.Write("Soll das Menü wirklich beendet werden (j/n)? ");
         beenden = ConsoleTools.LeseJaNein();
      }
   };

   class Untermenü
   {
      List<Film> filmliste;
      Film ausgewählterFilm;
      bool beenden = false;
      public Untermenü(List<Film> filmliste, Film ausgewählterFilm)
      {
         this.filmliste = filmliste;
         this.ausgewählterFilm = ausgewählterFilm;
      }
      public void Run()
      {
         do
         {
            ZeigeMenü();
            char eingabe = Console.ReadKey(true).KeyChar;
            switch (eingabe)
            {
               case '1':
                  FilmAnschauen();
                  break;
               case '2':
                  FilmLöschen();
                  break;
               case '3':
                  BewertungÄndern();
                  break;
               case '4':
                  MenüBeenden();
                  break;
               default:
                  Console.WriteLine("Ungültige Eingabe!");
                  Console.ReadKey(true);
                  break;
            }
         } while (!beenden);
      }
      void ZeigeMenü()
      {
         Console.Clear();
         Console.WriteLine("Derzeit ausgewählt\n: " + ausgewählterFilm.LangeBeschreibung + "\n\n. Was wollen Sie tun?\n" +
         "(1) Film gucken\n" +
         "(2) Film aus Liste löschen\n" +
         "(3) Bewertung ändern\n" +
         "(4) Zurück zum Hauptmenü\n");
      }
      void FilmAnschauen()
      {
         //Ergänzen
         // Film anschauen: Es wird zunächst das Geburtsdatum des Benutzers abgefragt. Ist dieser alt genug, wird der Film angeschaut, andernfalls wird eine Fehlermeldung ausgegeben.
         Console.WriteLine("Geben Sie ihr Geburtstdatum ein (DD:MM:YYYY): ");
         DateTime geburtstdatum = Convert.ToDateTime(Console.ReadLine());
         ausgewählterFilm.Abspielen(geburtstdatum);
      }

      void FilmLöschen()
      {
         //Ergänzen
         int filmIndex = 0;
         for(int i = 0; i < filmliste.Count; ++i)
         {
            if(filmliste.ElementAt(i).Titel == ausgewählterFilm.Titel)
            {
               filmIndex = i;
            }
         }
         filmliste.RemoveAt(filmIndex);
      }
      void BewertungÄndern()
      {
         //Ergänzen
         Console.WriteLine("Geben Sie eine neue Bewertung zwischen 1 und 5 ein: ");
         int bewertung = Convert.ToInt32(Console.ReadLine());
         ausgewählterFilm.Bewertung = bewertung;
      }
      void MenüBeenden()
      {
         Console.Write("Zum Hauptmenü zurückkehren (j/n)? ");
         beenden = ConsoleTools.LeseJaNein();
      }
   }

   static class ConsoleTools
   {
      public static DateTime LeseDatum()
      {
         return LeseIrgendwas<DateTime>(str => DateTime.ParseExact(str, @"d.M.yyyy", System.Globalization.CultureInfo.InvariantCulture), "22.9.2014");
      }
      public static TimeSpan LeseZeitspanne()
      {
         return LeseIrgendwas<TimeSpan>(str => TimeSpan.ParseExact(str, @"h\:mm\:ss", System.Globalization.CultureInfo.InvariantCulture), "1:42:08");
      }
      public static byte LeseByte()
      {
         return LeseIrgendwas<byte>(str => byte.Parse(str), "Der Wert muss zwischen 0 und 255 liegen.");
      }
      public static bool LeseJaNein(string ja = "j", string nein = "n")
      {
         return LeseIrgendwas<bool>(str =>
         {
            string lower = str.ToLower();
            if (lower == ja.ToLower())
               return true;
            if (lower == nein.ToLower())
               return false;
            throw new InvalidCastException();
         },
         ja + " oder " + nein + ", mehr Auswahl gibt es nicht!");
      }
      public static string LeseZeichenkette()
      {
         return Console.ReadLine();
      }
      private static T LeseIrgendwas<T>(Func<string, T> parser, string beispiel = null)
      {
         T ergebnis = default(T);
         bool richtigEingelesen = false;
         do
         {
            try
            {
               string zeile = Console.ReadLine();
               ergebnis = parser(zeile);
               richtigEingelesen = true;
            }
            catch
            {
               Console.WriteLine("Die Eingabe ist fehlerhaft!");
               if (beispiel != null)
                  Console.WriteLine("Beispiel für korrekte Eingabe: " + beispiel);
               Console.Write("Bitte noch einmal versuchen: ");
            }
         } while (!richtigEingelesen);
         return ergebnis;
      }
   }
}

