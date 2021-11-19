using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aufgabe5_3
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
	}
}

namespace MeineKlassen
{
	[System.ComponentModel.TypeConverter(typeof(AdressConverter))]
	public class Adresse
	{
		public Adresse()
		{
			_strasse = "";
			_hausnummer = 0;
			_ort = "";
			_postleitzahl = 0;
		}

		public override string ToString()
		{
			return _strasse + " " + _hausnummer + ", " + _postleitzahl + " " + _ort;
		}

		private string _strasse;
		public string Strasse { get { return _strasse; } set { _strasse = value; } }

		private ushort _hausnummer;
		public ushort Hausnummer { get { return _hausnummer; } set { _hausnummer = value; } }

		private string _ort;
		public string Ort { get { return _ort; } set { _ort = value; } }

		private ulong _postleitzahl;
		public ulong Postleitzahl { get { return _postleitzahl; } set { _postleitzahl = value; } }
	}

	public enum Geschlecht
	{
		Männlich = 0,
		Weiblich,
		Unbekannt
	}

	[ContentProperty("VollerName")]
	public class Person
	{
		public Person()
		{
			_vollerName = "";
			_geschlecht = Geschlecht.Unbekannt;
			_adresse = new Adresse();
		}

		public object Content { get { return _vollerName; } set { _vollerName = (string)value; } }

		public override string ToString()
		{
			return _vollerName + ", " + _geschlecht + ", wohnhaft in " + _adresse;
		}

		private string _vollerName;
		public string VollerName { get { return _vollerName; } set { _vollerName = value; } }

		private Geschlecht _geschlecht;
		public Geschlecht Geschlecht { get { return _geschlecht; } set { _geschlecht = value; } }

		private Adresse _adresse;
		public Adresse Adresse { get { return _adresse; } set { _adresse = value; } }

		private Namen _name;
		public Namen Name { get { return _name; } set { _name = value; } }
	}

	public class Namen
	{
		public static string Vorname { get { return "Herbert"; } }
	}

	class AdressConverter : System.ComponentModel.TypeConverter
	{
		public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(string))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}
		public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			try
			{
				char[] ziffern = "0123456789".ToCharArray();
				string strValue = ((string)value).Trim();
				Adresse adresse = new Adresse();
				int hausnummerPos = strValue.IndexOfAny(ziffern);
				adresse.Strasse = strValue.Substring(0, hausnummerPos - 1);
				int kommaPos = strValue.IndexOfAny(new char[] { ',', ' ' }, hausnummerPos);
				adresse.Hausnummer = ushort.Parse(strValue.Substring(hausnummerPos, kommaPos - hausnummerPos));
				int postleitzahlPos = strValue.IndexOfAny(ziffern, kommaPos);
				int ortPos = strValue.IndexOf(' ', postleitzahlPos) + 1;
				adresse.Postleitzahl = ulong.Parse(strValue.Substring(postleitzahlPos, ortPos - postleitzahlPos - 1));
				adresse.Ort = strValue.Substring(ortPos, strValue.Length - ortPos);
				return adresse;
			}
			catch
			{
				throw new Exception(string.Format("Der Wert {0} kann nicht in den Typ {1} umgewandelt werden.", value, typeof(Adresse)));
			}
		}
	}
}
