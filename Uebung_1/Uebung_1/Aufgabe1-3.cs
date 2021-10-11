using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe_1_3
{
   class Program
   {
      static void Main()
      {
         DateTime releaseDateFilm = new DateTime(2007, 8, 1);
         TimeSpan timeSpanFilm = new TimeSpan(2, 24, 0);
         Film film = new Film("TRaNsfoRmeRs", "MicHaEl BAy", releaseDateFilm, timeSpanFilm, 12);

         DateTime releaseDateCD = new DateTime(2010, 9, 10);
         TimeSpan timeSpanCD = new TimeSpan(0, 47, 0);
         string[] lieder = new string[] { "ThE ReQuIeM", "THe RAdIanCe", "BuRniNg iN tHe SkIEs" };
         CD cd = new CD("A Thousand Suns", "Linkin Park", lieder,  3, releaseDateCD, timeSpanCD, 6);

         Abspielmedium abspielmedium1 = film;
         abspielmedium1.ZeichenkettenKorrigieren();
         Abspielmedium abspielmedium2 = cd;
         abspielmedium2.ZeichenkettenKorrigieren();

         Console.WriteLine("Titel von abspielmedium1: " + abspielmedium1.Titel);
         Console.WriteLine("Titel von abspielmedium2: " + abspielmedium2.Titel);
      }
   }

   public abstract class Abspielmedium
   {
      public Abspielmedium(string title, DateTime releaseDate, TimeSpan playTime, byte minAge)
      {
         this.titel = title;
         this.releaseDatum = releaseDate;
         this.spielzeit = playTime;
         this.mindestalter = minAge;
         this.bewertung = 0;
         this.wieHäufigAbgespielt = 0;
      }
      public enum Qualität
      {
         Gut = 0,
         Mittelmäßig,
         Schlecht,
         Unbewertet
      };

      public TimeSpan Alter { get { return DateTime.Today - releaseDatum; } }

      public TimeSpan Gesamtspielzeit { get { return spielzeit * wieHäufigAbgespielt; } }
      
      public Qualität Qualitätskategorie
      {
         get
         {
            return (bewertung == 5 || bewertung == 4) ? Qualität.Gut
                 : (bewertung == 3)                   ? Qualität.Mittelmäßig
                 : (bewertung == 2 || bewertung == 1) ? Qualität.Schlecht
                                                      : Qualität.Unbewertet; 
         }
      }

      public string Titel { get { return titel; } }

      public DateTime ReleaseDatum { get { return releaseDatum; } }

      public TimeSpan Spielzeit { get { return spielzeit; } }

      public byte Mindestalter { get { return mindestalter; } }

      public int WieHäufigAbgespielt { get { return wieHäufigAbgespielt; } }

      public int Bewertung
      {
         set 
         {
            if (value < 0 || value > 5)
               throw new ArgumentOutOfRangeException();
            else
               bewertung = value;
         }
         get { return bewertung; }
      }

      public bool MindestalterErreicht(DateTime geburtsdatum)
      {
         byte age = Convert.ToByte(DateTime.Today.Year - geburtsdatum.Year);
         return age >= this.Mindestalter;
      }

      public void Abspielen(DateTime geburtsdatum)
      {
         if (MindestalterErreicht(geburtsdatum) == false)
            throw new InvalidOperationException();
         else
            ++wieHäufigAbgespielt;
      }
      public abstract bool IstAllzeitFavorit { get; }
      public abstract void ZeichenkettenKorrigieren();

      protected string titel;
      private DateTime releaseDatum;
      private TimeSpan spielzeit;
      private byte mindestalter;
      private int wieHäufigAbgespielt;
      private int bewertung;
   }

   class Film: Abspielmedium
   {
      public Film(string title, string director, DateTime releaseDate, TimeSpan playTime, byte minAge)
         :base(title, releaseDate, playTime, minAge)
      {
         this.regisseur = director;
      }
      public override void ZeichenkettenKorrigieren()
      {
         // Titel anpassen
         string firstLetterTitle = Titel.Substring(0, 1);
         string titleWithoutFirstLetter = Titel.Substring(1, Titel.Length - 1);
         string correctedTitle = firstLetterTitle.ToUpper() + titleWithoutFirstLetter.ToLower();
         this.titel = correctedTitle;

         // Regisseur anpassen
         string firstLetterDirector = Regisseur.Substring(0, 1);
         string directorWithoutFirstLetter = Regisseur.Substring(1, Regisseur.Length - 1);
         string correctedDirector = firstLetterDirector.ToUpper() + directorWithoutFirstLetter.ToLower();
         this.regisseur = correctedDirector;
      }

      public string Regisseur { get { return regisseur; } }

      public override bool IstAllzeitFavorit { get { return Gesamtspielzeit.Hours > 20; } }

      private string regisseur;
   }

   class CD : Abspielmedium
   {
      public CD(string title, string artist, string[] songs, int numberOfSongs, DateTime releaseDate, TimeSpan playTime, byte minAge)
         : base(title, releaseDate, playTime, minAge)
      {
         this.interpret = artist;
         this.lieder = songs;
         this.anzahlLieder = numberOfSongs;
      }
      public override void ZeichenkettenKorrigieren()
      {
         // Titel anpassen
         string firstLetterTitle = Titel.Substring(0, 1);
         string titleWithoutFirstLetter = Titel.Substring(1, Titel.Length - 1);
         string correctedTitle = firstLetterTitle.ToUpper() + titleWithoutFirstLetter.ToLower();
         this.titel = correctedTitle;

         // Interpret anpassen
         string firstLetterArtist = Interpret.Substring(0, 1);
         string artistWithoutFirstLetter = Interpret.Substring(1, Interpret.Length - 1);
         string correctedArtist = firstLetterArtist.ToUpper() + artistWithoutFirstLetter.ToLower();
         this.interpret = correctedArtist;

         // Lieder anpassen
         for(int i = 0; i < anzahlLieder; ++i)
         {
            string firstLetterSong = lieder[i].Substring(0, 1);
            string songWithoutFirstLetter = lieder[i].Substring(1, lieder[i].Length - 1);
            string correctedSong = firstLetterSong.ToUpper() + songWithoutFirstLetter.ToLower();
            this.lieder[i] = correctedSong;
         }
      }

      public string Interpret { get { return interpret; } }
      public string[] Lieder { get { return lieder; } }

      public override bool IstAllzeitFavorit { get { return Gesamtspielzeit.Hours > 40; } }

      private string interpret;
      private string[] lieder;
      private int anzahlLieder;
   }
}